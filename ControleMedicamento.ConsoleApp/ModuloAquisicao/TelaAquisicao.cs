using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloFornecedor;
using ControleMedicamento.ConsoleApp.ModuloFuncionario;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloAquisicao
{
    internal class TelaAquisicao : CompartilhadoComun
    {
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioFuncionario RepositorioFuncionario = null;
        public RepositorioAquisicao repositorioAquisicao = null;

        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Aquisicao ===");
                Console.WriteLine("1 - Adicionar Aquisicao");
                Console.WriteLine("2 - Listar Aquisicao");
                Console.WriteLine("3 - Editar Aquisicao");
                Console.WriteLine("4 - Remover Aquisicao");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarAquisicao();
                        break;
                    case 2:
                        ListarAquisicao();
                        break;
                    case 3:
                        EditarAquisicao();
                        break;
                    case 4:
                        ExcluirAquisicao();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        break;
                }
            } while (opcao != 0);
        }

        public Aquisicao ObterAquisicao()
        {
            Aquisicao aquisicao = new Aquisicao();


            Console.WriteLine("Digite a data da aquisição: ");
            aquisicao.Data = Console.ReadLine();
            Console.WriteLine("Digite a quantida de medicamentos: ");
            aquisicao.QuantidadeMedicamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id do medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id do funcionario: ");
            int idFuncionario = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id do Fornecedor de medicamento: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            foreach (Fornecedor fornecedor in repositorioFornecedor.listaObj)
            {
                if (idFornecedor == fornecedor.Id)
                {
                    aquisicao.Fornecedor = fornecedor;
                }
            }

            foreach (Medicamento medicamento in repositorioMedicamento.listaObj)
            {
                if (idMedicamento == medicamento.Id)
                {
                    aquisicao.Medicamento = medicamento;
                }
            }

            foreach (Funcionario funcionario in RepositorioFuncionario.listaObj)
            {
                if (idFuncionario == funcionario.Id)
                {
                    aquisicao.Funcionario = funcionario;
                }
            }





            return aquisicao;
        }

        public void CadastrarAquisicao()
        {
            Aquisicao aquisicao = ObterAquisicao();
            repositorioAquisicao.CadastrarAquisicao(aquisicao);
        }

        public void ListarAquisicao()
        {
            listaObj = repositorioAquisicao.ListarTodos();
            if (listaObj.Count == 0)
            {
                Console.WriteLine("Nenhum aquisicao cadastrado.");
            }
            else
            {
                foreach (Aquisicao aquisicao in listaObj)
                {
                    Console.WriteLine($"{aquisicao.Id} {aquisicao.Data}\n {aquisicao.Funcionario.Nome}\n {aquisicao.Fornecedor.Nome}\n {aquisicao.Medicamento.Nome}\n {aquisicao.QuantidadeMedicamento}");
                    Console.ReadKey();
                }
            }
        }

        public void EditarAquisicao()
        {
            int idSelecionado = EncontrIdAquisicao();
            Aquisicao aquisicao = ObterAquisicao();

            repositorioAquisicao.Editar(aquisicao, idSelecionado);

        }

        public int EncontrIdAquisicao()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id do aquisicao: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioAquisicao.SelecionarPorId(idSelecionado) == null;

                if (idInvalido) Console.WriteLine("Id invalido, tente novamente");
            } while (idInvalido);
            return idSelecionado;
        }

        public void ExcluirAquisicao()
        {
            Console.WriteLine("Digite o ID do aquisicao que desejar excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Aquisicao aquisicao in listaObj)
            {
                if (idExcluir == aquisicao.Id)
                {
                    listaObj.Remove(aquisicao);
                    return;
                }
            }
        }
    }
}

using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloAquisicao;
using ControleMedicamento.ConsoleApp.ModuloFornecedor;
using ControleMedicamento.ConsoleApp.ModuloFuncionario;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using ControleMedicamento.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloRequisicao
{
    internal class TelaRequisicao : CompartilhadoComun
    {
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFuncionario repositorioFuncionario = null;
        public RepositorioPaciente repositorioPaciente = null;
        public RepositorioRequisicao repositorioRequisicao = null;

        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Requisição ===");
                Console.WriteLine("1 - Adicionar Requisição");
                Console.WriteLine("2 - Listar Requisição");
                Console.WriteLine("3 - Editar Requisição");
                Console.WriteLine("4 - Remover Requisição");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarRequisicao();
                        break;
                    case 2:
                        ListarRequisicao();
                        break;
                    case 3:
                        EditarRequisicao();
                        break;
                    case 4:
                        ExcluirRequisicao();
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

        public Requisicao ObterRequisicao()
        {
            Requisicao requisicao = new Requisicao();


            Console.WriteLine("Digite a data da aquisição: ");
            requisicao.Data = Console.ReadLine();
            Console.WriteLine("Digite a quantida de medicamentos requisitada: ");
            requisicao.QuantidadeRequisitado = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id do medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id do paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id do funcionario de medicamento: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            foreach (Paciente paciente in repositorioPaciente.listaObj)
            {
                if (idPaciente == paciente.Id)
                {
                    requisicao.Paciente = paciente;
                }
            }

            foreach (Medicamento medicamento in repositorioMedicamento.listaObj)
            {
                if (idMedicamento == medicamento.Id)
                {
                    requisicao.Medicamento = medicamento;
                }
            }

            foreach (Funcionario funcionario in repositorioFuncionario.listaObj)
            {
                if (idFuncionario == funcionario.Id)
                {
                    requisicao.Funcionario = funcionario;
                }
            }





            return requisicao;
        }

        public void CadastrarRequisicao()
        {
            Requisicao requisicao = ObterRequisicao();
            repositorioRequisicao.CadastrarRequisicao(requisicao);
        }

        public void ListarRequisicao()
        {
            listaObj = repositorioRequisicao.ListarTodos();
            if (listaObj.Count == 0)
            {
                Console.WriteLine("Nenhum requisicao cadastrado.");
            }
            else
            {
                foreach (Requisicao requisicao in listaObj)
                {
                    Console.WriteLine($"{requisicao.Id} {requisicao.Data}\n {requisicao.Funcionario.Nome}\n {requisicao.Paciente.Nome}\n {requisicao.Medicamento.Nome}\n {requisicao.QuantidadeRequisitado}");
                    Console.ReadKey();
                }
            }
        }

        public void EditarRequisicao()
        {
            int idSelecionado = EncontrIdRequisicao();
            Requisicao requisicao = ObterRequisicao();

            repositorioRequisicao.Editar(requisicao, idSelecionado);

        }

        public int EncontrIdRequisicao()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id do requisicao: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioRequisicao.SelecionarPorId(idSelecionado) == null;

                if (idInvalido) Console.WriteLine("Id invalido, tente novamente");
            } while (idInvalido);
            return idSelecionado;
        }

        public void ExcluirRequisicao()
        {
            Console.WriteLine("Digite o ID do requisicao que desejar excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Requisicao requisicao in listaObj)
            {
                if (idExcluir == requisicao.Id)
                {
                    listaObj.Remove(requisicao);
                    return;
                }
            }
        }
    }
}

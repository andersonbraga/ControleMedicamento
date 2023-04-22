using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloFornecedor;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using ControleMedicamento.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloMedicamento
{
    internal class TelaMedicamento : CompartilhadoComun
    {
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Medicamentos ===");
                Console.WriteLine("1 - Adicionar Medicamentos");
                Console.WriteLine("2 - Listar Medicamentos");
                Console.WriteLine("3 - Editar Medicamentos");
                Console.WriteLine("4 - Remover Medicamentos");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarMedicamento();
                        break;
                    case 2:
                        ListarMedicamento();
                        break;
                    case 3:
                        EditarMedicamento();
                        break;
                    case 4:
                        ExcluirMedicamento();
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

        public Medicamento ObterMedicamento()
        {
            Medicamento medicamento = new Medicamento();
            Fornecedor fornecedorObj = null;

            Console.WriteLine("Digite o nome do Medicamento: ");
            medicamento.Nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição do Medicamento: ");
            medicamento.Descricao = Console.ReadLine();
            Console.WriteLine("Digite a quantidade disponivel de medicamento: ");
            medicamento.QuantidadeDisponivel = Console.ReadLine();
            Console.WriteLine("Digite a quantidade limite de medicamento: ");
            medicamento.QuantidadeLimite = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Id do Fornecedor de medicamento: ");
            int idFornecedor = int.Parse(Console.ReadLine());

            foreach (Fornecedor fornecedor in repositorioFornecedor.listaObj)
            {
                if (idFornecedor == fornecedor.Id)
                {
                    fornecedorObj = fornecedor;
                }
            }

            medicamento.Fornecedor = fornecedorObj;
            
            

            return medicamento;
        }

        public void CadastrarMedicamento()
        {
            Medicamento medicamento = ObterMedicamento();
            repositorioMedicamento.CadastrarMedicamento(medicamento);
        }

        public void ListarMedicamento()
        {
            listaObj = repositorioMedicamento.ListarTodos();
            if (listaObj.Count == 0)
            {
                Console.WriteLine("Nenhum medicamento cadastrado.");
            }
            else
            {
                foreach (Medicamento medicamento in listaObj)
                {
                    Console.WriteLine($"{medicamento.Id} {medicamento.Nome}\n {medicamento.Descricao}\n {medicamento.Fornecedor.Nome}\n {medicamento.QuantidadeLimite}\n {medicamento.QuantidadeDisponivel}");
                    Console.ReadKey();
                }
            }
        }

        public void EditarMedicamento()
        {
            int idSelecionado = EncontrIdMedicamento();
            Medicamento medicamento = ObterMedicamento();

            repositorioMedicamento.Editar(medicamento, idSelecionado);

        }

        public int EncontrIdMedicamento()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id do medicamento: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioMedicamento.SelecionarPorId(idSelecionado) == null;

                if (idInvalido) Console.WriteLine("Id invalido, tente novamente");
            } while (idInvalido);
            return idSelecionado;
        }

        public void ExcluirMedicamento()
        {
            Console.WriteLine("Digite o ID do medicamento que desejar excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Medicamento medicamento in listaObj)
            {
                if (idExcluir == medicamento.Id)
                {
                    listaObj.Remove(medicamento);
                    return;
                }
            }
        }
    }

        
}

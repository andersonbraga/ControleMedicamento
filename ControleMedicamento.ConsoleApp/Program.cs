using ControleMedicamento.ConsoleApp.ModuloAquisicao;
using ControleMedicamento.ConsoleApp.ModuloFornecedor;
using ControleMedicamento.ConsoleApp.ModuloFuncionario;
using ControleMedicamento.ConsoleApp.ModuloMedicamento;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using ControleMedicamento.ConsoleApp.ModuloPaciente;
using ControleMedicamento.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamento.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPaciente telaPaciente = new TelaPaciente();
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            
            
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            

            TelaFornecedor telaFornecedor = new TelaFornecedor();
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();

            TelaMedicamento telaMedicamento = new TelaMedicamento();
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();

            TelaAquisicao telaAquisicao = new TelaAquisicao();
            RepositorioAquisicao repositorioAquisicao = new RepositorioAquisicao();

            TelaRequisicao telaRequisicao = new TelaRequisicao();
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();

            telaRequisicao.repositorioRequisicao = repositorioRequisicao;
            telaRequisicao.repositorioFuncionario = repositorioFuncionario;
            telaRequisicao.repositorioPaciente = repositorioPaciente;

            
            telaAquisicao.repositorioFornecedor = repositorioFornecedor;
            telaAquisicao.repositorioAquisicao = repositorioAquisicao;
            telaAquisicao.repositorioMedicamento = repositorioMedicamento;


            telaPaciente.repositorioPaciente = repositorioPaciente;

            telaFuncionario.repositorioFuncionario = repositorioFuncionario;

            telaFornecedor.repositorioFornecedor = repositorioFornecedor;
            telaFornecedor.repositorioMedicamento = repositorioMedicamento;

            telaMedicamento.repositorioFornecedor = repositorioFornecedor;
            telaMedicamento.repositorioMedicamento = repositorioMedicamento;

            


            int opcao;
            do
            {
                Console.WriteLine("1 - Gerenciar Pacientes");
                Console.WriteLine("2 - Gerenciar Funcionarios");
                Console.WriteLine("3 - Gerenciar Fornecedor");
                Console.WriteLine("4 - Gerenciar Medicamentos");
                Console.WriteLine("5 - Gerenciar Aquisição");
                Console.WriteLine("6 - Gerenciar Requisições");
                Console.WriteLine("Digite uma opção: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        telaPaciente.MostrarMenu();
                        break;
                    case 2:
                        telaFuncionario.MostrarMenu();
                        break;
                    case 3:
                        telaFornecedor.MostrarMenu();
                        break;
                    case 4:
                        telaMedicamento.MostrarMenu();
                        break;
                    case 5:
                        telaAquisicao.MostrarMenu();
                        break;
                    case 6:
                        telaRequisicao.MostrarMenu();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        break;
                }
            } while (opcao != 0);
        }
    }
}
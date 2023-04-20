using ControleMedicamento.ConsoleApp.ModuloFornecedor;
using ControleMedicamento.ConsoleApp.ModuloFuncionario;
using ControleMedicamento.ConsoleApp.ModuloMedicamento;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using ControleMedicamento.ConsoleApp.ModuloPaciente;

namespace ControleMedicamento.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPaciente telaPaciente = new TelaPaciente();
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            telaPaciente.repositorioPaciente = repositorioPaciente;
            
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            telaFuncionario.repositorioFuncionario = repositorioFuncionario;

            TelaMedicamento telaMedicamento = new TelaMedicamento();
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            

            TelaFornecedor telaFornecedor = new TelaFornecedor();
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            telaFornecedor.repositorioFornecedor = repositorioFornecedor;
            telaFornecedor.repositorioMedicamento = repositorioMedicamento;

            int opcao;
            do
            {
                Console.WriteLine("1 - Gerenciar Pacientes");
                Console.WriteLine("2 - Gerenciar Funcionarios");
                Console.WriteLine("3 - Gerenciar Fornecedor");
                Console.WriteLine("4 - Gerenciar Medicamentos");
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
                        telaFuncionario.MostrarMenu();
                        break;
                    case 4:
                        telaMedicamento.MostrarMenu();
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
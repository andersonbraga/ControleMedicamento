using ControleMedicamento.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloPaciente
{
    internal class TelaPaciente : CompartilhadoComun
    {
        public RepositorioPaciente repositorioPaciente = null;

        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Pacientes ===");
                Console.WriteLine("1 - Adicionar Pacientes");
                Console.WriteLine("2 - Listar Pacientes");
                Console.WriteLine("3 - Editar Pacientes");
                Console.WriteLine("4 - Remover Pacientes");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                      CadastrarPaciente();
                        break;
                    case 2:
                     ListarPacientes();
                        break;
                    case 3:
                       EditarPaciente();
                        break;
                    case 4:
                        ExcluirPaciente();
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

        public Paciente ObterPaciente()
        {
            Paciente paciente = new Paciente();

            Console.WriteLine("Digite o nome do paciente: ");
            paciente.Nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf do paciente: ");
            paciente.Cpf = Console.ReadLine();
            Console.WriteLine("Digite o endereço do paciente: ");
            paciente.Endereco = Console.ReadLine();
            Console.WriteLine("Digite o numero do cartão sus do paciente: ");
            paciente.CartaoSus = Console.ReadLine();
            Console.WriteLine("Digite o telefone do paciente: ");
            paciente.Telefone = Console.ReadLine();

            return paciente;
        }

        public void CadastrarPaciente()
        {
            Paciente paciente = ObterPaciente();
            repositorioPaciente.CadastrarPaciente(paciente);
        }

        public void ListarPacientes()
        {
            listaObj = repositorioPaciente.ListarTodos();
            if(listaObj.Count == 0 )
            {
                Console.WriteLine("Nenhum paciente cadastrado.");
            }
            else
            {
                foreach(Paciente paciente in listaObj) 
                {
                    Console.WriteLine($"{paciente.Id} {paciente.Nome}\n {paciente.Cpf}\n {paciente.CartaoSus}\n {paciente.Endereco}\n {paciente.Telefone}");
                    Console.ReadKey();
                }
            }
        }

        public void EditarPaciente()
        {
            int idSelecionado = EncontrIdPaciente();
            Paciente paciente = ObterPaciente();

            repositorioPaciente.Editar(paciente, idSelecionado);

        }

        public int EncontrIdPaciente()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id do paciente: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioPaciente.SelecionarPorId(idSelecionado) == null;

                if (idInvalido) Console.WriteLine("Id invalido, tente novamente");
            } while (idInvalido);
            return idSelecionado;
        }

        public void ExcluirPaciente()
        {
            Console.WriteLine("Digite o ID do paciente que desejar excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Paciente paciente in listaObj)
            {
                if (idExcluir == paciente.Id)
                {
                    listaObj.Remove(paciente);
                    return;
                }
            }
        }
    }
}

using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : CompartilhadoComun
    {
        public RepositorioFuncionario repositorioFuncionario = null;

        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Funcionarios ===");
                Console.WriteLine("1 - Adicionar Funcionarios");
                Console.WriteLine("2 - Listar Funcionarios");
                Console.WriteLine("3 - Editar Funcionarios");
                Console.WriteLine("4 - Remover Funcionarios");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarFuncionario();
                        break;
                    case 2:
                        ListarFuncionario();
                        break;
                    case 3:
                        EditarFuncionario();
                        break;
                    case 4:
                        ExcluirFuncionario();
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

        public Funcionario ObterFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            Console.WriteLine("Digite o nome do funcionario: ");
            funcionario.Nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf do funcionario: ");
            funcionario.Cpf = Console.ReadLine();
            Console.WriteLine("Digite o endereço do funcionario: ");
            funcionario.Endereco = Console.ReadLine();
            Console.WriteLine("Digite o telefone do funcionario: ");
            funcionario.Telefone = Console.ReadLine();

            return funcionario;
        }

        public void CadastrarFuncionario()
        {
            Funcionario funcionario = ObterFuncionario();
            repositorioFuncionario.CadastrarFuncionario(funcionario);
        }

        public void ListarFuncionario()
        {
            listaObj = repositorioFuncionario.ListarTodos();
            if (listaObj.Count == 0)
            {
                Console.WriteLine("Nenhum funcionario cadastrado.");
            }
            else
            {
                foreach (Funcionario funcionario in listaObj)
                {
                    Console.WriteLine($"{funcionario.Id} {funcionario.Nome}\n {funcionario.Cpf}\n  {funcionario.Endereco}\n {funcionario.Telefone}");
                    Console.ReadKey();
                }
            }
        }

        public void EditarFuncionario()
        {
            int idSelecionado = EncontrIdFuncionario();
            Funcionario funcionario = ObterFuncionario();

            repositorioFuncionario.Editar(funcionario, idSelecionado);

        }

        public int EncontrIdFuncionario()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id do funcionario: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioFuncionario.SelecionarPorId(idSelecionado) == null;

                if (idInvalido) Console.WriteLine("Id invalido, tente novamente");
            } while (idInvalido);
            return idSelecionado;
        }

        public void ExcluirFuncionario()
        {
            Console.WriteLine("Digite o ID do funcionario que desejar excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Funcionario funcionario in listaObj)
            {
                if (idExcluir == funcionario.Id)
                {
                    listaObj.Remove(funcionario);
                    return;
                }
            }
        }
    }
}

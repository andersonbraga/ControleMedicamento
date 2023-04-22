using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloFuncionario;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloFornecedor
{
    internal class TelaFornecedor : CompartilhadoComun
    {
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioMedicamento repositorioMedicamento = null;

        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Fornecedor ===");
                Console.WriteLine("1 - Adicionar Fornecedor");
                Console.WriteLine("2 - Listar Fornecedor");
                Console.WriteLine("3 - Editar Fornecedor");
                Console.WriteLine("4 - Remover Fornecedor");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarFornecedor();
                        break;
                    case 2:
                        ListarFornecedor();
                        break;
                    case 3:
                        EditarFornecedor();
                        break;
                    case 4:
                        ExcluirFornecedor();
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

        public Fornecedor ObterFornecedor()
        {
            Fornecedor fornecedor = new Fornecedor();
            Medicamento medicamentoObj = null;

            Console.WriteLine("Digite o nome do fornecedor: ");
            fornecedor.Nome = Console.ReadLine();
            Console.WriteLine("Digite o cnpj do fornecedor: ");
            fornecedor.Cnpj = Console.ReadLine();
            Console.WriteLine("Digite o endereço do fornecedor: ");
            fornecedor.Endereco = Console.ReadLine();
            Console.WriteLine("Digite o telefone do fornecedor: ");
            fornecedor.Telefone = Console.ReadLine();
            Console.WriteLine("Digite o email do fornecedor: ");
            fornecedor.Email = Console.ReadLine();
            //Console.WriteLine("Digite o ID do medicamento que o postinho tem: ");
            //int idMedicamento = Convert.ToInt32(Console.ReadLine());

            //foreach(Medicamento medicamento in listaObj)
            //{
            //    if(idMedicamento == medicamento.Id)
            //    {
            //        medicamentoObj = medicamento;
            //    }
            //}

            return fornecedor;
        }

        public void CadastrarFornecedor()
        {
            Fornecedor fornecedor = ObterFornecedor();
            repositorioFornecedor.Cadastrar(fornecedor);
        }

        public void ListarFornecedor()
        {
            listaObj = repositorioFornecedor.ListarTodos();
            if (listaObj.Count == 0)
            {
                Console.WriteLine("Nenhum fornecedor cadastrado.");
            }
            else
            {
                foreach (Fornecedor fornecedor in listaObj)
                {
                    Console.WriteLine($"{fornecedor.Id} {fornecedor.Nome}\n {fornecedor.Cnpj}\n  {fornecedor.Endereco}\n {fornecedor.Telefone} \n {fornecedor.Email}\n ");
                    //{ fornecedor.Medicamento.Id}
                    Console.ReadKey();
                }
            }
        }

        public void EditarFornecedor()
        {
            int idSelecionado = EncontrIdFornecedor();
            Fornecedor fornecedor = ObterFornecedor();

            repositorioFornecedor.Editar(fornecedor, idSelecionado);

        }

        public int EncontrIdFornecedor()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id do fornecedor: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                idInvalido = repositorioFornecedor.SelecionarPorId(idSelecionado) == null;

                if (idInvalido) Console.WriteLine("Id invalido, tente novamente");
            } while (idInvalido);
            return idSelecionado;
        }

        public void ExcluirFornecedor()
        {
            Console.WriteLine("Digite o ID do fornecedor que desejar excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Fornecedor fornecedor in listaObj)
            {
                if (idExcluir == fornecedor.Id)
                {
                    listaObj.Remove(fornecedor);
                    return;
                }
            }
        }
    }
}

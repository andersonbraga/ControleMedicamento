using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloFuncionario
{
    internal class RepositorioFuncionario : CompartilhadoComun
    {

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            Adicionar(funcionario);
            funcionario.Id = listaObj.Count;
        }

     

        public virtual Entidade Editar(Funcionario funcionarioAtualizado, int id)
        {
            Funcionario funcionario = (Funcionario)SelecionarPorId(id);

            funcionario.Nome = funcionarioAtualizado.Nome;
            funcionario.Cpf = funcionarioAtualizado.Cpf;
            funcionario.Telefone = funcionarioAtualizado.Telefone;
            funcionario.Endereco = funcionarioAtualizado.Endereco;

            return funcionario;
        }

    }
}

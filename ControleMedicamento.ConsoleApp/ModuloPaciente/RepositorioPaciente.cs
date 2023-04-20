using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloPaciente
{
    internal class RepositorioPaciente : CompartilhadoComun
    {
                          
        public void CadastrarPaciente(Paciente paciente)
        {
            Adicionar(paciente);
            paciente.Id = listaObj.Count;
        }

        public virtual Entidade Editar(Paciente pacienteAtualizado, int id)
        {
            Paciente paciente = (Paciente)SelecionarPorId(id);

            paciente.Nome = pacienteAtualizado.Nome;
            paciente.Cpf = pacienteAtualizado.Cpf;
            paciente.Telefone = pacienteAtualizado.Telefone;
            paciente.CartaoSus = pacienteAtualizado.CartaoSus;
            paciente.Endereco = pacienteAtualizado.Endereco;

            return paciente;
        }
   


    }
}

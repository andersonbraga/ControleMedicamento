using ControleMedicamento.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.Compartilhado
{
    internal class CompartilhadoComun
    {

        public List<object> listaObj { get; set; } = new List<object>();

        public void Adicionar(object item) => listaObj.Add(item);

        public List<object> ListarTodos() => listaObj;

        public Entidade SelecionarPorId(int id)
        {
            Entidade entidade = null;

            foreach (Entidade item in listaObj)
            {
                if (item.Id == id)
                {
                    entidade = item;
                    break;
                }
            }
            return entidade;

        }

        //############# Implementar Por Ultimo ############

        //public virtual Entidade Editar(Paciente pacienteAtualizado, int id)
        //{
        //    Paciente paciente = (Paciente)SelecionarPorId(id);

        //    paciente.Nome = pacienteAtualizado.Nome;
        //    paciente.Cpf = pacienteAtualizado.Cpf;
        //    paciente.Telefone = pacienteAtualizado.Telefone;
        //    paciente.CartaoSus = pacienteAtualizado.CartaoSus;
        //    paciente.Endereco = pacienteAtualizado.Endereco;

        //    return paciente;
        //}


    }
}

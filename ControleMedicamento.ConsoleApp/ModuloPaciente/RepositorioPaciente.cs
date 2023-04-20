using ControleMedicamento.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloPaciente
{
    internal class RepositorioPaciente : CompartilhadoComun
    {
        public void AdicionarPaciente(Paciente paciente) 
        {
            listaObj.Add(paciente);
            paciente.Id = listaObj.Count;
        }

        public void CadastrarPaciente(Paciente paciente)
        {
            AdicionarPaciente(paciente);
        }

        public List<object> ListarTodos()
        {
            return listaObj;
        }

        public void ExcluirPaciente()
        {
            Console.WriteLine("Digite o ID do paciente que desejar excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach(Paciente paciente in listaObj)
            {
                if (idExcluir == paciente.Id)
                {
                    listaObj.Remove(paciente);
                    return;
                }
            }
        }

        public void EditarPaciente(Paciente pacienteAtualizado, int  id)
        {
           Paciente paciente = SelecionarPacientePorId(id);

            paciente.Nome = pacienteAtualizado.Nome;
            paciente.Cpf = pacienteAtualizado.Cpf;
            paciente.Telefone = pacienteAtualizado.Telefone;
            paciente.CartaoSus = pacienteAtualizado.CartaoSus;
            paciente.Endereco = pacienteAtualizado.Endereco;
            

        }

        public Paciente SelecionarPacientePorId(int id)
        {
            Paciente paciente = null;

            foreach (Paciente item in listaObj)
            {
                if(item.Id == id)
                {
                    paciente = item;
                    break;
                }
            }
            return paciente;

        }

    }
}

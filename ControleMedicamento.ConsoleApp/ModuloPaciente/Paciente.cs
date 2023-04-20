using ControleMedicamento.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloPaciente
{
    internal class Paciente : Entidade
    {
       

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string CartaoSus { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }


    }
}

using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloFornecedor
{
    internal class Fornecedor : Entidade
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}

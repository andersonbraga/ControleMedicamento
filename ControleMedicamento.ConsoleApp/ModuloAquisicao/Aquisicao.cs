using ControleMedicamento.ConsoleApp.ModuloFornecedor;
using ControleMedicamento.ConsoleApp.ModuloFuncionario;
using ControleMedicamento.ConsoleApp.ModuloMedicamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloAquisicao
{
    internal class Aquisicao
    {
        public Fornecedor Fornecedor { get; set; }
        public Medicamento Medicamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public string Data { get;set; }
        public int QuantidadeMedicamento { get; set; }
    }
}

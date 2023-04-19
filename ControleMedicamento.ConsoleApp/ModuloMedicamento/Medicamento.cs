using ControleMedicamento.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloMedicamentos
{
    internal class Medicamento
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string QuantidadeDisponivel { get; set; }
        public string HistoricoRequisicoes { get; set; }      // public Requisicoes HistoricoRequisicoes {get;set;}
        public int QuantidadeLimite { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}

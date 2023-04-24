using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloMedicamentos
{
    internal class RepositorioMedicamento : CompartilhadoComun
    {
        public void CadastrarMedicamento(Medicamento medicamento)
        {
            Adicionar(medicamento);
            medicamento.Id = listaObj.Count;
        }

        public virtual Entidade Editar(Medicamento medicamentoAtualizado, int id)
        {
            Medicamento medicamento = (Medicamento)SelecionarPorId(id);

            medicamento.Nome = medicamentoAtualizado.Nome;
            medicamento.QuantidadeLimite = medicamentoAtualizado.QuantidadeLimite;
            medicamento.QuantidadeDisponivel = medicamentoAtualizado.QuantidadeDisponivel;
            medicamento.Descricao = medicamentoAtualizado.Descricao;
            medicamento.HistoricoRequisicoes = medicamentoAtualizado.HistoricoRequisicoes;
            medicamento.Fornecedor = medicamentoAtualizado.Fornecedor;

            return medicamento;
        }

        public Entidade JaCadastrado(Medicamento medicamentoComparado, int id, int quantidadeAdicional)
        {
            Medicamento medicamento = (Medicamento)SelecionarPorId(id);

            if(medicamento.Id == id)
            {
                medicamento.QuantidadeLimite += quantidadeAdicional;
            }

                return medicamento;


        }

    }
}

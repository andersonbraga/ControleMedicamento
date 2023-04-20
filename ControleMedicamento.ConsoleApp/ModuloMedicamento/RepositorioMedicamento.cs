﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloMedicamentos
{
    internal class RepositorioMedicamento
    {
        //public void CadastrarMedicamento(Medicamento medicamento) => Adicionar(medicamento);
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

    }
}

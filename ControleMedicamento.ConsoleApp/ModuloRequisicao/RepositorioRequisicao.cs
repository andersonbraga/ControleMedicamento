using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloAquisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloRequisicao
{
    internal class RepositorioRequisicao : CompartilhadoComun
    {
        public void CadastrarRequisicao(Requisicao requisicao)
        {
            Adicionar(requisicao);
            requisicao.Id = listaObj.Count;
        }

        public virtual Entidade Editar(Requisicao requisicaoAtualizado, int id)
        {
            Requisicao requisicao = (Requisicao)SelecionarPorId(id);

            requisicao.QuantidadeRequisitado = requisicaoAtualizado.QuantidadeRequisitado;
            requisicao.Data = requisicaoAtualizado.Data;
            requisicao.Medicamento = requisicaoAtualizado.Medicamento;
            requisicao.Funcionario = requisicaoAtualizado.Funcionario;
            requisicao.Paciente = requisicaoAtualizado.Paciente;

            return requisicao;
        }
    }
}

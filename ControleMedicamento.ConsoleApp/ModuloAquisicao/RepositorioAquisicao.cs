using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloAquisicao
{
    internal class RepositorioAquisicao : CompartilhadoComun
    {
        public void CadastrarAquisicao(Aquisicao aquisicao)
        {
            Adicionar(aquisicao);
            aquisicao.Id = listaObj.Count;
        }

        public virtual Entidade Editar(Aquisicao aquisicaoAtualizado, int id)
        {
            Aquisicao aquisicao = (Aquisicao)SelecionarPorId(id);

            aquisicao.QuantidadeMedicamento = aquisicaoAtualizado.QuantidadeMedicamento;
            aquisicao.Data = aquisicaoAtualizado.Data;
            aquisicao.Medicamento = aquisicaoAtualizado.Medicamento;
            aquisicao.Funcionario = aquisicaoAtualizado.Funcionario;
            aquisicao.Fornecedor = aquisicaoAtualizado.Fornecedor;

            return aquisicao;
        }
    }
}

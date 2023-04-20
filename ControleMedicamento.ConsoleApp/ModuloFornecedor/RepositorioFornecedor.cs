using ControleMedicamento.ConsoleApp.Compartilhado;
using ControleMedicamento.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamento.ConsoleApp.ModuloFornecedor
{
    internal class RepositorioFornecedor : CompartilhadoComun
    {
        public void Cadastrar(Fornecedor fornecedor)
        {
            Adicionar(fornecedor);
            fornecedor.Id = listaObj.Count;
        }



        public virtual Entidade Editar(Fornecedor fornecedorAtualizado, int id)
        {
            Fornecedor fornecedor = (Fornecedor)SelecionarPorId(id);

            fornecedor.Nome = fornecedorAtualizado.Nome;
            fornecedor.Cnpj = fornecedorAtualizado.Cnpj;
            fornecedor.Telefone = fornecedorAtualizado.Telefone;
            fornecedor.Endereco = fornecedorAtualizado.Endereco;
            fornecedor.Email = fornecedorAtualizado.Email;
            fornecedor.Medicamento = fornecedorAtualizado.Medicamento;

            return fornecedor;
        }
    }
}

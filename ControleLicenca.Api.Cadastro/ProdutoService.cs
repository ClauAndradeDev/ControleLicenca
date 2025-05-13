using ControleLicenca.Api.Repositorios;
using ControleLicenca.Modelo.DTOs;
using ControleLicenca.Modelo.Entidades;
using ControleLicenca.Modelo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Api.Services.Cadastro
{
    public class ProdutoService : CrudServices<Produto, ProdutoDto>
    {
        public ProdutoService(ProdutoRepositorio produtoRepositorio,
            Mapper.Mapper mapper) :
            base(produtoRepositorio, mapper)
        {

        }

        public async Task<ProdutoDto> Adicionar(ProdutoDto produto)
        {
            var produtoModel = Mapper.Map<Produto>(produto);
            produtoModel.DataCadastro = DateTime.Now;
            produtoModel.Situacao = SituacaoEnum.Ativo;

            if(produtoModel.DescricaoSistema != null)
            {
                produtoModel = await Repositorio.Add(produtoModel);
            }

            var result = await base.FindByCodigo(produtoModel.Id);

            return result;
        }

        public async Task<ProdutoDto> Alterar(int codProduto, ProdutoDto produto)
        {
            var produtoModelAlterado = Mapper.Map<Produto>(produto);
            var produtoModel = await Repositorio.FindById(codProduto);

            if ((produtoModelAlterado != null) || (produtoModel != null))
            {
                if (produtoModel.DescricaoSistema != produtoModelAlterado.DescricaoSistema) 
                            produtoModel.DescricaoSistema = produtoModelAlterado.DescricaoSistema;
                if (produtoModel.Situacao != produtoModelAlterado.Situacao) 
                            produtoModel.Situacao = (SituacaoEnum)produtoModelAlterado.Situacao;

               produtoModel =  await Repositorio.Replace(codProduto, produtoModel);
            }

            var result = Mapper.Map<ProdutoDto>(produtoModel);

            return result;
        }

        public async Task Excluir(int codProduto)
        {
            var produtoModel = await Repositorio.FindById(codProduto);
            if (produtoModel != null)
            {
                await Repositorio.Remove(produtoModel.Id);
            }
        }
    }
}

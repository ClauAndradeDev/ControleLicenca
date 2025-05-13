using ControleLicenca.Api.Mapper;
using ControleLicenca.Api.Repositorios;
using ControleLicenca.DTOs;
using ControleLicenca.Entidades;
using ControleLicenca.Modelo.Enum;
using Microsoft.VisualBasic;


namespace ControleLicenca.Api.Services.Movimentacao
{
    public class LicencaService : CrudServices<Licenca, LicencaDto>
    {
        public ClienteRepositorio ClienteRepositorio { get; set; }
        public ContratoRepositorio ContratoRepositorio { get; set; }
        public ProdutoRepositorio ProdutoRepositorio { get; set; }


        public LicencaService(LicencaRepositorio licencaRepositorio, 
           ProdutoRepositorio produtoRepositorio,
            ContratoRepositorio contratoRepositorio,
            Mapper.Mapper mapper): 
                base (licencaRepositorio, mapper)
        {
            ProdutoRepositorio = produtoRepositorio;
            ContratoRepositorio = contratoRepositorio;
        }

        public async Task<string> Adicionar(LicencaDto licenca, int codProduto, int codContrato)
        {
            var produtoModel = await ProdutoRepositorio.FindById(codProduto);
            var contratoModel = await ContratoRepositorio.FindById(codContrato);
            var clienteModel = await ClienteRepositorio.FindById(contratoModel.IdCliente);

            var licencaModel = Mapper.Map<Licenca>(licenca);
            licencaModel.DataMovimentacao = DateTime.Now;

            if ((produtoModel != null) || (contratoModel != null))
            {
                licencaModel.DataMovimentacao = DateTime.Now;
                licencaModel.IdContrato = contratoModel.Id;
                licencaModel.IdProduto = produtoModel.Id;
                licencaModel.CodigoHash = produtoModel.DescricaoSistema + ";" + clienteModel.Nome + ";" + DateTime.Now;

                if (contratoModel.Situacao == SituacaoEnum.Ativo) 
                {
                    licencaModel.Situacao = SituacaoEnum.ConfirmadoPagamento;
                    licencaModel = await Repositorio.Add(licencaModel);
                }
                else
                {
                    await InativarLicenca(licencaModel.Id);
                }
            }

            var result = await base.FindByCodigo(licencaModel.Id);

            if (result.Situacao == SituacaoEnum.Ativo)
            {
                return result.CodigoHash;
            }
            else
            {
                return "";
            }

            
        }

        public async Task InativarLicenca (int codLicenca)
        {
            var licencaModel = await Repositorio.FindById(codLicenca);

            licencaModel.DataMovimentacao = DateAndTime.Now;
            licencaModel.Situacao = SituacaoEnum.AusenciaPagamento;

            licencaModel = await Repositorio.Add(licencaModel);

            await Repositorio.Replace(licencaModel.Id, licencaModel);
        }

        //public async Task<LicencaDto> Alterar (int codLicenca, int codProduto, int codContrato, LicencaDto licenca)
        //{
        //    var licencaModel = await Repositorio.FindById(codLicenca);
        //    var contratoModel = await ContratoRepositorio.FindById(codContrato);
        //    var produtoModel = await ProdutoRepositorio.FindById(codProduto);
        //    var clienteModel = await ClienteRepositorio.FindById(contratoModel.IdCliente);

        //    if (licencaModel != null)
        //    {
        //        if ((produtoModel != null) || (contratoModel != null) || (clienteModel != null))
        //        {
        //            if(produtoModel.DescricaoSistema != licenca.Produtos.DescricaoSistema)
        //            {

        //            }
        //        }


        //        //{
        //        //    var produtoJaExiste = licenca.Produtos.Where
        //        //}
        //        //if (clienteModel != null)
        //        //{
        //        //    var clienteJaExiste = licenca.Clientes.Where(l => l.Codigo == clienteModel.Id).Any();
        //        //    if (!clienteJaExiste)
        //        //    {
        //        //        licencaModel.IdCliente = clienteModel.Id;
        //        //    }
        //        //}
        //        //if (contratoModel != null)
        //        //{
        //        //    var contratoJaExiste = licenca.Contratos.Where(c => c.Codigo == contratoModel.Id).Any();
        //        //    if (!contratoJaExiste)
        //        //    {
        //        //        licencaModel.IdContrato = contratoModel.Id;
        //        //    }
        //        //}

        //        licencaModel.Situacao = (SituacaoEnum)licenca.Situacao;
        //        licencaModel = await Repositorio.Replace(licencaModel.Id, licencaModel);
        //    }

        //    var result = Mapper.Map<LicencaDto>(licencaModel);

        //    return result;
        //}

        public async Task<LicencaDto> AjustarSituacao (int codLicenca)
        {
            var licencaModel = await Repositorio.FindById(codLicenca);

            if(licencaModel != null)
            {
                if (licencaModel.Situacao == SituacaoEnum.Ativo)
                {
                    licencaModel.Situacao = SituacaoEnum.Inativo;
                }
                else
                {
                    licencaModel.Situacao = SituacaoEnum.Ativo;
                }
               licencaModel =  await Repositorio.Replace(codLicenca, licencaModel);
            }
            var result = Mapper.Map<LicencaDto>(licencaModel);

            return result;
        }
    }
}

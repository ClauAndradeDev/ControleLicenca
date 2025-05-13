using AutoMapper;
using ControleLicenca.DTOs;
using ControleLicenca.Entidades;
using ControleLicenca.Extensoes;
using ControleLicenca.Modelo.DTOs;
using ControleLicenca.Modelo.Entidades;
using ControleLicenca.Modelo.Extensoes;

namespace ControleLicenca.Api.Mapper
{
    public class Mapper
    {
        protected IMapper MapperConfig { get; set; }

        public Mapper()
        {
            ConfigureMapper(cfg =>
            {
                ConfigureModelToDto(cfg);
                ConfigureDtoToModel(cfg);
            });
        }
        protected void ConfigureMapper(Action<IMapperConfigurationExpression> configurationAction)
        {
            var config = new MapperConfiguration(configurationAction);
            MapperConfig = config.CreateMapper();
        }

        private void ConfigureModelToDto(IMapperConfigurationExpression cfg)
        {
            #region Cliente
            cfg.CreateMap<Cliente, ClienteDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Nome, opt => opt.MapFrom(model => model.Nome))
                .ForMember(dto => dto.Telefone, opt => opt.MapFrom(model => model.Telefone))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.CNPJ, opt => opt.MapFrom(model => model.CNPJ))
                .ForMember(dto => dto.Contratos, opt => opt.MapFrom(model => model.Contratos))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Contrato
            cfg.CreateMap<Contrato, ContratoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Descricao, opt => opt.MapFrom(model => model.Descricao))
                .ForMember(dto => dto.DataInicio, opt => opt.MapFrom(model => model.DataInicio))
                .ForMember(dto => dto.DataFinal, opt => opt.MapFrom(model => model.DataFinal))
                .ForMember(dto => dto.IgnoraDataFinal, opt => opt.MapFrom(model => model.IgnoraDataFinal))
                .ForMember(dto => dto.ValorMensal, opt => opt.MapFrom(model => model.ValorMensal))
                .ForMember(dto => dto.IdCliente, opt => opt.MapFrom(model => model.IdCliente))
                .ForMember(dto => dto.Licencas, opt => opt.MapFrom(model => model.Licencas))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Licenca
            cfg.CreateMap<Licenca, LicencaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.CodigoHash, opt => opt.MapFrom(model => model.CodigoHash))
                .ForMember(dto => dto.DataMovimentacao, opt => opt.MapFrom(model => model.DataMovimentacao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.Contratos, opt => opt.MapFrom(model => model.IdContrato))
                .ForMember(dto => dto.Produtos, opt => opt.MapFrom(model => model.IdProduto))
                .IgnoreAllUnmapped();
            #endregion

            #region Produto
            cfg.CreateMap<Produto, ProdutoDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DescricaoSistema, opt => opt.MapFrom(model => model.DescricaoSistema))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Usuario
            cfg.CreateMap<Usuario, UsuarioDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.DataCadastro, opt => opt.MapFrom(model => model.DataCadastro))
                .ForMember(dto => dto.Nome, opt => opt.MapFrom(model => model.Nome))
                .ForMember(dto => dto.Acesso, opt => opt.MapFrom(model => model.Acesso))
                .ForMember(dto => dto.Senha, opt => opt.MapFrom(model => model.Senha))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion
        }
        private void ConfigureDtoToModel(IMapperConfigurationExpression cfg)
        {
            #region ClienteDto
            cfg.CreateMap<ClienteDto, Cliente>()
               .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
               .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
               .ForMember(model => model.Nome, opt => opt.MapFrom(dto => dto.Nome))
               .ForMember(model => model.Telefone, opt => opt.MapFrom(dto => dto.Telefone))
               .ForMember(model => model.Email, opt => opt.MapFrom(dto => dto.Email))
               .ForMember(model => model.CNPJ, opt => opt.MapFrom(dto => dto.CNPJ))
               //.ForMember(model => model.Contratos, opt=>opt.MapFrom(dto=>dto.Contratos))
               .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
               .IgnoreAllUnmapped();
            #endregion

            #region ContratoDto
            cfg.CreateMap<ContratoDto, Contrato>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Descricao, opt => opt.MapFrom(dto => dto.Descricao))
                .ForMember(model => model.DataInicio, opt => opt.MapFrom(dto => dto.DataInicio))
                .ForMember(model => model.DataFinal, opt => opt.MapFrom(dto => dto.DataFinal))
                .ForMember(model => model.IgnoraDataFinal, opt => opt.MapFrom(dto => dto.IgnoraDataFinal))
                .ForMember(model => model.ValorMensal, opt => opt.MapFrom(dto => dto.ValorMensal))
                .ForMember(model => model.IdCliente, opt => opt.MapFrom(dto => dto.Clientes))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region ProdutoDto
            cfg.CreateMap<ProdutoDto, Produto>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DescricaoSistema, opt => opt.MapFrom(dto => dto.DescricaoSistema))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region LicencaDto
            cfg.CreateMap<LicencaDto, Licenca>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.CodigoHash, opt => opt.MapFrom(dto => dto.CodigoHash))
                .ForMember(model => model.DataMovimentacao, opt => opt.MapFrom(dto => dto.DataMovimentacao))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(model => model.IdContrato, opt => opt.MapFrom(dto => dto.Contratos))
                .ForMember(model => model.IdProduto, opt => opt.MapFrom(dto => dto.Produtos))
                .IgnoreAllUnmapped();
            #endregion

            #region UsuarioDto
            cfg.CreateMap<UsuarioDto, Usuario>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.DataCadastro, opt => opt.MapFrom(dto => dto.DataCadastro))
                .ForMember(model => model.Nome, opt => opt.MapFrom(dto => dto.Nome))
                .ForMember(model => model.Acesso, opt => opt.MapFrom(dto => dto.Acesso))
                .ForMember(model => model.Senha, opt => opt.MapFrom(dto => dto.Senha))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion
        }
        public virtual TResult Map<TResult>(object viewModel)
        {
            return MapperConfig.Map<TResult>(viewModel);
        }
    }
}

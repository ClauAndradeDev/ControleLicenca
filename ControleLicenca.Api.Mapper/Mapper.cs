using AutoMapper;
using ControleLicenca.DTOs;
using ControleLicenca.Entidades;
using ControleLicenca.Extensoes;
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
                .ForMember(dto => dto.DataValidade, opt => opt.MapFrom(model => model.DataValidade))
                .ForMember(dto => dto.ValorMensal, opt => opt.MapFrom(model => model.ValorMensal))
                .ForMember(dto => dto.ValorAnual, opt => opt.MapFrom(model => model.ValorAnual))
                .ForMember(dto => dto.ValorContratoTotal, opt => opt.MapFrom(model => model.ValorContratoTotal))
                .ForMember(dto => dto.PeriodoMeses, opt => opt.MapFrom(model => model.PeriodoMeses))
                .ForMember(dto => dto.PeriodoAnos, opt => opt.MapFrom(model => model.PeriodoAnos))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region Licenca
            cfg.CreateMap<Licenca, LicencaDto>()
                .ForMember(dto => dto.Codigo, opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.CodigoHash, opt => opt.MapFrom(model => model.CodigoHash))
                .ForMember(dto => dto.DataMovimentacao, opt => opt.MapFrom(model => model.DataMovimentacao))
                .ForMember(dto => dto.DataAtivacao, opt => opt.MapFrom(model => model.DataAtivacao))
                .ForMember(dto => dto.DataUltimaAtivacao, opt => opt.MapFrom(model => model.DataUltimaAtivacao))
                .ForMember(dto => dto.Situacao, opt => opt.MapFrom(model => model.Situacao))
                .ForMember(dto => dto.Clientes, opt => opt.MapFrom(model => model.IdCliente))
                .ForMember(dto => dto.Contratos, opt => opt.MapFrom(model => model.IdContrato))
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
                .ForMember(model => model.DataValidade, opt => opt.MapFrom(dto => dto.DataValidade))
                .ForMember(model => model.ValorMensal, opt => opt.MapFrom(dto => dto.ValorMensal))
                .ForMember(model => model.ValorAnual, opt => opt.MapFrom(dto => dto.ValorAnual))
                .ForMember(model => model.ValorContratoTotal, opt => opt.MapFrom(dto => dto.ValorContratoTotal))
                .ForMember(model => model.PeriodoMeses, opt => opt.MapFrom(dto => dto.PeriodoMeses))
                .ForMember(model => model.PeriodoAnos, opt => opt.MapFrom(dto => dto.PeriodoAnos))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .IgnoreAllUnmapped();
            #endregion

            #region LicencaDto
            cfg.CreateMap<LicencaDto, Licenca>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(model => model.CodigoHash, opt => opt.MapFrom(dto => dto.CodigoHash))
                .ForMember(model => model.DataMovimentacao, opt => opt.MapFrom(dto => dto.DataMovimentacao))
                .ForMember(model => model.DataAtivacao, opt => opt.MapFrom(dto => dto.DataAtivacao))
                .ForMember(model => model.DataUltimaAtivacao, opt => opt.MapFrom(dto => dto.DataUltimaAtivacao))
                .ForMember(model => model.Situacao, opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(model => model.IdCliente, opt => opt.MapFrom(dto => dto.Clientes))
                .ForMember(model => model.IdContrato, opt => opt.MapFrom(dto => dto.Contratos))
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

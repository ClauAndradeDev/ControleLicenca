using ControleLicenca.Api.Mapper;
using ControleLicenca.Api.Repositorios;
using ControleLicenca.DTOs;
using ControleLicenca.Entidades;
using ControleLicenca.Modelo.Enum;


namespace ControleLicenca.Api.Services.Movimentacao
{
    public class LicencaService : CrudServices<Licenca, LicencaDto>
    {
        public ClienteRepositorio ClienteRepositorio { get; set; }
        public ContratoRepositorio ContratoRepositorio { get; set; }


        public LicencaService(LicencaRepositorio licencaRepositorio, 
            ClienteRepositorio clienteRepositorio,
            ContratoRepositorio contratoRepositorio,
            Mapper.Mapper mapper): 
                base (licencaRepositorio, mapper)
        {
            ClienteRepositorio = clienteRepositorio;
            ContratoRepositorio = contratoRepositorio;
        }

        public async Task<LicencaDto> Adicionar(LicencaDto licenca, int codCliente, int codContrato)
        {
           
            var clienteModel = await ClienteRepositorio.FindById(codCliente);
            var contratoModel = await ContratoRepositorio.FindById(codContrato);

            var licencaModel = Mapper.Map<Licenca>(licenca);
            licencaModel.DataMovimentacao = DateTime.Now;
            licencaModel.IdCliente = clienteModel.Id;
            licencaModel.IdContrato = contratoModel.Id;
            licencaModel.Situacao = SituacaoEnum.Ativo;

            licencaModel = await Repositorio.Add(licencaModel);


            var result = await base.FindByCodigo(licencaModel.Id);

            return result;
        }

        public async Task<LicencaDto> Alterar (int codLicenca, int codCliente, int codContrato, LicencaDto licenca)
        {
            var licencaModel = await Repositorio.FindById(codLicenca);
            var clienteModel = await ClienteRepositorio.FindById(codCliente);
            var contratoModel = await ContratoRepositorio.FindById(codContrato);

            if (licencaModel != null)
            {
                if (clienteModel != null)
                {
                    var clienteJaExiste = licenca.Clientes.Where(l => l.Codigo == clienteModel.Id).Any();
                    if (!clienteJaExiste)
                    {
                        licencaModel.IdCliente = clienteModel.Id;
                    }
                }
                if (contratoModel != null)
                {
                    var contratoJaExiste = licenca.Contratos.Where(c=>c.Codigo == contratoModel.Id).Any();
                    if (!contratoJaExiste)
                    {
                        licencaModel.IdContrato = contratoModel.Id;
                    }
                }

                licencaModel.Situacao = (SituacaoEnum)licenca.Situacao;
                licencaModel = await Repositorio.Replace(licencaModel.Id, licencaModel);
            }

            var result = Mapper.Map<LicencaDto>(licencaModel);

            return result;
        }

        public async Task<Boolean> Excluir (int codLicenca)
        {
            var licencaModel = await base.FindByCodigo(codLicenca);
            if (licencaModel != null)
            {
                await base.Delete(codLicenca);
            }
            
            return true;
        }

        public async Task<LicencaDto> AjustaSituacao (int codLicenca)
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

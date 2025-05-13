using ContratoLicena.Modelo.Repositorio;
using ControleLicenca.Api.Mapper;
using ControleLicenca.Modelo;
using ControleLicenca.Modelo.Service;

namespace ControleLicenca.Api.Services
{
    public abstract class CrudServices<TModel, TDto> : CrudService<TModel, TDto>
            where TModel : ModelBase
            where TDto : ModelBaseCadastroDto
    {
        public Mapper.Mapper Mapper { get; set; }
        public CrudServices(BaseRepositorio<TModel> repository, Mapper.Mapper mapper) : base(repository)
        {
            Mapper = mapper;
        }

        protected override TModel DtoToModel(TDto obj)
        {
            var result = Mapper.Map<TModel>(obj);
            return result;
        }

        protected override TDto ModelToDto(TModel obj)
        {
            var result = Mapper.Map<TDto>(obj);
            return result;
        }

        protected override TDto[] ModelsToDtos(TModel[] objs)
        {
            var result = Mapper.Map<TDto[]>(objs);
            return result;
        }
    }
}

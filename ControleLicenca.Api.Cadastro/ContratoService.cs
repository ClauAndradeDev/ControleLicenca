using ControleLicenca.Api.Repositorios;
using ControleLicenca.DTOs;
using ControleLicenca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Api.Services.Cadastro
{
    public class ContratoService : CrudServices<Contrato, ContratoDto>
    {
        public ContratoService(ContratoRepositorio contratoRepositorio, Mapper.Mapper mapper):
            base (contratoRepositorio, mapper)
        {

        }

        public async Task<ContratoDto> Adicionar(ContratoDto contrato)
        {
            var contratoDto = new ContratoDto();
            contrato.DataCadastro = DateTime.Now;
            if (contrato.DataInicio != DateTime.Now) 
            {
                if(contrato.Descricao != null)
                {
                    contratoDto = await base.Insert(contrato);
                }
            }
            var result = await base.FindByCodigo(contratoDto.Codigo);

            return result;
        }

        public async Task<ContratoDto> Alterar (int codContrato, ContratoDto contrato)
        {
            var contratoDto = await base.FindByCodigo(codContrato);
            var contratoModel = Mapper.Map<Contrato>(contrato);

            if (contratoDto != null) 
            {
                await Repositorio.Replace(contratoModel.Id, contratoModel);
            }

            var result = Mapper.Map<ContratoDto>(contratoModel);

            return result;

        }

        public async Task Excluir (int codContrato)
        {
            var contratoModel = await Repositorio.FindById(codContrato);
            if (contratoModel != null)
            {
                await Repositorio.Remove(codContrato);
            }
        }
    }
}

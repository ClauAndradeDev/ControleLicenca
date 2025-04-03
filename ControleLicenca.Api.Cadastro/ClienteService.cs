using ControleLicenca.Api.Repositorios;
using ControleLicenca.DTOs;
using ControleLicenca.Entidades;
using ControleLicenca.Modelo.Enum;

namespace ControleLicenca.Api.Services.Cadastro
{
    public class ClienteService : CrudServices<Cliente, ClienteDto>
    {
        public ClienteService(ClienteRepositorio clienteRepositorio,
            Mapper.Mapper mapper) : base(clienteRepositorio, mapper)
        {

        }

        public async Task<ClienteDto> Adicionar(ClienteDto cliente)
        {
            var result = new ClienteDto();
            cliente.DataCadastro = DateTime.Now;
            if ((cliente.Nome != null) && (cliente.Telefone != null) && (cliente.Email != null))
            {
                cliente.Situacao = SituacaoEnum.Ativo;

                result = await base.Insert(cliente);

            }

            return result;
        }
        public async Task<ClienteDto> Alterar(int codCliente, ClienteDto cliente)
        {
            var clienteDto = await base.FindByCodigo(codCliente);
            var clienteModel = Mapper.Map<Cliente>(cliente);

            if (clienteDto != null)
            {
                await Repositorio.Replace(clienteModel.Id, clienteModel);
            }

            var result = Mapper.Map<ClienteDto>(clienteModel);

            return result;
        }

        public async Task Excluir(int codCliente)
        {
            var clienteModel = await Repositorio.FindById(codCliente);
            if (clienteModel != null)
            {
                await Repositorio.Remove(codCliente);
            }
        }

    }
}

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
            var clienteModel = Mapper.Map<Cliente>(cliente);
            var result = new ClienteDto();

            clienteModel.DataCadastro = DateTime.Now;
            clienteModel.Situacao = SituacaoEnum.Ativo;
            clienteModel = await Repositorio.Add(clienteModel);

            result = await base.FindByCodigo(clienteModel.Id);

            return result;
        }

        public async Task<ClienteDto> Alterar(int codCliente, ClienteDto cliente)
        {
            var clienteDto = await base.FindByCodigo(codCliente);
            
            if(clienteDto != null)
            {
                if (cliente.Nome != null) clienteDto.Nome = cliente.Nome;
                if (cliente.Telefone != null) clienteDto.Telefone = cliente.Telefone;
                if (cliente.Email != null) clienteDto.Email = cliente.Email;
                if (cliente.CNPJ != null) clienteDto.CNPJ = cliente.CNPJ;
                if (cliente.Situacao != clienteDto.Situacao) clienteDto.Situacao = (SituacaoEnum)cliente.Situacao;
                await base.Update(clienteDto.Codigo, clienteDto);
            }
            
            var result = await base.FindByCodigo(codCliente);

            return result;
        }

        public async Task Excluir(int codCliente)
        {
            /*
             * TODO
             * FAZER VERIFICAÇÃO SE CLIENTE ESTÁ VINCULADO A UMA LICENCA/CONTRATO ANTES DA EXCLUSÃO
             */
            var clienteModel = await Repositorio.FindById(codCliente);
            if (clienteModel != null)
            {
                await Repositorio.Remove(codCliente);
            }
        }

    }
}

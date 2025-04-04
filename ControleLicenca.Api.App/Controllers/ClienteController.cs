using ControleLicenca.Api.Services.Cadastro;
using ControleLicenca.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleLicenca.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public ClienteService ClienteService { get; set; }

        public ClienteController(ClienteService clienteService)
        {
            ClienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult>AdicionarCliente(ClienteDto cliente)
        {
            var result = await ClienteService.Adicionar(cliente);
            if (result.Codigo != 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Cliente não incluído");
            }
        }

        [HttpPut("cliente/{codCliente}")]
        public async Task<IActionResult> AlterarCliente(int codCliente, ClienteDto cliente)
        {
            var result = await ClienteService.Alterar(codCliente, cliente);
            if (result.Codigo != 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Cliente não alterado");
            }
        }

        [HttpDelete("ExcluirCliente/{codCliente}")]
        public async Task<IActionResult> RemoverCliente(int codCliente)
        {
            await ClienteService.Excluir(codCliente);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            try
            {
                var clientes = await ClienteService.All();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar Clientes, excessão: " + ex.Message);
            }
        }

        [HttpGet("cliente/{codigo}")]
        public async Task<IActionResult> ListarClientePorCodigo(int codigo)
        {
            try
            {
                var cliente = await ClienteService.FindByCodigo(codigo);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao buscar Cliente, excessão: " + ex.Message);
            }

        }
    }
}

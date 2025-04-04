using ControleLicenca.Api.Services.Cadastro;
using ControleLicenca.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ControleLicenca.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        public ContratoService ContratoService { get; set; }

        public ContratoController(ContratoService contratoService)
        {
            ContratoService = contratoService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarContrato(ContratoDto contrato)
        {
            var result = await ContratoService.Adicionar(contrato);
            if (result.Codigo != 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Contrato não incluído");
            }
        }

        [HttpPut("contrato/{codContrato}")]
        public async Task<IActionResult> AlterarContrato(int codContrato, ContratoDto contrato)
        {
            var result = await ContratoService.Alterar(codContrato, contrato);
            if(result.Codigo != 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Contrato não alterado");
            }
        }

        [HttpDelete("ExcluirContrato/{codContrato}")]
        public async Task<IActionResult> RemoverContrato(int codContrato)
        {
            await ContratoService.Excluir(codContrato);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListarContratos()
        {
            try
            {
                var contratos = await ContratoService.All();
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao listar Contratos, excessão: " + ex.Message);
            }
        }

        [HttpGet("contrato/{codigo}")]
        public async Task<IActionResult> ListarContratoPorCodigo(int codigo)
        {
            try
            {
                var contrato = await ContratoService.FindByCodigo(codigo);
                return Ok(contrato);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao buscar Contrato, excessão: " + ex.Message);
            }
        }
    }
}

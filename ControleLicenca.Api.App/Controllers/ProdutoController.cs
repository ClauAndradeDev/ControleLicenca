using ControleLicenca.Api.Services.Cadastro;
using ControleLicenca.Modelo.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleLicenca.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        public ProdutoService ProdutoService { get; set; }
        public ProdutoController(ProdutoService produtoService)
        {
            ProdutoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(ProdutoDto produto)
        {
            try
            {
                var result = await ProdutoService.Adicionar(produto);
                if (result.Codigo != 0)
                {
                    return Ok("Produto Adicionado!");
                }
                else
                {
                    return BadRequest("Produto não Adicionado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao Adicionar Produto, excessão: " + ex.Message);
            }
            
        }

        [HttpPut("produto/{codProduto}")]
        public async Task<IActionResult> AlterarProduto(int codProduto, ProdutoDto produto)
        {
            try
            {
                var result = await ProdutoService.Alterar(codProduto, produto);
                if (result.Codigo != 0)
                {
                    return Ok("Produto Alterado!");
                }
                else
                {
                    return BadRequest("Produto não Alterado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao alterar Produto, excessão: "+ ex.Message);
            }
        }

        [HttpDelete("produto/{codProduto}")]
        public async Task<IActionResult> RemoveProduto(int codProduto)
        {
            try
            {
                await ProdutoService.Excluir(codProduto);
                return Ok("Produto Excluído!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir produto, excessão: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            try
            {
                var result = await ProdutoService.All();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Listagem de produto não recuperado, excessão: " + ex.Message);
            }
        }

        [HttpGet("produto/{codProduto}")]
        public async Task<IActionResult> ListarProdutosPorCodigo(int codProduto)
        {
            try
            {
                var result = await ProdutoService.FindByCodigo(codProduto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Listagem do Produto não recuperado, excessão: " + ex.Message);
            }
        }
    }
}

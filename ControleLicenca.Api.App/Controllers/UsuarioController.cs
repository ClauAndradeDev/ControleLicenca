using ControleLicenca.Api.Services.Cadastro;
using ControleLicenca.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleLicenca.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public UsuarioService UsuarioService { get; set; }
        public UsuarioController(UsuarioService usuarioservice)
        {
            UsuarioService = usuarioservice;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(UsuarioDto usuario)
        {
            var result = await UsuarioService.Adicionar(usuario);
            if (result.Codigo != 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Usuário não incluído");
            }
        }

        [HttpPut("usuario/{codUsuario}")]
        public async Task<IActionResult>AlterarUsuario(int codUsuario, UsuarioDto usuario)
        {
            var result = await UsuarioService.Alterar(codUsuario, usuario); ;
            if (result.Codigo != 0)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Usuário não alterado");
            }
        }

        [HttpPut("{codUsuario}/alterarSenha")]
        public async Task<IActionResult> AlterarSenha(int codUsuario, UsuarioDto usuario)
        {
            var result = await UsuarioService.AlterarSenha(codUsuario, usuario);
            if (result.Codigo != 0)
            { 
                return Ok("Senha alterada!");
            }
            else
            {
                return Ok("Usuário não alterado");
            }
        }

        [HttpDelete("ExcluirUsuario/{codUsuario}")]
        public async Task<IActionResult> RemoverUsuario(int codUsuario)
        {
            await UsuarioService.Excluir(codUsuario);
            return Ok();
        }
    }
}

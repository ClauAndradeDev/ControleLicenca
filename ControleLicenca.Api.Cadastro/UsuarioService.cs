using ControleLicenca.Api.Repositorios;
using ControleLicenca.DTOs;
using ControleLicenca.Entidades;
using ControleLicenca.Extensoes;
using ControleLicenca.Modelo.Enum;


namespace ControleLicenca.Api.Services.Cadastro
{
    public class UsuarioService : CrudServices<Usuario, UsuarioDto>
    {
        public UsuarioService(UsuarioRepositorio usuarioRepositorio,
            Mapper.Mapper mapper) : base(usuarioRepositorio, mapper)
        {
        }

        public async Task<UsuarioDto> Adicionar(UsuarioDto usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            if (usuario.Senha != null)
            {
                var senhaHash = HashMD5.RetornarMD5(usuario.Senha);
                usuario.Senha = senhaHash;
            }
            usuario.Situacao = SituacaoEnum.Ativo;

            var usuarioDto = await base.Insert(usuario);
            //var usuarioModel = await base.ReturnModel(usuarioDto.Codigo);
            var result = await base.FindByCodigo(usuarioDto.Codigo);

            return result;
        }

        public async Task<UsuarioDto> Alterar(int codUsuario, UsuarioDto usuario)
        {
            var usuarioDto = await base.FindByCodigo(codUsuario);
            var usuarioModel = Mapper.Map<Usuario>(usuario);

            if (usuarioDto != null)
            {
                //await Repositorio.Replace(usuarioModel.Id, usuarioModel);
                usuarioDto.Situacao = (SituacaoEnum)usuario.Situacao;
                usuarioDto.Acesso = usuario.Acesso;
                usuarioDto.Nome = usuario.Nome;
                await base.Update(usuarioDto.Codigo, usuarioDto);
            }

            var result = await base.FindByCodigo(codUsuario);

            return result;
        }

        public async Task<UsuarioDto>AlterarSenha(int codUsuario, UsuarioDto usuario)
        {
            var usuarioDto = await base.FindByCodigo(codUsuario);
            var usuarioModel = Mapper.Map<Usuario>(usuario);
            
            if (usuario.Acesso == usuarioDto.Acesso)
            {
                var senhaRecebida = HashMD5.RetornarMD5(usuario.Senha);
                usuarioModel = await Repositorio.FindById(codUsuario);
                usuarioModel.Senha = senhaRecebida;
                if (usuarioModel.Senha != usuarioDto.Senha)
                {
                    usuarioModel.Senha = senhaRecebida;
                    await Repositorio.Replace(usuarioModel.Id, usuarioModel);
                }
            }

            var result = Mapper.Map<UsuarioDto>(usuarioModel);

            return result;
        }

        public async Task Excluir(int codUsuario)
        {
            var usuarioModel = await Repositorio.FindById(codUsuario);
            if (usuarioModel != null)
            {
                await Repositorio.Remove(codUsuario);
            }
        }


    }
}

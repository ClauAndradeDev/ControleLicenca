using ContratoLicena.Modelo.Repositorio;
using ControleLicenca.Context;
using ControleLicenca.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleLicenca.Api.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>
    {
        public UsuarioRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}

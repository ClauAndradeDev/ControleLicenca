using ContratoLicena.Modelo.Repositorio;
using ControleLicenca.Context;
using ControleLicenca.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Api.Repositorios
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>
    {
        public ProdutoRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}

using ContratoLicena.Modelo.Repositorio;
using ControleLicenca.Context;
using ControleLicenca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Api.Repositorios
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>
    {
        public ClienteRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}

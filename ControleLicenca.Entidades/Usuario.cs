using ControleLicenca.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Entidades
{
    public class Usuario: ModelCadastro
    {
        public string? Nome { get; set; }
        public string? Acesso{ get; set; }
        public string? Senha { get; set; }
    }
}

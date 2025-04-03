using ControleLicenca.Modelo;
using ControleLicenca.Modelo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.DTOs
{
    public class UsuarioDto: ModelCadastroDto
    {
        public string? Nome { get; set; }
        public string? Acesso{ get; set; }
        public string? Senha { get; set; }

    }
}

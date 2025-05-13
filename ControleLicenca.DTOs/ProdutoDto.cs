using ControleLicenca.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Modelo.DTOs
{
    public class ProdutoDto: ModelCadastroDto
    {
        public string? DescricaoSistema { get; set; }

        public virtual ICollection<LicencaDto>? Licencas { get; set; }
    }
}

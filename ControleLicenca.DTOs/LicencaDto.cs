using ControleLicenca.Modelo;
using ControleLicenca.Modelo.DTOs;
using ControleLicenca.Modelo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.DTOs
{
    public class LicencaDto: ModelMovimentacaoDto
    {
        public string? CodigoHash { get; set; }
        public SituacaoEnum? Situacao { get; set; }
        public int IdContrato { get; set; }
        public virtual ContratoDto? Contratos { get; set; }

        public int IdProduto { get; set; }
        public virtual ProdutoDto? Produtos { get; set; }
    }
}

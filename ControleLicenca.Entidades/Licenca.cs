using ControleLicenca.Modelo;
using ControleLicenca.Modelo.Entidades;
using ControleLicenca.Modelo.Enum;

namespace ControleLicenca.Entidades
{
    public class Licenca : ModelMovimentacao
    {
        public string? CodigoHash { get; set; }
        public SituacaoEnum? Situacao { get; set; }

        public int IdContrato { get; set; }
        public virtual Contrato? Contratos { get; set; }

        public int IdProduto { get; set; }
        public virtual Produto? Produtos { get; set; }

    }
}

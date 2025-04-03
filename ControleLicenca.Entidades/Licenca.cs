using ControleLicenca.Modelo;
using ControleLicenca.Modelo.Enum;

namespace ControleLicenca.Entidades
{
    public class Licenca : ModelMovimentacao
    {
        public string? CodigoHash { get; set; }

        public DateTime DataAtivacao { get; set; }
        public DateTime DataUltimaAtivacao { get; set; }
        public SituacaoEnum? Situacao { get; set; }

        public int IdCliente { get; set; }
        public virtual Cliente? Clientes { get; set; }
        public int IdContrato { get; set; }
        public virtual Contrato? Contratos { get; set; }

    }
}

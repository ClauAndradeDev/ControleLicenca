using ControleLicenca.Modelo;
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
        public HashCode CodigoHash { get; set; }
        //public int IdCliente { get; set; }
        //public int IdContrato { get; set; }
        public DateTime DataAtivacao { get; set; }
        public DateTime DataUltimaAtivacao { get; set; }
        public SituacaoEnum Situacao { get; set; }

        public virtual ClienteDto[]? Clientes { get; set; }
        public virtual ContratoDto[]? Contratos {  get; set; }
    }
}

using ControleLicenca.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.DTOs
{
    public class ContratoDto: ModelCadastroDto
    {
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public Boolean IgnoraDataFinal { get; set; }
        public decimal ValorMensal { get; set; }

        public int IdCliente { get; set; }
        public virtual ClienteDto? Clientes { get; set; }

        public virtual LicencaDto[]? Licencas { get; set; }

    }
}

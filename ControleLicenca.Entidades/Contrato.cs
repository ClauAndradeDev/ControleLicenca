using ControleLicenca.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Entidades
{
    public class Contrato: ModelCadastro
    {
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataValidade { get; set; }
        public decimal ValorMensal { get; set; }
        public int PeriodoMeses { get; set; }
        public int PeriodoAnos { get; set; }
        public decimal ValorAnual { get; set; }
        public decimal ValorContratoTotal { get; set; }

        public virtual ICollection<Licenca>? Licencas { get; set; }

    }
}

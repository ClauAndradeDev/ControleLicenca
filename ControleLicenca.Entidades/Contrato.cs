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
        public Boolean IgnoraDataFinal { get; set; }
        public decimal ValorMensal { get; set; }

        public int IdCliente { get; set; }
        public virtual Cliente? Clientes { get; set; }

        public virtual ICollection<Licenca>? Licencas { get; set; }

    }
}

using ControleLicenca.Modelo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLicenca.Modelo
{
    public class ModelCadastro: ModelBase
    {
        public DateTime DataCadastro { get; set; }
        public SituacaoEnum? Situacao { get; set; }
    }
}

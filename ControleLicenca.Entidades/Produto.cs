using ControleLicenca.Entidades;

namespace ControleLicenca.Modelo.Entidades
{
    public class Produto : ModelCadastro
    {
        public string? DescricaoSistema { get; set; }

        public virtual ICollection<Licenca>? Licencas { get; set; }
    }
}

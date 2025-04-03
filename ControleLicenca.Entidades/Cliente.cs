using ControleLicenca.Modelo;

namespace ControleLicenca.Entidades
{
    public class Cliente: ModelCadastro
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Licenca>? Licencas { get; set; }
    }
}

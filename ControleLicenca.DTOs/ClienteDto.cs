using ControleLicenca.Modelo;

namespace ControleLicenca.DTOs
{
    public class ClienteDto: ModelCadastroDto
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public string? CNPJ { get; set; }
    }
}

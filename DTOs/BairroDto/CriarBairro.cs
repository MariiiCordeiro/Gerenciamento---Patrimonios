namespace GerenciamentoPatrimonio.DTOs.BairroDto
{
    public class CriarBairro
    {
        public string NomeBairro { get; set; } = string.Empty;
        public Guid CidadeId { get; set; }
    }
}

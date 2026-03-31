namespace GerenciamentoPatrimonio.DTOs.EnderecoDto
{
    public class CriarEndereco
    {
        public string Longradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; } //Adicionar string.empty
        public Guid BairroId { get; set; }
    }
}

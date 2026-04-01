namespace GerenciamentoPatrimonio.DTOs.UsuarioDto
{
    public class CriarUsuario
    {
        public string NIF { get; set; } = null!;

        public string NomeUsuario { get; set; } = null!;

        public string? RG { get; set; }

        public string CPF { get; set; } = null!;

        public string CarteiraTrabalho { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Guid EnderecoID { get; set; }

        public Guid CargoID { get; set; }

        public Guid TipoUsuarioID { get; set; }
    }
}

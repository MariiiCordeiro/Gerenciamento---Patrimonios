namespace GerenciamentoPatrimonio.DTOs.UsuarioDto
{
    public class LerUsuario
    {
        public Guid UsuarioID { get; set; }

        public string NIF { get; set; } = string.Empty;

        public string NomeUsuario { get; set; } = string.Empty;

        public string? RG { get; set; }

        public string CPF { get; set; } = null!;

        public string CarteiraTrabalho { get; set; } = string.Empty;

        public bool? Ativo { get; set; }
        public bool PrimeiroAcesso { get; set; }

        public string Email { get; set; } = null!;

        public Guid EnderecoID { get; set; }

        public Guid CargoID { get; set; }

        public Guid TipoUsuarioID { get; set; }

    }
}

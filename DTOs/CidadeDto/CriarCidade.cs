using System.ComponentModel.DataAnnotations;

namespace GerenciamentoPatrimonio.DTOs.CidadeDto
{
    public class CriarCidade
    {
        [Required(ErrorMessage = " O nome da cidade é obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome da cidade deve ter no máximo 50 caracteres!")]
        public string NomeCidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}

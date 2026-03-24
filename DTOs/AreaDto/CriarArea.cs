using System.ComponentModel.DataAnnotations;

namespace GerenciamentoPatrimonio.DTOs.AreaDto
{
    public class CriarArea
    {
        [Required(ErrorMessage = " O nome da área é obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome da área deve ter no máximo 50 caracteres!" )]
        public string NomeArea {  get; set; } = string.Empty; //string.Empty refere-se a proibição do nulo  string? = pode ser null null! = confio no sistema e não entrara nulo
    }
}

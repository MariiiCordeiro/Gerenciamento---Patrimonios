using System.ComponentModel.DataAnnotations;

namespace GerenciamentoPatrimonio.DTOs.LocalDto
{
    public class CriarLocal
    {
        [Required(ErrorMessage = " O nome do local é obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome do local deve ter no máximo 50 caracteres!")]
        public string NomeLocal { get; set; } = string.Empty; //string.Empty refere-se a proibição do nulo  string? = pode ser null null! = confio no sistema e não entrara nulo
        public int LocalSAP { get; set; }
        public string DescricaoSAP {  get; set; }
        public Guid AreaID { get; set; }
    }
}

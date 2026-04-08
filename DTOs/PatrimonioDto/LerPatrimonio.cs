namespace GerenciamentoPatrimonio.DTOs.PatrimonioDto
{
    public class LerPatrimonio
    {
        public class PatrimonioReadDto
        {
            public Guid PatrimonioID { get; set; }
            public string Denominacao { get; set; } = string.Empty;
            public string NumeroPatrimonio { get; set; } = string.Empty;
            public decimal? Valor { get; set; }
            public string? Imagem { get; set; }

            public Guid LocalID { get; set; }
            public string NomeLocal { get; set; } = string.Empty;

            public Guid TipoPatrimonioID { get; set; }
            public string NomeTipoPatrimonio { get; set; } = string.Empty;

            public Guid StatusPatrimonioID { get; set; }
            public string NomeStatusPatrimonio { get; set; } = string.Empty;
        }
    }
}

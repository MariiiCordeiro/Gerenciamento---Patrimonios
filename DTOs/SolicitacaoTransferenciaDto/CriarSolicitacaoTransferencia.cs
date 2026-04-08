namespace GerenciamentoPatrimonio.DTOs.SolicitacaoTransferenciaDto
{
    public class CriarSolicitacaoTransferencia
    {
        public string Justificativa { get; set; } = string.Empty;
        public Guid PatrimonioID { get; set; }
        public Guid LocalID { get; set; }
    }
}

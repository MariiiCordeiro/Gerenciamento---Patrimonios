namespace GerenciamentoPatrimonio.DTOs.SolicitacaoTransferenciaDto
{
    public class LerSolicitacaoTransferencia
    {
        public string Justificativa { get; set; } = string.Empty;
        public Guid TransferenciaID { get; set; }
        public Guid StatusTransferenciaID { get; set; }
        public Guid UsuarioIDSolicitacao {  get; set; }
        public Guid UsuarioIDAprovacao {  get; set; }
        public Guid PatrimonioID { get; set; }
        public Guid LocalID {  get; set; }
        public DateTime DataCriacaoSolicitante { get; set; }
        public DateTime? DataResposta { get; set; }

    }
}

using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ISolicitacaoTransferenciaRepository
    {
        List<SolicitacaoTransferencia> Listar();
        SolicitacaoTransferencia BuscarPorId(Guid transferenciaId);
        bool ExisteSolicitacaoPendente(Guid patrimonioId);
        bool UsuarioResponsavelDoLocal(Guid usuarioId, Guid locald);

        StatusTransferencia BuscarStatusTransferenciaPendente(string status);

        void Adicionar(SolicitacaoTransferencia solicitacaoTransferencia);

        bool LocalExiste(Guid localId);
        Patrimonio BuscarPatrimonioPorID(Guid patrimonioId) ;
    }
}

using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositories
{
    public class SolicitacaoTransferenciaRepository : ISolicitacaoTransferenciaRepository
    {
        private readonly GerenciamentoPatrimoniosContext _context;

        public SolicitacaoTransferenciaRepository(GerenciamentoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<SolicitacaoTransferencia> Listar()
        {
            return _context.SolicitacaoTransferencia.OrderByDescending(solicitacaoTransferencia => solicitacaoTransferencia.DataCriacaoSolicitante).ToList();
        }

        public SolicitacaoTransferencia BuscarPorId(Guid transferenciaId)
        {
            return _context.SolicitacaoTransferencia.Find(transferenciaId);
        }

        public StatusTransferencia BuscarStatusTransferenciaPendente(string status)
        {
            return _context.SolicitacaoTransferencia.FirstOrDefault(statusTransferencia => statusTransferencia.Status.ToLower() == status.ToLower());
        }

        public bool ExisteSolicitacaoPendente(Guid patrimonioId)
        {
            StatusTransferencia statusPendente = BuscarStatusTransferenciaPendente("Pendente de aprovação!");

            if(statusPendente == null)
            {
                return false;
            }

            return _context.SolicitacaoTransferencia.Any(solicitacao => solicitacao.PatrimonioID == patrimonioId && solicitacao.StatusTransferenciaID == statusPendente.StatusTransferenciaID);
        }

        public bool UsuarioResponsavelDoLocal(Guid usuarioId, Guid localId)
        {
            return _context.Usuario.Any(usuario => usuario.UsuarioID == usuarioId && usuario.Local.Any(local => local.LocalID == localId));
        }

        public void Adicionar(SolicitacaoTransferencia solicitacaoTransferencia)
        {
            _context.SolicitacaoTransferencia.Add(solicitacaoTransferencia);
            _context.SaveChanges();
        }

        public bool LocalExiste(Guid localId)
        {
            return _context.Local.Any(local => local.LocalID == localId);
        }

        public bool BuscarPatrimonioPorId(Guid patrimonioId)
        {
            return _context.Patrimonio.Find(patrimonioId);
        }
    }
}

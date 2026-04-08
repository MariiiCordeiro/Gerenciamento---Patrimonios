using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.SolicitacaoTransferenciaDto;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class SolicitacaoTransferenciaService
    {
        private readonly ISolicitacaoTransferenciaRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;

        public SolicitacaoTransferenciaService(ISolicitacaoTransferenciaRepository repository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public List<LerSolicitacaoTransferencia> Listar()
        {
            List<SolicitacaoTransferencia> solicitacoes = _repository.Listar();

            List<LerSolicitacaoTransferencia> solicitacaoDto = solicitacoes.Select(solicitacao => new LerSolicitacaoTransferencia
            {
                TransferenciaID = solicitacao.TransferenciaID,
                DataCriacaoSolicitante = solicitacao.DataCriacaoSolicitante,
                DataResposta = solicitacao.DataResposta,
                Justificativa = solicitacao.Justificativa,
                StatusTransferenciaID = solicitacao.StatusTransferenciaID,
                UsuarioIDSolicitacao = solicitacao.UsuarioIDSolicitante,
                UsuarioIDAprovacao = solicitacao.UsuarioIDAprovacao,
                PatrimonioID = solicitacao.PatrimonioID,
                LocalID = solicitacao.LocalID
            }).ToList();

            return solicitacaoDto;
        }

        public LerSolicitacaoTransferencia BuscarPorId(Guid transferenciaId)
        {
            SolicitacaoTransferencia solicitacao = _repository.BuscarPorId(transferenciaId);

            if(solicitacao == null)
            {
                throw new DomainException("Solicitação de transferência nao encontrada!");
            }

            LerSolicitacaoTransferencia solicitacaoDto = new LerSolicitacaoTransferencia
            {
                TransferenciaID = solicitacao.TransferenciaID,
                DataCriacaoSolicitante = solicitacao.DataCriacaoSolicitante,
                DataResposta = solicitacao.DataResposta,
                Justificativa = solicitacao.Justificativa,
                StatusTransferenciaID = solicitacao.StatusTransferenciaID,
                UsuarioIDSolicitacao = solicitacao.UsuarioIDSolicitante,
                UsuarioIDAprovacao = solicitacao.UsuarioIDAprovacao,
                PatrimonioID = solicitacao.PatrimonioID,
                LocalID = solicitacao.LocalID
            };

            return solicitacaoDto;
        }
    }
}

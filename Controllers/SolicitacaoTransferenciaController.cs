using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.SolicitacaoTransferenciaDto;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoTransferenciaController : ControllerBase
    {
        private readonly SolicitacaoTransferenciaService _service;

        public SolicitacaoTransferenciaController(SolicitacaoTransferenciaService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<LerSolicitacaoTransferencia>> Listar()
        {
            List<LerSolicitacaoTransferencia> solicitacoes = _service.Listar();
            return Ok(solicitacoes);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<LerSolicitacaoTransferencia> BuscarPorId(Guid id)
        {
            try
            {
                LerSolicitacaoTransferencia solicitacao = _service.BuscarPorId(id);
                return Ok(solicitacao);
            }
            catch(DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

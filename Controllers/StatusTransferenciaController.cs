using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.StatusTransferenciaDto;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTransferenciaController : ControllerBase
    {
        private readonly StatusTransferenciaService _service;

        public StatusTransferenciaController(StatusTransferenciaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerStatusTransferencia>> Listar()
        {
            List<LerStatusTransferencia> statusDto = _service.Listar();
            return Ok(statusDto);
        }

        [HttpGet("{id}")]
        public ActionResult<LerStatusTransferencia> BuscarPorId(Guid id)
        {
            try
            {
                LerStatusTransferencia statusTransferenciaDto = _service.BuscarPorId(id);
                return Ok(statusTransferenciaDto);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarStatusTransferencia dto)
        {
            try
            {
                _service.Adicionar(dto);
                return Created();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, CriarStatusTransferencia dto)
        {
            try
            {
                _service.Atualizar(id, dto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

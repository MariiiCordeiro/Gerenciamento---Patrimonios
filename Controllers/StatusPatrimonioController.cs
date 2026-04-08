using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.StatusPatrimonioDto;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPatrimonioController : ControllerBase
    {
        private readonly StatusPatrimonioService _service;

        public StatusPatrimonioController(StatusPatrimonioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerStatusPatrimonio>> Listar()
        {
            List<LerStatusPatrimonio> statusDto = _service.Listar();
            return Ok(statusDto);
        }

        [HttpGet("{id}")]
        public ActionResult<LerStatusPatrimonio> BuscarPorId(Guid id)
        {
            try
            {
                LerStatusPatrimonio status = _service.BuscarPorId(id);
                return Ok(status);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarStatusPatrimonio dto)
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
        public ActionResult Atualizar(Guid id, CriarStatusPatrimonio dto)
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

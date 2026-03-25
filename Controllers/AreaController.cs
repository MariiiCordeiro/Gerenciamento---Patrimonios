using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.AreaDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalGames.Exceptions;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AreaService _service;

        public AreaController(AreaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerArea>> Listar()
        {
            List<LerArea> areas = _service.Listar();

            return Ok(areas);
        }

        [HttpGet("{id}")]
        public ActionResult<LerArea> BuscarPorId(Guid id)
        {
            try
            {
                LerArea area = _service.BuscarPorId(id);
                return Ok(area);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Adicionar(CriarArea dto)
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
        public ActionResult Atualizar(Guid id, CriarArea dto)
        {
            try
            {
                _service.Atualiar(id, dto);
                return Ok();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}

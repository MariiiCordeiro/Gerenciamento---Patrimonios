using GerenciamentoPatrimonio.Aplications;
using GerenciamentoPatrimonio.DTOs.AreaDto;
using GerenciamentoPatrimonio.DTOs.LocalDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalGames.Exceptions;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {

        private readonly LocalService _service;

        public LocalController(LocalService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerLocal>> Listar()
        {
            List<LerLocal> locais = _service.Listar();

            return Ok(locais);
        }

        [HttpGet("{id}")]

        public ActionResult<LerLocal> BuscarPorId(Guid id)
        {
            try
            {
                LerLocal local = _service.BuscarPorId(id);
                return Ok(local);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarLocal dto)
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
        public ActionResult Atualizar(Guid id, CriarLocal dto)
        {
            try
            {
                _service.Atualizar(id, dto);
                return NoContent();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

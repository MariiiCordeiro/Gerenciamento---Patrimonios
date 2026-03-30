using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.CidadeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoPatrimonio.Exceptions;


namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly CidadeService _service;

        public CidadeController(CidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerCidade>> Listar()
        {
            List<LerCidade> cidade = _service.Listar();
            return Ok(cidade);
        }

        [HttpGet("{id}")]
        public ActionResult<LerCidade> BuscarPorId(Guid id)
        {
            try
            {
                LerCidade cidade = _service.BuscarPorId(id);
                return Ok(cidade);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarCidade dto)
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
        public ActionResult Atualizar(Guid id, CriarCidade dto)
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

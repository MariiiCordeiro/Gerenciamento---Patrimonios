using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.TipoUsuarioDto;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly TipoUsuarioService _service;

        public TipoUsuarioController(TipoUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerTipoUsuario>> Listar()
        {
            List<LerTipoUsuario> tipos = _service.Listar();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerTipoUsuario> BuscarPorId(Guid id)
        {
            try
            {
                LerTipoUsuario tipoUsuario = _service.BuscarPorId(id);
                return Ok(tipoUsuario);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarTipoUsuario dto)
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
        public ActionResult Atualizar(Guid id, CriarTipoUsuario dto)
        {
            try
            {
                _service.Atualizar(id, dto);
                return Ok();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.EnderecoDto;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerEndereco>> Listar()
        {
            List<LerEndereco> endereco = _service.Listar();
            return Ok(endereco);
        }

        [HttpGet("{id}")]
        public ActionResult<LerEndereco> BuscarPorID(Guid id)
        {
            try
            {
                LerEndereco endereco = _service.BuscarPorId(id);
                return Ok(endereco);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

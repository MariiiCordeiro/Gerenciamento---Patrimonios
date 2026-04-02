using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.DTOs.BairroDto;
using GerenciamentoPatrimonio.DTOs.CargoDto;
using GerenciamentoPatrimonio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoPatrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly CargoService _service;

        public CargoController(CargoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerCargo>> Listar()
        {
            List<LerCargo> cargos = _service.Listar();
            return cargos;
        }

        [HttpGet("{id}")]
        public ActionResult<LerCargo> BuscarPorId(Guid id)
        {
            try
            {
                LerCargo cargo = _service.BuscarPorId(id);
                return Ok(cargo);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adiconar(CriarCargo dto)
        {
            try
            {
                _service.Adicionar(dto);
                return Created();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, CriarCargo dto)
        {
            try
            {
                _service.Atualizar(id, dto);
                return Ok();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

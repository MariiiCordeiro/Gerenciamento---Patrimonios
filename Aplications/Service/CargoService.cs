using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.CargoDto;
using GerenciamentoPatrimonio.DTOs.EnderecoDto;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Aplications.Regras;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class CargoService
    {
        private readonly ICargoRepository _repository;

        public CargoService(ICargoRepository repository)
        {
            _repository = repository;   
        }

        public List<LerCargo> Listar()
        {
            List<Cargo> cargos = _repository.Listar();

            List<LerCargo> cargoDto = cargos.Select(cargo => new LerCargo
            {
                CargoID = cargo.CargoID,
                NomeCargo = cargo.NomeCargo
            }).ToList();

            return cargoDto;
        }

        public LerCargo BuscarPorId(Guid id)
        {
            Cargo cargo = _repository.BuscarPorId(id);

            if(cargo == null)
            {
                throw new DomainException("Crago não enocntrado!");
            }

            LerCargo cargoDto = new LerCargo
            {
                CargoID = cargo.CargoID,
                NomeCargo = cargo.NomeCargo
            };

            return cargoDto;
        }


        public void Adicionar(CriarCargo dto)
        {
            Validar.ValidarNome(dto.NomeCargo);

            Cargo cargoExistente = _repository.BuscarPorNome(dto.NomeCargo);

            if(cargoExistente != null)
            {
                throw new DomainException("Já existe um cargo cadastrado com esse nome.");
            }

            Cargo cargo = new Cargo
            {
                NomeCargo = dto.NomeCargo
            };

            _repository.Adicionar(cargo);
        }


        public void Atualizar(Guid cargoId, CriarCargo dto)
        {
            Validar.ValidarNome(dto.NomeCargo);

            Cargo cargoBanco = _repository.BuscarPorId(cargoId);

            if(cargoBanco == null)
            {
                throw new DomainException("Cargo não encontado!");
            }

            Cargo cargoExistente = _repository.BuscarPorNome(dto.NomeCargo);

            if( cargoExistente != null)
            {
                throw new DomainException("Já existe um cargo cadastrado com esse nome!");
            }

            cargoBanco.NomeCargo = dto.NomeCargo;

            _repository.Atualizar(cargoBanco);
        }
    }
}

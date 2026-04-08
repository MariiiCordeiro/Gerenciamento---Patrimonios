using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.StatusPatrimonioDto;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class StatusPatrimonioService
    {
        private readonly IStatusPatrimonioRepository _repository;

        public StatusPatrimonioService(IStatusPatrimonioRepository repository)
        {
            _repository = repository;
        }

        public List<LerStatusPatrimonio> Listar()
        {
            List<StatusPatrimonio> statusPatrimonios = _repository.Listar();
            List<LerStatusPatrimonio> statusPatrimonioDto = statusPatrimonios.Select(statusPatrimonio => new LerStatusPatrimonio
            {
                StatusPatrimonioId = statusPatrimonio.StatusPatrimonioID,
                Status = statusPatrimonio.Status
            }).ToList();

            return statusPatrimonioDto;
        }

        public LerStatusPatrimonio BuscarPorId(Guid id)
        {
            StatusPatrimonio statusPatrimonio = _repository.BuscarPorId(id);

            return new LerStatusPatrimonio
            {
                StatusPatrimonioId = statusPatrimonio.StatusPatrimonioID,
                Status = statusPatrimonio.Status
            };
        }

        public void Adicionar(CriarStatusPatrimonio dto)
        {
            Validar.ValidarNome(dto.Status);
            StatusPatrimonio statusExistente = _repository.BuscarPorNome(dto.Status);

            if (statusExistente != null)
            {
                throw new DomainException("Já existe um Status de Patrimônio com esse nome.");
            }

            StatusPatrimonio status = new StatusPatrimonio
            {
                Status = dto.Status
            };

            _repository.Adicionar(status);
        }

        public void Atualizar(Guid id, CriarStatusPatrimonio dto)
        {
            Validar.ValidarNome(dto.Status);
            StatusPatrimonio statusExistente = _repository.BuscarPorNome(dto.Status);

            if (statusExistente != null)
            {
                throw new DomainException("Já existe um Status de Patrimônio com esse nome.");
            }

            StatusPatrimonio statusBanco = _repository.BuscarPorId(id);

            if (statusBanco == null)
            {
                throw new DomainException("Status de Patrimônio não encontado.");
            }

            statusBanco.Status = dto.Status;

            _repository.Atualizar(statusBanco);
        }
    }
}

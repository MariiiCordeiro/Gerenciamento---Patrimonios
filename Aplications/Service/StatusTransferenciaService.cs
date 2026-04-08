using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.StatusTransferenciaDto;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class StatusTransferenciaService
    {
        private readonly IStatusTransferenciaRepository _repository;

        public StatusTransferenciaService(IStatusTransferenciaRepository repository)
        {
            _repository = repository;
        }

        public List<LerStatusTransferencia> Listar()
        {
            List<StatusTransferencia> statusTransferencias = _repository.Listar();
            List<LerStatusTransferencia> statusTransferenciaDto = statusTransferencias.Select(statusTransferencia => new LerStatusTransferencia
            {
                StatusTransferenciaId = statusTransferencia.StatusTransferenciaID,
                Status = statusTransferencia.Status
            }).ToList();

            return statusTransferenciaDto;
        }

        public LerStatusTransferencia BuscarPorId(Guid id)
        {
            StatusTransferencia statusTransferencia = _repository.BuscarPorId(id);

            return new LerStatusTransferencia
            {
                StatusTransferenciaId = statusTransferencia.StatusTransferenciaID,
                Status = statusTransferencia.Status
            };
        }

        public void Adicionar(CriarStatusTransferencia dto)
        {
            Validar.ValidarNome(dto.Status);
            StatusTransferencia statusExistente = _repository.BuscarPorNome(dto.Status);

            if (statusExistente != null)
            {
                throw new DomainException("Já existe um Status de Transferência com esse nome.");
            }

            StatusTransferencia statusT = new StatusTransferencia
            {
                Status = dto.Status
            };

            _repository.Adicionar(statusT);
        }

        public void Atualizar(Guid id, CriarStatusTransferencia dto)
        {
            Validar.ValidarNome(dto.Status);
            StatusTransferencia statusExistente = _repository.BuscarPorNome(dto.Status);

            if (statusExistente != null)
            {
                throw new DomainException("Já existe um Status de Transferência com esse nome.");
            }

            StatusTransferencia statusBanco = _repository.BuscarPorId(id);

            if (statusBanco == null)
            {
                throw new DomainException("Status de Transferência não encontrado.");
            }

            statusBanco.Status = dto.Status;

            _repository.Adicionar(statusBanco);
        }
    }
}


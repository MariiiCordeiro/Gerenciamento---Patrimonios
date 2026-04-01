using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.CidadeDto;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Exceptions;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class CidadeService
    {
        private readonly ICidadeRepository _repository;

        public CidadeService(ICidadeRepository repository)
        {
            _repository = repository;
        }

        public List<LerCidade> Listar()
        {
            List<Cidade> cidades = _repository.Listar();

            List<LerCidade> cidadeDto = cidades.Select(cidade => new LerCidade
            {
                CidadeID = cidade.CidadeID,
                NomeCidade = cidade.NomeCidade,
                Estado = cidade.Estado
            }).ToList();

            return cidadeDto;
        }

        public LerCidade BuscarPorId(Guid cidadeId)
        {
            Cidade cidade = _repository.BuscarPorId(cidadeId);

            if(cidade == null)
            {
                throw new DomainException("Cidade não encontrada!");
            }

            LerCidade cidadeDto = new LerCidade
            {
                CidadeID = cidade.CidadeID,
                NomeCidade = cidade.NomeCidade
            };
            return cidadeDto;
        }

        public void Adicionar(CriarCidade dto)
        {
            Validar.ValidarNome(dto.NomeCidade);
            Cidade cidadeExistente = _repository.BuscarPorNomeEEstado(dto.NomeCidade, dto.Estado);

            if(cidadeExistente != null)
            {
                throw new DomainException("Já existe uma cidade com esse nome!");
            }

            Cidade cidade = new Cidade
            {
                NomeCidade = dto.NomeCidade,
                Estado = dto.Estado
            };
            _repository.Adicionar(cidade);
        }

        public void Atualizar(Guid cidadeId, CriarCidade dto)
        {
            Validar.ValidarNome(dto.NomeCidade);
            Cidade cidadeBanco = _repository.BuscarPorId(cidadeId);

            if(cidadeBanco == null)
            {
                throw new DomainException("Cidade não encontrada!");
            }

            Cidade cidadeExistente = _repository.BuscarPorNomeEEstado(dto.NomeCidade, dto.Estado);

            if( cidadeExistente != null)
            {
                throw new DomainException("Já existe uma área cadastrada com esse nome");
            }

            cidadeBanco.NomeCidade = dto.NomeCidade;
            cidadeBanco.Estado = dto.Estado;

            _repository.Atualizar(cidadeBanco);
        }
    }
}

using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.AreaDto;
using GerenciamentoPatrimonio.DTOs.LocalDto;
using GerenciamentoPatrimonio.Interfaces;
using RoyalGames.Exceptions;

namespace GerenciamentoPatrimonio.Aplications
{
    public class LocalService
    {
        private readonly ILocalRepository _repository;

        public LocalService (ILocalRepository repository)
        {
            _repository = repository;
        }

        public List<LerLocal> Listar()
        {
            List<Local> locais = _repository.Listar();

            List<LerLocal> localDto = locais.Select(local => new LerLocal
            {
                LocalID = local.LocalID,
                NomeLocal = local.NomeLocal,
                LocalSAP = local.LocalSAP,
                DescricaoSAP = local.DescricaoSAP,
                AreaID = local.AreaID
            }).ToList();

            return localDto;
        }

        public LerLocal BuscarPorId(Guid localId)
        {
            Local local = _repository.BuscarPorId(localId);

            if(local == null)
            {
                throw new DomainException("Local não encontrado!");
            }

            return new LerLocal
            {
                LocalID = local.LocalID,
                NomeLocal = local.NomeLocal,
                LocalSAP = local.LocalSAP,
                DescricaoSAP = local.DescricaoSAP,
                AreaID = local.AreaID
            };
        }

        public void Adicionar(CriarLocal dto)
        {
            Validar.ValidarNome(dto.NomeLocal);

            if (!_repository.AreaExiste(dto.AreaID))
            {
                throw new DomainException("Área informada não existe!");
            }

            Local local = new Local
            {
                NomeLocal = dto.NomeLocal,
                LocalSAP = dto.LocalSAP,
                DescricaoSAP = dto.DescricaoSAP,
                AreaID = dto.AreaID
            };

             _repository.Adicionar(local);
        }

        public void Atualizar(Guid localId, CriarLocal dto)
        {
            Validar.ValidarNome(dto.NomeLocal);

            Local localBanco = _repository.BuscarPorId(localId);

            if(localBanco == null)
            {
                throw new DomainException("Local não encontrao!");
            }

            if (!_repository.AreaExiste(dto.AreaID))
            {
                throw new DomainException("Área não existe!");
            }

            localBanco.NomeLocal = dto.NomeLocal;
            localBanco.LocalSAP = dto.LocalSAP;
            localBanco.DescricaoSAP = dto.DescricaoSAP;
            localBanco.AreaID = dto.AreaID;

            _repository.Atualizar(localBanco);
        }
    }
}

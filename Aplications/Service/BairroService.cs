using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.BairroDto;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class BairroService
    {
        private readonly IBairroRepository _repository;

        public BairroService(IBairroRepository repository)
        {
            _repository = repository; 
        }

        public List<LerBairro> Listar()
        {
            List<Bairro> bairros = _repository.Listar();
            List<LerBairro> bairroDto = bairros.Select(bairro => new LerBairro
            {
                BairroId = bairro.BairroID,
                NomeBairro = bairro.NomeBairro,
                CidadeId = bairro.CidadeID,
            }).ToList();

            return bairroDto;
        }

        public LerBairro BuscarPorId(Guid bairroId)
        {
            Bairro bairro = _repository.BuscarPorId(bairroId);

            if (bairro == null)
            {
                throw new DomainException("Bairro não encontrado!");
            }
            LerBairro bairroDto = new LerBairro
            {
                BairroId = bairro.BairroID,
                NomeBairro = bairro.NomeBairro,
                CidadeId = bairro.CidadeID
            };

            return bairroDto;
        }

        public void Adicionar(CriarBairro dto)
        {
            Validar.ValidarNome(dto.NomeBairro);     //metodo da regra validar, irá validar se o nomeque está entrando esta vazio
            Bairro bairroExistente = _repository.BuscarPorNome(dto.NomeBairro, dto.CidadeId);

            if (bairroExistente != null)
            {
                throw new DomainException("Já existe um bairro com esse nome!");
            }

            if (!_repository.CidadeExiste(dto.CidadeId))
            {
                throw new DomainException("Cidade não existe!");
            }

            Bairro bairro = new Bairro
            {
                // areaid = guid.newguid caso não houvesse a geração a!utomática no banco, portanto será só o nome que sera passado aqui.
                NomeBairro = dto.NomeBairro,
                CidadeID = dto.CidadeId
            };

            _repository.Adicionar(bairro);
        }

        public void Atualizar(Guid bairroId, CriarBairro dto)
        {
            Validar.ValidarNome(dto.NomeBairro);
            Bairro bairroBanco = _repository.BuscarPorId(bairroId);

            if(bairroBanco == null)
            {
                throw new DomainException("Bairro não encontrado!");
            }

            Bairro bairroExistente = _repository.BuscarPorNome(dto.NomeBairro, dto.CidadeId);

            if(bairroExistente != null)
            {
                throw new DomainException("Já existe um bairro cadastrado com esse nome!");
            }

            bairroBanco.NomeBairro = dto.NomeBairro;
            bairroBanco.CidadeID = dto.CidadeId;

            _repository.Atualizar(bairroBanco);
        }
    }
}

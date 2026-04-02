using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.EnderecoDto;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Aplications.Regras;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class EnderecoService
    {
        private readonly lEnderecoRepository _repository;

        public EnderecoService(lEnderecoRepository repository)
        {
            _repository = repository;
        }

        public List<LerEndereco> Listar()
        {
            List<Endereco> enderecos = _repository.Listar();
            List<LerEndereco> enderecoDto = enderecos.Select(endereco => new LerEndereco
            {
                EnderecoId = endereco.EnderecoID,
                Longradouro = endereco.Longradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                CEP = endereco.CEP,
                BairroId = endereco.BairroID
            }).ToList();

            return enderecoDto;
        }

        public LerEndereco BuscarPorId(Guid enderecoId)
        {
            Endereco endereco = _repository.BuscarPorId(enderecoId);

            if (endereco == null)
            {
                throw new DomainException("Endereço não encontrado!");
            }

            return new LerEndereco
            {
                EnderecoId = endereco.EnderecoID,
                Longradouro = endereco.Longradouro,
                Complemento = endereco.Complemento,
                CEP = endereco.CEP,
                BairroId = endereco.BairroID
            };
        }

        public void Adicionar(CriarEndereco dto)
        {
            Validar.ValidarNome(dto.Longradouro);

            Endereco enderecoExistente = _repository.BuscarPorLongradouroENumero(dto.Longradouro, dto.Numero, dto.BairroId);

            if (enderecoExistente != null)
            {
                throw new DomainException("Já existe um endereço cadastrado com esse nome nesse bairro");
            }

            if (!_repository.BairroExiste(dto.BairroId))
            {
                throw new DomainException("Bairro informado não existe!");
            }

            Endereco endereco = new Endereco
            {
                Longradouro = dto.Longradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                CEP = dto.CEP,
                BairroID = dto.BairroId
            };

            _repository.Adicionar(endereco);
        }

        public void Atualizar(Guid enderecoId, CriarEndereco dto)
        {
            Validar.ValidarNome(dto.Longradouro);

            Endereco enderecoExistente = _repository.BuscarPorLongradouroENumero(dto.Longradouro, dto.Numero, dto.BairroId);

            if (enderecoExistente != null)
            {
                throw new DomainException("Já existe um endereço cadastrado com esse nome nome nesse bairro");
            }

            Endereco enderecoBanco = _repository.BuscarPorId(enderecoId);

            if (enderecoBanco == null)
            {
                throw new DomainException("Endereco não encontrado!");
            }

            if (!_repository.BairroExiste(dto.BairroId))
            {
                throw new DomainException("Bairro não existe!");
            }

            enderecoBanco.Longradouro = dto.Longradouro;
            enderecoBanco.Numero = dto.Numero;
            enderecoBanco.Complemento = dto.Complemento;
            enderecoBanco.CEP = dto.CEP;
            enderecoBanco.BairroID = dto.BairroId;

            _repository.Atualizar(enderecoBanco);
        }
    }
}

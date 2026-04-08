using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.TipoUsuarioDto;
using GerenciamentoPatrimonio.Exceptions;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class TipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _repository;

        public TipoUsuarioService(ITipoUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<LerTipoUsuario> Listar()
        {
            List<TipoUsuario> tipoUsuarios = _repository.Listar();

            List<LerTipoUsuario> tipoUsuarioDto = tipoUsuarios.Select(tipoUsuario => new LerTipoUsuario
            {
                TipoUsuarioId = tipoUsuario.TipoUsuarioID,
                NomeTipo = tipoUsuario.NomeTipo
            }).ToList();

            return tipoUsuarioDto;
        }

        public LerTipoUsuario BuscarPorId(Guid id)
        {
            TipoUsuario tipoUsuario = _repository.BuscarPorId(id);

            if (tipoUsuario == null)
            {
                throw new DomainException("Tipo de Usuário não encontrado.");
            }

            return new LerTipoUsuario
            {
                TipoUsuarioId = tipoUsuario.TipoUsuarioID,
                NomeTipo = tipoUsuario.NomeTipo
            };
        }

        public void Adicionar(CriarTipoUsuario dto)
        {
            Validar.ValidarNome(dto.NomeTipo);

            TipoUsuario tipoUsuarioExistente = _repository.BuscarPorNome(dto.NomeTipo);

            if (tipoUsuarioExistente != null)
            {
                throw new DomainException("Já existe um tipo de usuário com este nome.");
            }

            TipoUsuario tipoUsuario = new TipoUsuario
            {
                NomeTipo = dto.NomeTipo
            };

            _repository.Adicionar(tipoUsuario);
        }

        public void Atualizar(Guid id, CriarTipoUsuario dto)
        {
            Validar.ValidarNome(dto.NomeTipo);

            TipoUsuario tipoUsuarioExistente = _repository.BuscarPorNome(dto.NomeTipo);

            TipoUsuario tipoUsuarioBanco = _repository.BuscarPorId(id);

            if (tipoUsuarioBanco == null)
            {
                throw new DomainException("Tipo de usuário não encontrado.");
            }

            if (tipoUsuarioExistente != null)
            {
                throw new DomainException("Já existe um tipo de usuário com este nome.");
            }

            tipoUsuarioBanco.NomeTipo = dto.NomeTipo;

            _repository.Atualizar(tipoUsuarioBanco);
        }
    }
}


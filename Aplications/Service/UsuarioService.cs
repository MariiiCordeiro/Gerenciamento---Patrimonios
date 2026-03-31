using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.UsuarioDto;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Repositories;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<LerUsuario> Listar()
        {
            List<Usuario> usuarios = _repository.Listar();

            List<LerUsuario> usuarioDto = usuarios.Select(usuario => new LerUsuario
            {
                UsuarioID = usuario.UsuarioID,
                NIF = usuario.NIF,
                NomeUsuario = usuario.NomeUsuario,
                RG = usuario.RG,
                CPF = usuario.CPF,
                CarteiraTrabalho = usuario.CarteiraTrabalho,
                Email = usuario.Email,
                Ativo = usuario.Ativo,
                PrimeiroAcesso = usuario.PrimeiroAcesso,
                EnderecoID = usuario.EnderecoID,
                CargoID = usuario.CargoID,
                TipoUsuarioID = usuario.TipoUsuarioID
            }).ToList();
        }
    }
}

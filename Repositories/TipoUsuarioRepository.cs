using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.TipoUsuarioDto;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly GerenciamentoPatrimoniosContext _context;

        public TipoUsuarioRepository(GerenciamentoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuario.OrderBy(tipoUsuario => tipoUsuario.NomeTipo).ToList();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _context.TipoUsuario.Find(id);
        }

        public TipoUsuario BuscarPorNome(string nome)
        {
            return _context.TipoUsuario.FirstOrDefault(tipoUsuario => tipoUsuario.NomeTipo == nome);
        }

        public void Adicionar(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuario.Add(tipoUsuario);
            _context.SaveChanges();
        }

        public void Atualizar(TipoUsuario tipoUsuario)
        {
            if (tipoUsuario == null)
            {
                return;
            }

            TipoUsuario tipoUsuarioBanco = _context.TipoUsuario.Find(tipoUsuario.TipoUsuarioID);

            if (tipoUsuarioBanco == null)
            {
                return;
            }

            tipoUsuarioBanco.NomeTipo = tipoUsuario.NomeTipo;

            _context.SaveChanges();
        }
    }
}


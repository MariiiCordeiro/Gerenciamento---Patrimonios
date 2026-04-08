//using GerenciamentoPatrimonio.Contexts;
//using GerenciamentoPatrimonio.Domains;
//using GerenciamentoPatrimonio.DTOs.TipoUsuarioDto;
//using GerenciamentoPatrimonio.Interfaces;

//namespace GerenciamentoPatrimonio.Repositories
//{
//    public class TipoUsuarioRepository : ITipoUsuarioRepository
//    {
//        private readonly GerenciamentoPatrimoniosContext _context;

//        public TipoUsuarioRepository(GerenciamentoPatrimoniosContext context)
//        {
//            _context = context;
//        }
//        public List<LerTipoUsuario> Listar()
//        {
//            return _context.TipoUsuario.OrderBy(tipoUsuario => tipoUsuario.NomeTipo).ToList();
//        }
//    }
//}

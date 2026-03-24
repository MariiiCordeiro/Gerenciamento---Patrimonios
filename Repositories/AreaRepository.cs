using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly GerenciamentoPatrimoniosContext _context;

        public AreaRepository(GerenciamentoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Area> Listar() // como ira listar algo precia ter um retorno de consulta no banco atraves da context 
        {
            return _context.Area.OrderBy(area => area.NomeArea).ToList();
        }
    }
}

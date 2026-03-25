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

        public Area BuscarPorId(Guid areaId)
        {
            return _context.Area.Find(areaId);
        }

        public Area BuscarPorNome(string areaNome)
        {
            return _context.Area.FirstOrDefault(area => area.NomeArea.ToLower() == areaNome.ToLower());
        }
       
        public void Adicionar(Area area)
        {
            _context.Area.Add(area); // Adicionar a area
            _context.SaveChanges();  // Salva as alterações feitas
        }

        public void Atualizar(Area area)
        {
            if(area == null)
            {
                return;
            }

            Area areaBanco = _context.Area.Find(area.AreaID); // deu tudo certo ira buscar  aarea no banco pelo id para atualização

            areaBanco.NomeArea = area.NomeArea;
            _context.SaveChanges();
        }
    }
}

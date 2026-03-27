using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.AreaDto;
using GerenciamentoPatrimonio.DTOs.LocalDto;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly GerenciamentoPatrimoniosContext _context;

        public LocalRepository(GerenciamentoPatrimoniosContext context)
        {
            _context = context; 
        }

        public List<Local> Listar()
        {
            return _context.Local.OrderBy(local => local.NomeLocal).ToList();
        }

        public Local BuscarPorId(Guid localId)
        {
            return _context.Local.Find(localId);
        }

        public void Adicionar(Local local)
        {
            _context.Local.Add(local);
            _context.SaveChanges();
        }
        
        public bool AreaExiste(Guid areaId)
        {
            return _context.Area.Any(area => area.AreaID == areaId);
        }

        public void Atualizar(Local local)
        {
            if(local == null)
            {
                return;
            }

            Local localBanco = _context.Local.Find(local.LocalID);

            if(localBanco == null)
            {
                return;
            }

            localBanco.NomeLocal = local.NomeLocal;
            localBanco.LocalSAP = local.LocalSAP;
            localBanco.DescricaoSAP = local.DescricaoSAP;
            localBanco.AreaID = local.AreaID;

            _context.SaveChanges();
        }

        public Local BuscarPorNome(string NomeLocal, Guid areaId)
        {
            return _context.Local.FirstOrDefault(local => local.NomeLocal.ToLower() == NomeLocal.ToLower() && local.AreaID == areaId);
        }
        
    }
}

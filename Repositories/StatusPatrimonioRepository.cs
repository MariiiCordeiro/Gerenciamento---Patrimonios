using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositories
{
    public class StatusPatrimonioRepository : IStatusPatrimonioRepository
    {
     
            private readonly GerenciamentoPatrimoniosContext _context;

            public StatusPatrimonioRepository(GerenciamentoPatrimoniosContext context)
            {
                _context = context;
            }

            public List<StatusPatrimonio> Listar()
            {
                return _context.StatusPatrimonio.OrderBy(statusPatrimonio => statusPatrimonio.Status).ToList();
            }

            public StatusPatrimonio BuscarPorId(Guid statusPatrimonioId)
            {
                return _context.StatusPatrimonio.Find(statusPatrimonioId);
            }

            public StatusPatrimonio BuscarPorNome(string status)
            {
                return _context.StatusPatrimonio.FirstOrDefault(statusPatrimonio => statusPatrimonio.Status.ToLower() == status.ToLower());
            }

            public void Adicionar(StatusPatrimonio statusPatrimonio)
            {
                _context.StatusPatrimonio.Add(statusPatrimonio);
                _context.SaveChanges();
            }

            public void Atualizar(StatusPatrimonio statusPatrimonio)
            {
                if (statusPatrimonio == null)
                {
                    return;
                }

                StatusPatrimonio statusPatrimonioBanco = _context.StatusPatrimonio.Find(statusPatrimonio.StatusPatrimonioID);

                statusPatrimonioBanco.Status = statusPatrimonio.Status;
                _context.SaveChanges();
            }
        
    }
}

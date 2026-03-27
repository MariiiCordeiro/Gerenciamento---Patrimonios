using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Repositories
{
    public class CidadeRepository
    {
        private readonly GerenciamentoPatrimoniosContext _context;

        public CidadeRepository(GerenciamentoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Cidade> Listar()
        {
            return _context.Cidade.OrderBy(cidade => cidade.NomeCidade).ToList();
        }

        public Cidade BuscarPorId(Guid cidadeId)
        {
            return _context.Cidade.Find(cidadeId);
        }

        public Cidade BuscarPorNomeEEstado(string nomeCidade, string nomeEstado)
        {
            return _context.Cidade.FirstOrDefault(cidade => cidade.NomeCidade.ToLower == nomeCidade.ToLower() && nomeEstado.Estado = nome
        }
    }
}

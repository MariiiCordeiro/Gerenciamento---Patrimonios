using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositories
{
    public class PatrimonioRepository : IPatrimonioRepository
    {
        private readonly GerenciamentoPatrimoniosContext _context;

        public PatrimonioRepository(GerenciamentoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Patrimonio> Listar()
        {
            return _context.Patrimonio
                .OrderBy(patrimonio => patrimonio.Denominacao)
                .ToList();
        }

        public Patrimonio BuscarPorId(Guid patrimonioId)
        {
            return _context.Patrimonio.Find(patrimonioId);
        }

        public Patrimonio BuscarPorNumeroEPatrimonio(string numeroPatrimonio, Guid? patrimonioId = null)
        {
            var consulta = _context.Patrimonio.AsQueryable();

            if (patrimonioId.HasValue)
            {
                consulta = consulta.Where(patrimonio => patrimonio.PatrimonioID != patrimonioId.Value);
            }

            return consulta.FirstOrDefault(patrimonio => patrimonio.NumeroPatrimonio.ToLower() == numeroPatrimonio.ToLower());
        }

        public bool LocalizacaoExiste(Guid localId)
        {
            return _context.Local.Any(local => local.LocalID == localId);
        }
        bool TipoPatrimonioExiste(Guid tipoPatrimonioId)
        {
            return _context.TipoPatrimonio.Any(tipoPatrimonio => tipoPatrimonio.TipoPatrimonioID == tipoPatrimonioId);
        }
        bool StatusPatrimonioExiste(Guid statusPatrimonioId)
        {
            return _context.StatusPatrimonio.Any(statusPatrimonio => statusPatrimonio.StatusPatrimonioID == statusPatrimonioId);
        }

        public void Adicionar(Patrimonio patrimonio)
        {
            _context.Patrimonio.Add(patrimonio);
            _context.SaveChanges();
        }

        public void Atualizar(Patrimonio patrimonio)
        {
            if (patrimonio == null)
            {
                return;
            }

            Patrimonio patrimonioBanco = _context.Patrimonio.Find(patrimonio.PatrimonioID);

            if (patrimonioBanco == null)
            {
                return;
            }

            patrimonioBanco.Denominacao = patrimonio.Denominacao;
            patrimonioBanco.NumeroPatrimonio = patrimonio.NumeroPatrimonio;
            patrimonioBanco.Valor = patrimonio.Valor;
            patrimonioBanco.Imagem = patrimonio.Imagem;
            patrimonioBanco.LocalID = patrimonio.LocalID;
            patrimonioBanco.TipoPatrimonioID = patrimonio.TipoPatrimonioID;
            patrimonioBanco.StatusPatrimonioID = patrimonio.StatusPatrimonioID;
            _context.SaveChanges();
        }

        public void AtualizarStatus(Patrimonio patrimonio)
        {
            if (patrimonio == null)
            {
                return;
            }

            Patrimonio patrimonioBanco = _context.Patrimonio.Find(patrimonio.PatrimonioID);

            if (patrimonioBanco == null)
            {
                return;
            }

            patrimonioBanco.StatusPatrimonioID = patrimonio.StatusPatrimonioID;

            _context.SaveChanges();
        }

        public Patrimonio BuscarPorNumeroPatrimonio(string numeroPatrimonio, Guid? patrimonioId = null)
        {
            throw new NotImplementedException();
        }

        bool IPatrimonioRepository.TipoPatrimonioExiste(Guid tipoPatrimonioId)
        {
            return TipoPatrimonioExiste(tipoPatrimonioId);
        }

        bool IPatrimonioRepository.StatusPatrimonioExiste(Guid statusPatrimonioId)
        {
            return StatusPatrimonioExiste(statusPatrimonioId);
        }
    }
}

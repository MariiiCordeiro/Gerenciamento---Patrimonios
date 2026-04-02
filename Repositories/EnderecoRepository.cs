using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.Interfaces;

namespace GerenciamentoPatrimonio.Repositories
{
    public class EnderecoRepository : lEnderecoRepository
    {
        private readonly GerenciamentoPatrimoniosContext _context;

        public EnderecoRepository(GerenciamentoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Endereco> Listar()
        {
            return _context.Endereco.OrderBy(endereco => endereco.Longradouro).ToList();
        }

        public Endereco BuscarPorId(Guid enderecoId)
        {
            return _context.Endereco.Find(enderecoId);
        }

        public void Adicionar(Endereco endereco)
        {
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
        }

        public void Atualizar(Endereco endereco)
        {
            if (endereco == null)
            {
                return;
            }

            Endereco enderecoBanco = _context.Endereco.Find(endereco.EnderecoID);

            if (enderecoBanco == null)
            {
                return;
            }

            enderecoBanco.Longradouro = endereco.Longradouro;
            enderecoBanco.Numero = endereco.Numero;
            enderecoBanco.Complemento = endereco.Complemento;
            enderecoBanco.CEP = endereco.CEP;
            enderecoBanco.BairroID = endereco.BairroID;

            _context.SaveChanges();
        }

        public Endereco BuscarPorLongradouroENumero(string longradouro, int? numero, Guid bairroId)
        {
            return _context.Endereco.FirstOrDefault(endereco => endereco.Longradouro.ToLower() == longradouro.ToLower() && endereco.Numero == numero && endereco.BairroID == bairroId);
        }

        public bool BairroExiste(Guid bairroId)
        {
            return _context.Bairro.Any(bairro => bairro.BairroID == bairroId);
        }
    }
}

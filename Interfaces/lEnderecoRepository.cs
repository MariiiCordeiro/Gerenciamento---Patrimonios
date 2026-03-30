using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface lEnderecoRepository
    {
        List<Endereco> Listar();

        Endereco BuscarPorId(Guid enderecoId);
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Endereco BuscarPorLongradouroENumero(string longradouro, int? numero, Guid bairroId);
        bool BairroExiste(Guid bairroId);
    }
}

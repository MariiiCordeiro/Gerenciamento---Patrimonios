using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ICidadeRepository
    {
        List<Cidade> Listar();

        Cidade BuscarPorID(Guid cidadeId);

        Cidade BuscarPorNomeEEstado(string nomeCidade, string NomeEstado);

        void Atualizar(Cidade cidade);

        void Adicionar(Cidade cidade);
    }
}

using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ICidadeRepository
    {
        List<Cidade> Listar();

        Cidade BuscarPorId(Guid cidadeId);

        Cidade BuscarPorNomeEEstado(string nomeCidade, string nomeEstado);

        void Atualizar(Cidade cidade);

        void Adicionar(Cidade cidade);
    }
}

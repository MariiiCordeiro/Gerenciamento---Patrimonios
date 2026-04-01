using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ITipoAlteracaoRepositorycs
    {
        List<TipoAlteracao> Listar();
        TipoAlteracao BuscarPorId(Guid tipoAlteracaoId);
        TipoAlteracao BuscarPorNome(string nomeTipo);

        void Adicionar(TipoAlteracao tipoAlteracao);
        void Atualizar(TipoAlteracao tipoAlteracao);
    }
}

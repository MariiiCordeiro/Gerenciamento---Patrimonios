using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface ILocalRepository
    {
        List<Local> Listar();
        Local BuscarPorId(Guid localId);
        Local BuscarPorNome(string NomeLocal, Guid areaId);
        void Adicionar(Local local);
        void Atualizar(Local local);
        bool AreaExiste(Guid areaId);

    }
}

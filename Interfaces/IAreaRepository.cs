using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.Interfaces
{
    public interface IAreaRepository
    {
        List<Area> Listar(); //Criando um método em que irá listar todas as listas cadastradas

        Area BuscarPorId(Guid areaId);

        Area BuscarPorNome(string nomeArea);
    }

}

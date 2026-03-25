using RoyalGames.Exceptions;

namespace GerenciamentoPatrimonio.Aplications.Regras
{
    public class Validar
    {
        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obriátório!");
            }
        }
    }
}

using GerenciamentoPatrimonio.Domains;

namespace GerenciamentoPatrimonio.DTOs.CargoDto
{
    public class LerCargo
    {
        public Guid CargoID { get; set; }

        public string NomeCargo { get; set; } = string.Empty;

    }
}

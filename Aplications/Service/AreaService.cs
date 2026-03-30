using GerenciamentoPatrimonio.Aplications.Regras;
using GerenciamentoPatrimonio.Domains;
using GerenciamentoPatrimonio.DTOs.AreaDto;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Exceptions;

namespace GerenciamentoPatrimonio.Aplications.Service
{
    public class AreaService
    {
        private readonly IAreaRepository _repository;

        public AreaService(IAreaRepository repository)
        {
            _repository = repository;   
        }

        public List<LerArea> Listar()
        {
            List<Area> areas = _repository.Listar();

            List<LerArea> areaDto = areas.Select(area => new LerArea{
                AreaID = area.AreaID,
                NomeArea = area.NomeArea}).ToList();

            return areaDto;
        }

        public LerArea BuscarPorId(Guid areaId)
        {
            Area area = _repository.BuscarPorId(areaId);

            if (area == null)
            {
                throw new DomainException("Área não encontrada");

            }
            LerArea areaDto = new LerArea
            {
                AreaID = area.AreaID,
                NomeArea = area.NomeArea
            };

            return areaDto;
        }


        public void Adicionar(CriarArea dto)
        {
            Validar.ValidarNome(dto.NomeArea);     //metodo da regra validar, irá validar se o nomeque está entrando esta vazio
            Area areaExistente = _repository.BuscarPorNome(dto.NomeArea);

            if(areaExistente != null)
            {
                throw new DomainException("Já existe uma área com esse nome!");
            }

            Area area = new Area
            {
                // areaid = guid.newguid caso não houvesse a geraçãoa utomática no banco, portanto será só o nome que sera passado aqui.
                NomeArea = dto.NomeArea
            };

            _repository.Adicionar(area);
        }

        public void Atualiar(Guid areaId, CriarArea dto)
        {
            Validar.ValidarNome(dto.NomeArea);
            Area areaBanco = _repository.BuscarPorId(areaId);

            if(areaBanco == null)
            {
                throw new DomainException("Área não encontrada!");
            }

            Area areaExistente = _repository.BuscarPorNome(dto.NomeArea);

            if(areaExistente != null)
            {
                throw new DomainException("Já existe uma área cadastrada com esse nome!");
            }

            areaBanco.NomeArea= dto.NomeArea;

            _repository.Atualizar(areaBanco);
        }

    }
}

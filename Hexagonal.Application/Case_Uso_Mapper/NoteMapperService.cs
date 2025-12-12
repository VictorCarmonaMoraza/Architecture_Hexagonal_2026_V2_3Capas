using Hexagonal.Application.Mapper;
using Hexagonal.Application.Port_Primary;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.IRepository;

namespace Hexagonal.Application.Case_Uso_Mapper
{
    public class NoteMapperService<data_entrada_DTO, data_salida_MODEL> : IAddService<data_entrada_DTO, data_salida_MODEL>
    {
        //Esta dependencia guarda en base de datos el modelo(data_salida_MODEL)
        private readonly IAddRepository<data_salida_MODEL> _repository;

        //Mapeador generico de DTO a entidad de dominio
        private readonly IMapper<data_entrada_DTO, Nota> _mapperEntity;

        //Mapeador generico de DTO a modelo de infraestuctura
        private readonly IMapper<data_entrada_DTO,data_salida_MODEL> _mapperModel;

        public NoteMapperService(IAddRepository<data_salida_MODEL> repository,
                                 IMapper<data_entrada_DTO, Nota> mapperEntity,
                                 IMapper<data_entrada_DTO, data_salida_MODEL> mapperModel)
        {
            _repository = repository;
            _mapperEntity = mapperEntity;
            _mapperModel = mapperModel;
        }

        public async Task AddAsync(data_entrada_DTO dto)
        {
            // Mapeo a modelo de salida (DOMINIO)
            //Convierte el DTO en una entidad de dominio(Nota)
            var nota = _mapperEntity.Map(dto);
            // Mapeo a modelo de salida (INFRAESTRUCTURA)
            var noteModel =_mapperModel.Map(dto);

            if(nota.Message.Length < 3)
            {
                throw new Exception("La nota debe tener al menos 5 caracteres");
            }

            await _repository.AddAsync(noteModel);
        }
    }
}

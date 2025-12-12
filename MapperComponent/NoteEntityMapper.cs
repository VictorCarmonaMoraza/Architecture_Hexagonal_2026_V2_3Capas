using Hexagonal.Application.DTOs;
using Hexagonal.Application.Mapper;
using Hexagonal.Domain.Entities;

namespace MapperComponent
{
    // Mapper de NoteDTO a Nota (Entidad de Dominio)
    public class NoteEntityMapper : IMapper<NoteDTO, Nota>
    {
        //Forma 1
        public Nota Map(NoteDTO dto)
        {
            var nota = new Nota(dto.Id, dto.ItemId, dto.Message);
            return nota;
        }

        //Forma 2
        //public Nota Map(NoteDTO dto) => new Nota(dto.Id, dto.ItemId, dto.Message);
    }
}

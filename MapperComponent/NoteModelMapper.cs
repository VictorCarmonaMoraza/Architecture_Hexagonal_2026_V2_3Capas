using Hexagonal.Application.DTOs;
using Hexagonal.Application.Mapper;
using Hexagonal.Domain.Entities;
using Hexagonal.Infraestructure.Models;

namespace MapperComponent
{
    public class NoteModelMapper : IMapper<NoteDTO, NoteModel>
    {
        public NoteModel Map(NoteDTO dto)
        {
            var notaModel = new NoteModel()
            {
                Id = dto.Id,
                ItemId = dto.ItemId,
                Message = dto.Message,
                CreatedDate = DateTime.Now,
                Color = dto.Color
            };

            return notaModel;
        }

        //Forma 2
        //public NoteModel Map(NoteDTO dto) => new NoteModel { Id = dto.Id, ItemId = dto.ItemId, Message = dto.Message, CreatedDate = DateTime.Now, Color = dto.Color };


    }
}

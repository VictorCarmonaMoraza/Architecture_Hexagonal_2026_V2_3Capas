using Hexagonal.Application.DTOs;
using Hexagonal.Application.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagonal.Application.Case_Uso_DTO
{
    public class NoteDTOService : ICommonService<NoteDTO>
    {
        private readonly ICommonService<NoteDTO> _noteRepository;

        public NoteDTOService(ICommonService<NoteDTO> noteRepository)
        {
            _noteRepository = noteRepository;
        }


        public async Task AddItemAsync(NoteDTO noteDTO)
        {
            await _noteRepository.AddItemAsync(noteDTO);
        }

        public async Task<IEnumerable<NoteDTO>> GetAllItemsAsync()
        {
            return await _noteRepository.GetAllItemsAsync();
        }

        public Task<NoteDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemById(NoteDTO noteDTO)
        {
            throw new NotImplementedException();
        }
    }
}

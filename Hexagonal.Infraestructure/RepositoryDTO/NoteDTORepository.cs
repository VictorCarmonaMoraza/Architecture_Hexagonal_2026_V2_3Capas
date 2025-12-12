using Hexagonal.Application.DTOs;
using Hexagonal.Domain.GenericosDomain;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Infraestructure.RepositoryDTO
{
    public class NoteDTORepository : ICommonRepository<NoteDTO>
    {
        private readonly ApplicationDbContext _context;

        public NoteDTORepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NoteDTO item)
        {
            var model = new NoteModel()
            {
                Id = item.Id,
                ItemId = item.ItemId,
                Color = item.Color,
                Message = item.Message
            };
            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteDTO>> GetAllItemsAsync()
        {
            return await _context.NotesModel
                .Select(n => new NoteDTO
                {
                    Id = n.Id,
                    ItemId = n.ItemId,
                    Color = n.Color,
                    Message = n.Message
                })
                .ToListAsync();
        }

        public Task<NoteDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateItem(NoteDTO id)
        {
            throw new NotImplementedException();
        }
    }
}

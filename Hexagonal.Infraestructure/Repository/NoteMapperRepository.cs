using Hexagonal.Domain.IRepository;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.Models;

namespace Hexagonal.Infraestructure.Repository
{
    public class NoteMapperRepository : IAddRepository<NoteModel>
    {
        private readonly ApplicationDbContext _context;

        public NoteMapperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NoteModel model)
        {
            await _context.NotesModel.AddAsync(model);
            await _context.SaveChangesAsync();
        }
    }
}

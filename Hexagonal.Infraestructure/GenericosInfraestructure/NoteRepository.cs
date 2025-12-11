using Hexagonal.Domain.Entities;
using Hexagonal.Domain.GenericosDomain;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Infraestructure.GenericosInfraestructure
{
    public class NoteRepository : ICommonRepository<Nota>
    {

        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Nota nota)
        {
            var model = new NoteModel()
            {
                Message = nota.Message,
                ItemId = nota.ItemId,
                CreatdedDate = DateTime.UtcNow
            };
            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nota>> GetAllItemsAsync()
        {
             return await _context.NotesModel.Select(n => new Nota(n.Id, n.ItemId, n.Message)).ToListAsync();
        }

        public async Task<string> updateItem(Nota nota)
        {
            // Buscar la nota por su Id
            var model = await _context.NotesModel.FindAsync(nota.Id);

            if (model == null)
            {
                return "No se encontró la nota";
            }

            // Actualizar campos
            model.Message = nota.Message;

            // Guardar cambios
            await _context.SaveChangesAsync();

            return "Nota actualizada correctamente";
        }

    }
}

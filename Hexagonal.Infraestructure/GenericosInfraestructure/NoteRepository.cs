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

            var modelItem = await _context.ItemsModel.FindAsync(nota.ItemId);

            if (modelItem.IsCompleted == true)
            {
                return;
            }
            var model = new NoteModel()
            {
                Message = nota.Message,
                ItemId = nota.ItemId,
                CreatedDate = DateTime.UtcNow
            };
            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nota>> GetAllItemsAsync()
        {
             return await _context.NotesModel.Select(n => new Nota(n.Id, n.ItemId, n.Message)).ToListAsync();
        }

        public async Task<bool> updateItem(Nota nota)
        {
            // Buscar la nota por su Id
            var model = await _context.NotesModel.FindAsync(nota.Id);
            var modelItem = await _context.ItemsModel.FindAsync(nota.ItemId);

            if (model == null)
            {
                return false; // Nota no encontrada
            }

            if (modelItem.IsCompleted == true)
            {
                return false;
            }

            // Actualizar campos
            model.Message = nota.Message;

            // Guardar cambios
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<Nota?> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return Task.FromResult<Nota?>(null);
            }
            var model = _context.NotesModel.Find(id);
            if (model == null)
            {
                return Task.FromResult<Nota?>(null);
            }
            var nota = new Nota(model.Id, model.ItemId, model.Message);
            return Task.FromResult<Nota?>(nota);
        }

    }
}

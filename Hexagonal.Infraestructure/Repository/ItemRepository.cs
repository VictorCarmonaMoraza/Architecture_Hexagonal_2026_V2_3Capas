using Hexagonal.Domain.Entities;
using Hexagonal.Domain.interfaces;
using Hexagonal.Infraestructure.DBContext;
using Hexagonal.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Infraestructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        //Obtenemos el contexto de la base de datos mediante inyección de dependencias
        private readonly ApplicationDbContext _context;

        //Constructor
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {
            var model = new ItemModel()
            {
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CreatedDate = DateTime.UtcNow
            };

            _context.ItemsModel.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.ItemsModel.Select(e => new Item(e.Id, e.Title, e.IsCompleted)).ToListAsync();
        }

        public async Task updateItem(int id)
        {
            var model = await _context.ItemsModel.FindAsync(id);
            if (model != null)
            {
                model.IsCompleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}

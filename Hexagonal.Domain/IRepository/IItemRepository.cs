using Hexagonal.Domain.Entities;

namespace Hexagonal.Domain.interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task AddAsync(Item item);

        Task<string> updateItem(int id);
    }
}

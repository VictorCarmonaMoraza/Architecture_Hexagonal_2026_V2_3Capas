using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Port_Primary
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task AddItemAsync(string title);

        Task UpdateItemById(int id);
    }
}

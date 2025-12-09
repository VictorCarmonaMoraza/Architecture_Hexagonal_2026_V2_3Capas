using Hexagonal.Application.Port_Primary;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.interfaces;

namespace Hexagonal.Application.Case_Uso
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task AddItemAsync(string title)
        {
            //Creamos un nuevo item con el id 0 (se asignará automáticamente), el título proporcionado y el estado incompleto (false)
            var item = new Item(0, title, false);
            //Llamamos al repositorio para agregar el nuevo item
            await _itemRepository.AddAsync(item);
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllItemsAsync();
        }
    }
}

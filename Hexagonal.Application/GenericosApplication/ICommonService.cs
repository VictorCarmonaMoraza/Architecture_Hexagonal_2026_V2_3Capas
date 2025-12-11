using Hexagonal.Domain.Entities;

namespace Hexagonal.Application.Genericos
{
    //Puerto de entrada genérico
    public interface ICommonService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();
        Task AddItemAsync(TEntity entity);

        Task<bool> UpdateItemById(TEntity entity);

        Task<TEntity?> GetByIdAsync(int id);
    }
}

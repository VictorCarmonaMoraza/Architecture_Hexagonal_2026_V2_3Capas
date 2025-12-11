namespace Hexagonal.Domain.GenericosDomain
{
    public interface ICommonRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();
        Task AddAsync(TEntity item);

        Task<bool> updateItem(TEntity id);

        Task<TEntity?> GetByIdAsync(int id);
    }
}

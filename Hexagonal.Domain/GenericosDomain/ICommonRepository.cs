namespace Hexagonal.Domain.GenericosDomain
{
    public interface ICommonRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();
        Task AddAsync(TEntity item);

        Task<string> updateItem(TEntity id);
    }
}

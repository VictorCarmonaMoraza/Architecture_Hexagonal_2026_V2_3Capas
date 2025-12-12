namespace Hexagonal.Domain.IRepository
{
    //Algun modelo llegara pero no sabemos cual
    public interface IAddRepository<TModel>
    {
        //Haremos una insercion asincrona
        Task AddAsync(TModel model);
    }
}

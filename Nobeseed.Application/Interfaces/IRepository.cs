namespace Nobeseed.Domain.Interfaces
{
    public interface IRepository<T, TDto>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(TDto entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveAsync();
    }
}

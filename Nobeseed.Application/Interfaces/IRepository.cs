namespace Nobeseed.Domain.Interfaces
{
    public interface IRepository<T, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task<bool> Create(TCreateDto entity);
        Task<bool> Update(TUpdateDto entity);
        Task<bool> Delete(Guid id);
        Task SaveAsync();
    }
}

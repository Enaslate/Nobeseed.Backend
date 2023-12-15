using Nobeseed.Domain.Entities;

namespace Nobeseed.Application.Interfaces
{
    public interface IBookService
    {
        Task<IBaseResponse<IEnumerable<Book>>> GetAll();
    }
}

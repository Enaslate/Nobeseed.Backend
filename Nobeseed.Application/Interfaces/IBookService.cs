using Nobeseed.Application.Dtos;
using Nobeseed.Domain.Entities;

namespace Nobeseed.Application.Interfaces
{
    public interface IBookService
    {
        Task<IBaseResponse<IEnumerable<Book>>> GetBooks();
        Task<IBaseResponse<Book>> GetBook(Guid id);
        Task<IBaseResponse<bool>> Create(CreateBookDto bookDto);
        Task<IBaseResponse<bool>> Update(UpdateBookDto book);
        Task<IBaseResponse<bool>> Delete(Guid id);

    }
}

using Nobeseed.Application.Dtos;
using Nobeseed.Application.Interfaces;
using Nobeseed.Domain.Entities;

namespace Nobeseed.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book, CreateBookDto, UpdateBookDto>
    {

    }
}

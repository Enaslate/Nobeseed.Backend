using Nobeseed.Application.Interfaces;
using Nobeseed.Application.Responses;
using Nobeseed.Domain.Entities;
using Nobeseed.Domain.Interfaces;

namespace Nobeseed.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Book>>> GetAll()
        {
            var response = new BaseResponse<IEnumerable<Book>>();
            try
            {
                var books = await _bookRepository.GetAll();

                if (books.Count() == 0)
                {
                    response.Description = "Not found";
                    response.Success = true;
                    return response;
                }

                response.Data = books;
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Book>>()
                {
                    Description = $"{ex.Message}",
                };
            }
        }
    }
}

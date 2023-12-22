using Nobeseed.Application.Dtos;
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

        public async Task<IBaseResponse<IEnumerable<Book>>> GetBooks()
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
                    Success = false
                };
            }
        }

        public async Task<IBaseResponse<Book>> GetBook(Guid id)
        {
            var response = new BaseResponse<Book>();

            try
            {
                var book = await _bookRepository.Get(id);

                if (book == null)
                {
                    response.Description = "Book not found";
                    response.Success = true;

                    return response;
                }

                response.Data = book;
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<IBaseResponse<bool>> Create(CreateBookDto bookDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var isBookCreated = await _bookRepository.Create(bookDto);

                if (!isBookCreated)
                {
                    response.Description = "Not created";
                    response.Success = true;

                    return response;
                }

                response.Data = isBookCreated;
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<IBaseResponse<bool>> Update(UpdateBookDto book)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var bookToUpdate = await _bookRepository.Get(book.Id);

                if (bookToUpdate == null)
                {
                    response.Description = "Not found";
                    response.Success = true;

                    return response;
                }

                var isBookUpdated = await _bookRepository.Update(book);

                response.Data = isBookUpdated;
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(Guid id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var bookToDelete = await _bookRepository.Get(id);

                if (bookToDelete == null)
                {
                    response.Description = "Not found";
                    response.Success = true;

                    return response;
                }

                var isBookDeleted = await _bookRepository.Delete(bookToDelete.Id);

                response.Data = isBookDeleted;
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    Success = false
                };
            }
        }
    }
}

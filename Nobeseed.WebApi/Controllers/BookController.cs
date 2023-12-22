using Microsoft.AspNetCore.Mvc;
using Nobeseed.Application.Dtos;
using Nobeseed.Application.Interfaces;
using Nobeseed.Application.Responses;
using Nobeseed.Domain.Entities;

namespace Nobeseed.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json", "multipart/form-data")]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) => _bookService = bookService;

        [HttpGet]
        public async Task<ActionResult<IBaseResponse<IEnumerable<Book>>>> GetAll()
        {
            var books = await _bookService.GetBooks();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IBaseResponse<Book>>> Get([FromQuery]Guid id)
        {
            var book = await _bookService.GetBook(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<IBaseResponse<bool>>> Create(CreateBookDto bookDto)
        {
            var isCreated = await _bookService.Create(bookDto);

            return Ok(isCreated);
        }

        [HttpPut]
        public async Task<ActionResult<IBaseResponse<bool>>> Update(UpdateBookDto book)
        {
            var isUpdated = await _bookService.Update(book);

            return Ok(isUpdated);
        }

        [HttpDelete]
        public async Task<ActionResult<IBaseResponse<bool>>> Delete(Guid id)
        {
            var isDeleted = await _bookService.Delete(id);

            return Ok(isDeleted);
        }
    }
}

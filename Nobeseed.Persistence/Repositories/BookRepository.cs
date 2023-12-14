using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nobeseed.Application.Dtos;
using Nobeseed.Domain.Entities;
using Nobeseed.Domain.Interfaces;

namespace Nobeseed.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly NobeseedDbContext _context;
        private readonly IMapper _mapper;
        public BookRepository(NobeseedDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> Get(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            return book;
        }

        public async Task Create(BookDto entity)
        {
            var book = _mapper.Map<Book>(entity);
            await _context.Books.AddAsync(book);
            await SaveAsync();
        }

        public async Task Update(Book entity)
        {
            _context.Books.Attach(entity);
            _context.Books.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

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

        public async Task<bool> Create(CreateBookDto entity)
        {
            var book = _mapper.Map<Book>(entity);
            await _context.Books.AddAsync(book);
            await SaveAsync();

            return true;
        }

        public async Task<bool> Update(UpdateBookDto entity)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (book == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            book.SetTitle(entity.Title);
            book.SetDescription(entity.Description);
            book.SetAuthor(entity.Author);
            book.SetStatus(entity.Status);
            book.SetType(entity.Type);
            book.SetCountry(entity.Country);
            
            _context.Books.Attach(book);
            _context.Entry(book).State = EntityState.Modified;
            await SaveAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                throw new ArgumentException(nameof(book));
            }

            _context.Books.Remove(book);
            await SaveAsync();

            return true;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

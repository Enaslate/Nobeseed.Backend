using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nobeseed.Application.Dtos;
using Nobeseed.Application.Interfaces;
using Nobeseed.Application.Services;
using Nobeseed.Domain.Entities;
using Nobeseed.Domain.Interfaces;
using Nobeseed.Persistence;
using Nobeseed.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Book), typeof(BookDto));

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<NobeseedDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello world!");
app.MapGet("/books", async (IBookService books) => await books.GetAll());
app.MapGet("/books/{id}", async (IBookRepository books, Guid id) => await books.Get(id));
app.MapPost("/books", async (IBookRepository books, BookDto bookDto) => await books.Create(bookDto));
app.MapDelete("/books/{book}", async (IBookRepository books, [FromBody] Book book) => await books.Delete(book));

app.MapGet("/books/{bookId}/chapters", async (NobeseedDbContext context, Guid bookId) =>
    await context.Chapters
    .Where(c => c.BookId == bookId)
    .OrderBy(c => c.Order)
    .ToListAsync());

app.MapGet("/chapters", async (NobeseedDbContext context) => await context.Chapters.ToListAsync());

app.Run();
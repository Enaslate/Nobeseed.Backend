using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nobeseed.Application.Dtos;
using Nobeseed.Application.Interfaces;
using Nobeseed.Application.Services;
using Nobeseed.Domain.Entities;
using Nobeseed.Domain.Interfaces;
using Nobeseed.Persistence;
using Nobeseed.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Book), typeof(CreateBookDto));
builder.Services.AddAutoMapper(typeof(Book), typeof(UpdateBookDto));
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<NobeseedDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapGet("/", () => "Hello world!");
//app.MapDelete("/", () => "Delete");

//app.MapGet("/books", async (IBookService books) => await books.GetBooks());
//app.MapGet("/books/{id}", async (IBookService books, Guid id) => await books.GetBook(id));
//app.MapPost("/books", async (IBookService books, BookDto bookDto) => await books.Create(bookDto));
//app.MapPut("/books", async (IBookService books, [FromBody]Book book) => await books.Update(book));
//app.MapDelete("/books/{id}", async (IBookService books, [FromBody] Guid id) => await books.Delete(id));



//app.MapGet("/books/{bookId}/chapters", async (NobeseedDbContext context, Guid bookId) =>
//    await context.Chapters
//    .Where(c => c.BookId == bookId)
//    .OrderBy(c => c.Order)
//    .ToListAsync());

//app.MapGet("/chapters", async (NobeseedDbContext context) => await context.Chapters.ToListAsync());

app.Run();
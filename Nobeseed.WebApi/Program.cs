using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nobeseed.Domain.Entities;
using Nobeseed.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<NobeseedDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.MapGet("/", () => "Hello world!");
app.MapGet("/books", async (NobeseedDbContext context) => await context.Books.ToListAsync());
app.MapGet("/books/{id}", async (NobeseedDbContext context, Guid id) => await context.Books.FirstOrDefaultAsync(x => x.Id == id));
app.MapGet("/books/{bookId}/chapters", async (NobeseedDbContext context, Guid bookId) => 
    await context.Chapters
    .Where(c => c.BookId == bookId)
    .OrderBy(c => c.Order)
    .ToListAsync());

app.MapGet("/chapters", async (NobeseedDbContext context) => await context.Chapters.ToListAsync());

app.Run();
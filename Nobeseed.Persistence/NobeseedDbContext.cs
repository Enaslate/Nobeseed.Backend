using System;
using Microsoft.EntityFrameworkCore;
using Nobeseed.Domain.Entities;
using Nobeseed.Persistence.EntityTypeConfigurations;

namespace Nobeseed.Persistence
{
    public class NobeseedDbContext : DbContext
    {
        public DbSet<Book> Books { get; private set; }
        public DbSet<Chapter> Chapters { get; private set; }

        public NobeseedDbContext(DbContextOptions<NobeseedDbContext> options) 
            : base(options) 
        { 
            Books = Set<Book>();
            Chapters = Set<Chapter>();
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new ChapterConfiguration());
            base.OnModelCreating(builder);

            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A1"),
                    UserId = Guid.Parse("25CF48C7-8E23-4B2D-98D4-68491AC524A1"),
                    Title = "Book1"
                },
                new Book
                {
                    Id = Guid.Parse("0195D302-D181-41DC-92D0-6148F0E7D3CA"),
                    UserId = Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    Title = "Book2"
                }
            );

            builder.Entity<Chapter>().HasData(
                new Chapter
                {
                    Id = Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    BookId = Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A1"),
                    UserId = Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    Title = "Chapter1 book1"
                },
                new Chapter
                {
                    Id = Guid.Parse("25CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    BookId = Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A1"),
                    UserId = Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    Title = "Chapter2 book1"
                },
                new Chapter
                {
                    Id = Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    BookId = Guid.Parse("0195D302-D181-41DC-92D0-6148F0E7D3CA"),
                    UserId = Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    Title = "Chapter1 book2"
                },
                new Chapter
                {
                    Id = Guid.Parse("45CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    BookId = Guid.Parse("0195D302-D181-41DC-92D0-6148F0E7D3CA"),
                    UserId = Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    Title = "Chapter2 book2"
                }
            );
        }
    }
}

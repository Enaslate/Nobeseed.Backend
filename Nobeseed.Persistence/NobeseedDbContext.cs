using Microsoft.EntityFrameworkCore;
using Nobeseed.Application.Interfaces;
using Nobeseed.Domain.Entities;
using Nobeseed.Persistence.EntityTypeConfigurations;

namespace Nobeseed.Persistence
{
    public class NobeseedDbContext : DbContext, INobeseedDbContext
    {
        public DbSet<Book> Books { get; private set; }
        public DbSet<Chapter> Chapters { get; private set; }
        public DbSet<Genre> Genres { get; private set; }
        public DbSet<Tag> Tags { get; private set; }

        public NobeseedDbContext(DbContextOptions<NobeseedDbContext> options) 
            : base(options) 
        { 
            Books = Set<Book>();
            Chapters = Set<Chapter>();
            Genres = Set<Genre>();
            Tags = Set<Tag>();

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new ChapterConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            base.OnModelCreating(builder);

            builder.Entity<Book>().HasData(
                new Book(
                    Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A1"),
                    Guid.Parse("25CF48C7-8E23-4B2D-98D4-68491AC524A1"),
                    "Book1"
                    ),
                new Book
                (
                    Guid.Parse("0195D302-D181-41DC-92D0-6148F0E7D3CA"),
                    Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    "Book2"
                )
            );

            builder.Entity<Chapter>().HasData(
                new Chapter
                (   
                    Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A1"),
                    Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    "Chapter1 book1"
                ),
                new Chapter
                (
                    Guid.Parse("25CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    Guid.Parse("15CF48C6-8E23-4B2D-98D4-68491AC524A1"),
                    Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    "Chapter2 book1"
                ),
                new Chapter
                (
                    Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    Guid.Parse("0195D302-D181-41DC-92D0-6148F0E7D3CA"),
                    Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    "Chapter1 book2"
                ),
                new Chapter
                (
                    Guid.Parse("45CF48C6-8E23-4B2D-98D4-68491AC524A2"),
                    Guid.Parse("0195D302-D181-41DC-92D0-6148F0E7D3CA"),
                    Guid.Parse("35CF48C6-8E23-4B2D-98D4-68491AC524AF"),
                    "Chapter2 book2"
                )
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nobeseed.Domain.Entities;

namespace Nobeseed.Persistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.HasIndex(book => book.Id).IsUnique();
            builder.Property(book => book.UserId);
            builder.Property(book => book.Title).HasMaxLength(255);
        }
    }
}

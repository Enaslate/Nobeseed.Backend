using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nobeseed.Domain.Entities;

namespace Nobeseed.Persistence.EntityTypeConfigurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasKey(chapter => chapter.Id);
            builder.HasIndex(chapter => chapter.Id).IsUnique();
            builder.Property(chapter => chapter.Title).HasMaxLength(255);
        }
    }
}

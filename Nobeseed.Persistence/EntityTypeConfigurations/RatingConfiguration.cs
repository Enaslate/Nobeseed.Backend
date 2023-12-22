using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nobeseed.Domain.Entities;

namespace Nobeseed.Persistence.EntityTypeConfigurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(rating => rating.Id);
            builder.HasIndex(rating => rating.Id).IsUnique();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Nobeseed.Domain.Entities;

namespace Nobeseed.Application.Interfaces
{
    public interface INobeseedDbContext 
    {
        DbSet<Book> Books { get; }
        DbSet<Chapter> Chapters { get; }
    }
}

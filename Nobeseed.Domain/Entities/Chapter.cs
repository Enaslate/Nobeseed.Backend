using Nobeseed.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Nobeseed.Domain.Entities
{
    public class Chapter
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public ChapterStatus Status { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}

using Nobeseed.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Nobeseed.Domain.Entities
{
    public class Chapter
    {
        public Guid Id { get; }
        public Guid BookId { get; }
        public Guid UserId { get; }
        public string Title { get; private set; } = null!;
        public string? Content { get; private set; }
        public int Order { get; private set; }
        public ChapterStatus Status { get; private set; }

        public Chapter() { }

        public Chapter(Guid id, Guid bookId, Guid userId, string title)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
            Title = title;
        }

        public Chapter(Guid id, Guid bookId, Guid userId, string title, string? content, int order, ChapterStatus status)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
            Title = title;
            Content = content;
            Order = order;
            Status = status;
        }

        public void SetTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                Title = title;
            }
        }

        public void SetContent(string content) {  Content = content; }
        public void SetOrder(int order) {  Order = order; }
        public void SetStatus(ChapterStatus status) {  Status = status; }
    }
}

using Nobeseed.Domain.Enum;

namespace Nobeseed.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public string? Image {  get; set; }
        public string? Author { get; private set; }
        public DateTime PublicationYear { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        private List<Genre> _genres = new List<Genre>();
        public IEnumerable<Genre>? Genres => _genres;
        private List<Tag> _tags = new List<Tag>();
        public IEnumerable<Tag>? Tags => _tags;
        public BookFormat BookFormat { get; private set; }
        public BookStatus BookStatus { get; private set; }
        public BookStatus TranslationStatus { get; private set; }
        public AgeRating AgeRating { get; private set; }
        private List<Rating> _evaluations = new List<Rating>();
        public IEnumerable<Rating>? Evaluations => _evaluations;
        public float Evaluation 
        { 
            get
            {
                if (_evaluations.Count == 0)
                {
                    return 0;
                }

                int sum = 0;
                foreach (Rating rating in _evaluations)
                {
                    sum += rating.Stars;
                }

                float total = sum / _evaluations.Count;

                return total;
            }
        }
        private List<Comment> _comments = new List<Comment>();
        public IEnumerable<Comment>? Comments => _comments;
        public BookType BookType { get; private set; }
        public Country Country { get; private set; }

        public Book() { }
        public Book(Guid id) { Id = id; }

        public Book(Guid id, Guid userId, string title) : this(id)
        {
            UserId = userId;
            Title = title;
        }

        public Book(Guid id, Guid userId, string title, string? description, string? image, string? author, DateTime publicationYear, 
            DateTime creationDate, DateTime modifiedDate, List<Genre> genres, List<Tag> tags, BookFormat bookFormat, BookStatus bookStatus, 
            BookStatus translationStatus, AgeRating ageRating, List<Rating> evaluations, List<Comment> comments, BookType bookType, Country country) : this(id, userId, title)
        {
            Description = description;
            Image = image;
            Author = author;
            PublicationYear = publicationYear;
            CreationDate = creationDate;
            ModifiedDate = modifiedDate;
            _genres = genres;
            _tags = tags;
            BookFormat = bookFormat;
            BookStatus = bookStatus;
            TranslationStatus = translationStatus;
            AgeRating = ageRating;
            _evaluations = evaluations;
            _comments = comments;
            BookType = bookType;
            Country = country;
        }

        public void SetTitle(string title) 
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Title = title;
            }
        }
        public void SetDescription(string description) {  Description = description; }
        public void SetAuthor(string author) {  Author = author; }
        public void SetStatus(BookStatus status) {  BookStatus = status; }
        public void SetType(BookType type) {  BookType = type; }
        public void SetCountry(Country country) { Country = country; }
        public void SetPublicationYear(DateTime year) { PublicationYear = year; }
        public void SetCreationDate(DateTime creationDate) { CreationDate = creationDate; }
        public void SetModifiedDate(DateTime modifiedDate) { ModifiedDate = modifiedDate; }
        public void AddGenre(Genre genre) { _genres.Add(genre); }
        public void RemoveGenre(Genre genre) { _genres.Remove(genre); }
        public void AddTag(Tag tag) { _tags.Add(tag); }
        public void RemoveTag(Tag tag) { _tags.Remove(tag); }
        public void AddComment(Comment comment) { _comments.Add(comment); }
        public void RemoveComment(Comment comment) { _comments.Remove(comment); }
        public void AddEvaluation(Rating rating) { _evaluations.Add(rating); }
        public void RemoveEvaluation(Rating rating) { _evaluations.Remove(rating); }
        public void SetBookFormat(BookFormat bookFormat) {  BookFormat = bookFormat; }
        public void SetBookStatus(BookStatus status) { BookStatus = status; }
        public void SetTranslationStatus(BookStatus status) { TranslationStatus = status; }
        public void SetAgeRating(AgeRating ageRating) { AgeRating = ageRating; }
    }
}

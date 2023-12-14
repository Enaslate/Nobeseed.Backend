using System;
using System.ComponentModel.DataAnnotations;
using Nobeseed.Domain.Enum;

namespace Nobeseed.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public string? Image {  get; private set; }
        public string? Author { get; private set; }
        public BookStatus Status { get; private set; }
        public BookType Type { get; private set; }
        public Country Country { get; private set; }

        public Book() { }

        public Book(Guid id, Guid userId, string title)
        {
            Id = id;
            UserId = userId;
            Title = title;
        }

        public Book(Guid id, Guid userId, string title, string? description, string? image,
            string? author, BookStatus status, BookType type, Country country)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            Image = image;
            Author = author;
            Status = status;
            Type = type;
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
        public void SetStatus(BookStatus status) {  Status = status; }
        public void SetType(BookType type) {  Type = type; }
        public void SetCountry(Country country) { Country = country; }
    }
}

﻿using Nobeseed.Application.Interfaces;
using Nobeseed.Domain.Enum;

namespace Nobeseed.Application.Dtos
{
    public class BookDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Author { get; set; }
        public BookStatus Status { get; set; }
        public BookType Type { get; set; }
        public Country Country { get; set; }


    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;
using Nobeseed.Domain.Enum;

namespace Nobeseed.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Author { get; set; }
        public BookStatus Status { get; set; }
        public BookType Type { get; set; }
        public Country Country { get; set; }
    }
}
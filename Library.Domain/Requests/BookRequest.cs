﻿using System;
using System.ComponentModel.DataAnnotations;
using Library.Domain.Model;
using Library.Domain.Properties;

namespace Library.Domain.Requests
{
    public  abstract class BookRequest
    {
        [Display(Name = "Book_Title", ResourceType = typeof(DomainResources))]
        public string Title { get; set; }
        [Display(Name = "Book_Author", ResourceType = typeof(DomainResources))]
        public string Author { get; set; }
    }

    public class CreateBookRequest : BookRequest
    {
    }

    public class EditBookRequest : BookRequest
    {
        public Guid Id { get; set; }

        public EditBookRequest() { }
        public EditBookRequest(Book book) : this()
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
        }
    }
}

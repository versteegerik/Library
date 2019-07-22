using System;
using System.ComponentModel.DataAnnotations;
using Library.Domain.Models;
using Library.Domain.Properties;

namespace Library.Domain.Requests
{
    public  abstract class BookRequest
    {
        [Display(Name = "Book_Isbn", ResourceType = typeof(DomainResources))]
        public string Isbn { get; set; }
        [Display(Name = "Book_Title", ResourceType = typeof(DomainResources))]
        public string Title { get; set; }
        [Display(Name = "Book_Author", ResourceType = typeof(DomainResources))]
        public string Author { get; set; }
    }

    public class CreateBookRequest : BookRequest
    {
    }

    public class UpdateBookRequest : BookRequest
    {
        public Guid Id { get; set; }

        public UpdateBookRequest() { }
        public UpdateBookRequest(Book book) : this()
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Isbn = book.Isbn;
        }
    }

    public class DeleteBookRequest : BookRequest
    {
        public Guid Id { get; set; }

        public DeleteBookRequest() { }
        public DeleteBookRequest(Book book) : this()
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
        }
    }
}

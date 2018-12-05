using System;
using Library.Domain.Model;

namespace Library.Application.Web.Views.Books
{
    public class BookDetailsModel
    {
        public BookDetailsModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}

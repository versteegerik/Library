using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Web.Views.Books
{
    public class MyBookListViewModel
    {
        public MyBookListViewModel(IEnumerable<Book> books)
        {
            Books = books.Select(book => new MyBookViewModel(book));
        }

        public IEnumerable<MyBookViewModel> Books { get; set; }
    }

    public class MyBookViewModel
    {
        public MyBookViewModel(Book book)
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

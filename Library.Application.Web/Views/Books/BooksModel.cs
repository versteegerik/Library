using Library.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Web.Views.Books
{
    public class BookListViewModel
    {
        public BookListViewModel(IEnumerable<Book> books)
        {
            Books = books.Select(book => new BookViewModel(book));
        }

        public IEnumerable<BookViewModel> Books { get; set; }
    }

    public class BookViewModel
    {
        public BookViewModel(Book book)
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

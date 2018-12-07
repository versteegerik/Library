using System;
using Library.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Web.Views.Home
{
    public class HomeModel
    {
        public HomeModel(IEnumerable<Book> myBooks, IEnumerable<Book> myWishList)
        {
            MyBooks = myBooks.Select(book => new BookViewModel(book));
            MyWishList = myWishList.Select(book => new BookViewModel(book));
        }

        public IEnumerable<BookViewModel> MyBooks { get; set; }
        public IEnumerable<BookViewModel> MyWishList { get; set; }
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

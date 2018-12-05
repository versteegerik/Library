using Library.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Web.Views.Home
{
    public class HomeModel
    {
        public HomeModel(IEnumerable<Book> myBooks)
        {
            MyBooks = myBooks.Select(book => new BookViewModel(book));
        }

        public IEnumerable<BookViewModel> MyBooks { get; set; }
    }

    public class BookViewModel
    {
        public BookViewModel(Book book)
        {
            Title = book.Title;
            Author = book.Author;
        }

        public string Title { get; set; }
        public string Author { get; set; }
    }
}

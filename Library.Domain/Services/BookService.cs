using System;
using System.Collections.Generic;
using Library.Domain.Model;
using Library.Domain.Requests;

namespace Library.Domain.Services
{
    public class BookService
    {
        public Book GetBookById(Guid id)
        {
            return new Book(new CreateBookRequest
            {
                Author = "Test",
                Title = "Test"
            });
        }

        public IList<Book> GetMyBooks()
        {
            return new List<Book>
            {
                new Book(new CreateBookRequest
                {
                    Author = "Test",
                    Title = "Test"
                }),
                new Book(new CreateBookRequest
                {
                    Author = "Test2",
                    Title = "Test"
                }),
                new Book(new CreateBookRequest
                {
                    Author = "Test3",
                    Title = "Test"
                }),
                new Book(new CreateBookRequest
                {
                    Author = "Test4",
                    Title = "Test"
                })
            };
        }

        public void CreateBook(CreateBookRequest request)
        {
            var book = new Book(request);
        }

        public IEnumerable<Book> GetMyWishList()
        {
            return new List<Book>
            {
                new Book(new CreateBookRequest
                {
                    Author = "Test",
                    Title = "Test"
                }),
                new Book(new CreateBookRequest
                {
                    Author = "Test2",
                    Title = "Test"
                }),
                new Book(new CreateBookRequest
                {
                    Author = "Test3",
                    Title = "Test"
                }),
                new Book(new CreateBookRequest
                {
                    Author = "Test4",
                    Title = "Test"
                })
            };
        }
    }
}

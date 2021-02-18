using Library.Domain.Models;
using Library.Domain.Requests;
using System.Linq;
using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public class PersonBookService : BaseService
    {
        public PersonBookService(IPersistence persistence) : base(persistence) { }

        public void AddBookToWishList(AddBookToWishListRequest request)
        {
            Persistence.BeginTransaction();
            var person = Persistence.GetById<Person>(request.PersonId);
            if (person.WishListBooks.Any(b => b.Id == request.BookId))
            {
                //Person already has this book on his WishList
                return;
            }

            var book = Persistence.GetById<Book>(request.BookId);
            person.WishListBooks.Add(book);
            Persistence.Commit();
        }

        public void RemoveBookFromWishListRequest(AddBookToWishListRequest request)
        {
            Persistence.BeginTransaction();
            var person = Persistence.GetById<Person>(request.PersonId);

            var book = Persistence.GetById<Book>(request.BookId);
            person.WishListBooks.Remove(book);
            Persistence.Commit();
        }

        public void AddBookToOwnedListRequest(AddBookToWishListRequest request)
        {
            Persistence.BeginTransaction();
            var person = Persistence.GetById<Person>(request.PersonId);
            if (person.OwnedBooks.Any(b => b.Id == request.BookId))
            {
                //Person already has this book on his WishList
                return;
            }

            var book = Persistence.GetById<Book>(request.BookId);
            person.OwnedBooks.Add(book);
            Persistence.Commit();
        }

        public void RemoveBookFromOwnedListRequest(AddBookToWishListRequest request)
        {
            Persistence.BeginTransaction();
            var person = Persistence.GetById<Person>(request.PersonId);

            var book = Persistence.GetById<Book>(request.BookId);
            person.OwnedBooks.Remove(book);
            Persistence.Commit();
        }
    }
}

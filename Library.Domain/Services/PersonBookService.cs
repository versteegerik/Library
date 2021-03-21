using Library.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public class PersonBookService : BasePersonService
    {
        public PersonBookService(IPersistence persistence, IHttpContextAccessor httpContextAccessor) : base(persistence, httpContextAccessor) { }

        public bool HasAsOwnedBooks(Book book) => GetCurrentPerson().OwnedBooks.Any(_ => _ == book);

        public async Task AddToOwnedBooks(Book book)
        {
            Persistence.BeginTransaction();

            var person = GetCurrentPerson();
            if (person.OwnedBooks.Any(b => b.Id == book.Id))
            {
                //Person already has this book on his WishList
                return;
            }
            person.OwnedBooks.Add(book);

            await Persistence.Update(person);
            await Persistence.Commit();
        }

        public async Task RemoveFromOwnedBooks(Book book)
        {
            Persistence.BeginTransaction();

            var person = GetCurrentPerson();
            if (!person.OwnedBooks.Any(b => b.Id == book.Id))
            {
                //Person already has this book on his WishList
                return;
            }
            person.OwnedBooks.Remove(book); 

            await Persistence.Update(person);
            await Persistence.Commit();
        }
    }
}

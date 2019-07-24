using Library.Domain.Common;
using Library.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
{
    public class BookRepository
    {
        private readonly IDomainPersistence persistence;

        public BookRepository(IDomainPersistence persistence)
        {
            this.persistence = persistence;
        }

        public IEnumerable<Book> GetBooksByUser(ApplicationUser applicationUser)
        {
            return persistence.Books
                .Where(b => b.Owner == applicationUser)
                .ToArray();
        }
    }
}

using Library.Domain.Common;
using Library.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
{
    public class BookRepository : Repository
    {
        public BookRepository(DomainDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Book> GetBooksByUser(ApplicationUser applicationUser)
        {
            return DbContext.Books
                .Where(b => b.Owner == applicationUser)
                .ToArray();
        }
    }
}

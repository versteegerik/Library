using Library.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
{
    public class BookRepository : IRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Book> GetBooksByUser(ApplicationUser applicationUser)
        {
            return DbContext.Query<Book>().Where(b => b.Owner == applicationUser).ToList();
        }
    }
}

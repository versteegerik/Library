using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Domain.Common;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence
{
    public class DomainDbContext : DbContext, IDomainPersistence
    {
        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        private DbSet<Book> BooksDbSet { get; set; }
        private DbSet<DomainUser> DomainUsersDbSet { get; set; }

        public IQueryable<Book> Books => BooksDbSet.AsQueryable();

        public DomainUser GetDomainUser(ClaimsPrincipal user) => DomainUsersDbSet.Single(_ => _.UserName.Equals(user.Identity.Name, StringComparison.OrdinalIgnoreCase));

        public void Create(Book book) => BooksDbSet.Add(book);

        public void Update(Book book) => BooksDbSet.Update(book);

        public void Delete(Book book) => BooksDbSet.Remove(book);
        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}

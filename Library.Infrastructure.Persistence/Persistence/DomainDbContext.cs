using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Common;
using Library.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence
{
    public class DomainDbContext : DbContext, IDomainPersistence
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DomainDbContext(DbContextOptions<DomainDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        private DbSet<Book> BooksDbSet { get; set; }
        private DbSet<DomainUser> DomainUsersDbSet { get; set; }
        private DbSet<UserBookInformation> UserBookInformationDbSet { get; set; }

        public IQueryable<Book> Books => BooksDbSet.AsQueryable();

        public IQueryable<UserBookInformation> UserBookInformations => UserBookInformationDbSet.AsQueryable();

        public void Create(Book book) => BooksDbSet.Add(book);

        public void Update(Book book) => BooksDbSet.Update(book);

        public void Delete(Book book) => BooksDbSet.Remove(book);


        public IQueryable<DomainUser> DomainUsers => DomainUsersDbSet.AsQueryable();
        public void Update(DomainUser domainUser) => DomainUsersDbSet.Update(domainUser);


        public void Create(UserBookInformation userBookInformation) => UserBookInformationDbSet.Add(userBookInformation);

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}

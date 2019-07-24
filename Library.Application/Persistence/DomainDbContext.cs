using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Persistence
{
    public class DomainDbContext : DbContext
    {
        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}

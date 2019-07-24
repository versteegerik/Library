using System.Linq;
using Library.Application.Common;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationPersistence
    {
        public ApplicationDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        private DbSet<NewsMessage> NewsMessagesDbSet { get; set; }

        public IQueryable<NewsMessage> NewsMessages => NewsMessagesDbSet.AsQueryable();
    }
}

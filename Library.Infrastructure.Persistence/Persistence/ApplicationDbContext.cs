using Library.Application.Common;
using Library.Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationPersistence
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        private DbSet<NewsMessage> NewsMessagesDbSet { get; set; }

        public IQueryable<NewsMessage> NewsMessages => NewsMessagesDbSet.AsQueryable();

        public void Create(NewsMessage newsMessage) => NewsMessagesDbSet.Add(newsMessage);

        public void Update(NewsMessage newsMessage) => NewsMessagesDbSet.Update(newsMessage);

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}

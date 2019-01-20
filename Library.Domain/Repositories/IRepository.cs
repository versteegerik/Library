using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Repositories
{
    public abstract class IRepository
    {
        protected ApplicationDbContext DbContext { get; }

        public IRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}

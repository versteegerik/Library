using Library.Domain.Common;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Domain.Model;

namespace Library.Domain.Repositories
{
    public abstract class Repository
    {
        protected ApplicationDbContext DbContext { get; }

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public async Task<T> FindAsync<T>(Guid id) where T : BaseEntity => await DbContext.FindAsync<T>(id);

        public void Add<T>(T entity) where T : BaseEntity => DbContext.Add(entity);

        public void Update<T>(T entity) where T : BaseEntity => DbContext.Update(entity);

        public void SaveChanges() => DbContext.SaveChanges();

        public async Task<ApplicationUser> FindUserByClaimsPrincipalAsync(ClaimsPrincipal claimsPrincipal) => await DbContext.ApplicationUsers.FindAsync(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}

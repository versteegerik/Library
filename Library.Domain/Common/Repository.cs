using Library.Domain.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Domain.Common
{
    public abstract class Repository
    {
        protected DomainDbContext DbContext { get; }

        protected Repository(DomainDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T> FindAsync<T>(Guid id) where T : BaseEntity => await DbContext.FindAsync<T>(id);

        public void Create<T>(T entity) where T : BaseEntity => DbContext.Add(entity);

        public void Update<T>(T entity) where T : BaseEntity => DbContext.Update(entity);

        public void Delete<T>(T entity) where T : BaseEntity => DbContext.Remove(entity);

        public void SaveChanges() => DbContext.SaveChanges();

        public async Task<ApplicationUser> FindUserByClaimsPrincipal(ClaimsPrincipal claimsPrincipal) => await DbContext.ApplicationUsers.FindAsync(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}

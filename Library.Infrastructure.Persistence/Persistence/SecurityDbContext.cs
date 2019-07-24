using Library.Infrastructure.Security.Models;
using Library.Infrastructure.Security.Persistence;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Infrastructure.Persistence
{
    public class SecurityDbContext : IdentityDbContext, ISecurityPersistence
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {
        }

        private DbSet<ApplicationUser> ApplicationUsersDbSet { get; set; }

        public IQueryable<ApplicationUser> ApplicationUsers => ApplicationUsersDbSet.AsQueryable();
    }
}

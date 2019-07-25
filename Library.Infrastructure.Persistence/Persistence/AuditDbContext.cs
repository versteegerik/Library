using System.Threading.Tasks;
using Library.Infrastructure.Audit.Common;
using Library.Infrastructure.Audit.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Persistence
{
    public class AuditDbContext : DbContext, IAuditPersistence
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
        {
        }

        private DbSet<LoginAttempt> LoginAttempt { get; set; }

        public void Create(LoginAttempt loginAttempt) => LoginAttempt.Add(loginAttempt);
        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}

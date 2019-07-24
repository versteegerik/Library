using Library.Infrastructure.Audit.Models;
using Library.Infrastructure.Security.Persistence;
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
    }
}

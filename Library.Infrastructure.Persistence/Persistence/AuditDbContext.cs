using Library.Infrastructure.Security.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Persistence
{
    public class AuditDbContext : DbContext, IAuditPersistence
    {
    }
}

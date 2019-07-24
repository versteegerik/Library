using Library.Infrastructure.Audit.Models;

namespace Library.Infrastructure.Security.Persistence
{
    public interface IAuditPersistence
    {
        void Create(LoginAttempt loginAttempt);
    }
}

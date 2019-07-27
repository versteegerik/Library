using Library.Infrastructure.Audit.Models;
using System.Threading.Tasks;

namespace Library.Infrastructure.Audit.Common
{
    public interface IAuditPersistence
    {
        void Create(LoginAttempt loginAttempt);
        Task SaveChangesAsync();
    }
}

using Library.Infrastructure.Security.Models;
using System.Linq;

namespace Library.Infrastructure.Security.Persistence
{
    public interface ISecurityPersistence
    {
        IQueryable<ApplicationUser> ApplicationUsers { get; }
    }
}

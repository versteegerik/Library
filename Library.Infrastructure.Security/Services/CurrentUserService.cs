using Library.Domain.Common;
using Library.Domain.Models;
using Library.Infrastructure.Security.Models;
using Library.Infrastructure.Security.Persistence;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Library.Infrastructure.Security.Services
{
    public class CurrentUserService
    {
        public ApplicationUser CurrentApplicationUser { get; }
        public DomainUser CurrentDomainUser => CurrentApplicationUser?.DomainUser;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, ISecurityPersistence securityPersistence, IDomainPersistence domainPersistence)
        {
            var user = httpContextAccessor.HttpContext.User;
            CurrentApplicationUser = securityPersistence.ApplicationUsers.Single(_ => _.NormalizedUserName == user.Identity.Name.ToUpper());
        }
    }
}

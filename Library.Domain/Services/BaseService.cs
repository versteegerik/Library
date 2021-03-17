using Library.Domain.Models;
using Microsoft.AspNetCore.Http;
using Versteey.Infrastructure.Persistence;
using System.Linq;
using System.Security.Claims;

namespace Library.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IPersistence Persistence;

        public BaseService(IPersistence persistence)
        {
            Persistence = persistence;
        }
    }

    public abstract class BasePersonService : BaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasePersonService(IPersistence persistence, IHttpContextAccessor httpContextAccessor) : base(persistence)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Person GetCurrentPerson()
        {
            var personClaim = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Sid);
            return Persistence.GetById<Person>(personClaim.Value);
        }
    }
}

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Library.Application.Common;
using Library.Domain.Common;
using Library.Infrastructure.Audit.Common;

namespace Library.Application.Web.Common
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IApplicationPersistence applicationPersistence, IDomainPersistence domainPersistence, IAuditPersistence auditPersistence)
        {
            // Do tasks before other middleware here, aka 'BeginRequest'
            // ...

            // Let the middleware pipeline run
            await _next(context);

            // Do tasks after middleware here, aka 'EndRequest'
            // ...
            try
            {
                await applicationPersistence.SaveChangesAsync();
                await domainPersistence.SaveChangesAsync();
            }
            finally
            {
                await auditPersistence.SaveChangesAsync();
            }
        }
    }
}

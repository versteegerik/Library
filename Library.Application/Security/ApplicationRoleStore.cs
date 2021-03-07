using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Library.Application.Security
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext, Guid>
    {
        public ApplicationRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;

namespace Library.Application.Security
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        //ApplicationUser
        public const string CreateApplicationUser = nameof(CreateApplicationUser);
        public const string UpdateApplicationUser = nameof(UpdateApplicationUser);
        public const string DeleteApplicationUser = nameof(DeleteApplicationUser);

        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}

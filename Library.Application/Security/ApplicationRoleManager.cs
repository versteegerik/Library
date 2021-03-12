using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Library.Application.Security
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole> store, IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<ApplicationRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }

        public async Task InitRoles()
        {
            foreach (var role in GetConstants(typeof(ApplicationRole)))
            {
                var roleExist = await RoleExistsAsync(role.Name);
                if (!roleExist)
                {
                    var newRole = new ApplicationRole(role.Name);
                    var roleResult = await CreateAsync(newRole);
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Could not create role: {role.Name}");
                    }
                }
            }
        }

        private List<FieldInfo> GetConstants(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.FlattenHierarchy);

            return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
        }
    }
}

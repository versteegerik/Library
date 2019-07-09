using Library.Domain.Requests;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Model
{
    public sealed class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(CreateApplicationUserRequest createApplicationUserRequest) : this()
        {
            UserName = createApplicationUserRequest.UserName;
            Email = createApplicationUserRequest.Email;
            PhoneNumber = createApplicationUserRequest.PhoneNumber;
        }
    }
}

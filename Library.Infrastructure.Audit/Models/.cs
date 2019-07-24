using Library.Domain.Models;
using Library.Infrastructure.Security.Models.Requests;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Infrastructure.Security.Models
{
    [Table("AspNetUsers")]
    public sealed class ApplicationUser : IdentityUser , DomainUser
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

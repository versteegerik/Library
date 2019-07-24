using Library.Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace Library.Infrastructure.Security.Models.Requests
{
    public class CreateApplicationUserRequest
    {
        [Display(Name = "ApplicationUser_UserName", ResourceType = typeof(DomainResources))]
        public string UserName { get; set; }
        [Display(Name = "ApplicationUser_Email", ResourceType = typeof(DomainResources))]
        public string Email { get; set; }
        [Display(Name = "ApplicationUser_PhoneNumber", ResourceType = typeof(DomainResources))]
        public string PhoneNumber { get; set; }
        [Display(Name = "ApplicationUser_Password", ResourceType = typeof(DomainResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "ApplicationUser_PasswordConfirmation", ResourceType = typeof(DomainResources))]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }

    public class EditApplicationUserRequest
    {
        public string Id { get; set; }
        [Display(Name = "ApplicationUser_Email", ResourceType = typeof(DomainResources))]
        public string Email { get; set; }
        [Display(Name = "ApplicationUser_PhoneNumber", ResourceType = typeof(DomainResources))]
        public string PhoneNumber { get; set; }

        public EditApplicationUserRequest() { }
        public EditApplicationUserRequest(ApplicationUser applicationUser)
        {
            Id = applicationUser.Id;
            Email = applicationUser.Email;
            PhoneNumber = applicationUser.PhoneNumber;            
        }
    }
}

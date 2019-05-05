using Library.Domain.Model;
using Library.Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Requests
{
    public class CreateApplicationUserRequest
    {
        [Display(Name = "ApplicationUser_UserName", ResourceType = typeof(DomainResources))]
        public string UserName { get; set; }
        [Display(Name = "ApplicationUser_Email", ResourceType = typeof(DomainResources))]
        public string Email { get; set; }
        [Display(Name = "ApplicationUser_PhoneNumber", ResourceType = typeof(DomainResources))]
        public string PhoneNumber { get; set; }
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

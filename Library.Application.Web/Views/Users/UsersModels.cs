using Library.Domain.Model;
using Library.Domain.Requests;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Web.Views.Users
{
    public class ListModel
    {
        public IEnumerable<ApplicationUserModel> ApplicationUsers { get; set; }

        public ListModel(IEnumerable<ApplicationUser> applicationUsers)
        {
            ApplicationUsers = applicationUsers.Select(au => new ApplicationUserModel(au));
        }
    }

    public class ApplicationUserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ApplicationUserModel(ApplicationUser applicationUser)
        {
            Id = applicationUser.Id;
            UserName = applicationUser.UserName;
            Email = applicationUser.Email;
            PhoneNumber = applicationUser.PhoneNumber;
        }
    }

    public class EditApplicationUserModel
    {
        public EditApplicationUserRequest Request { get; set; }
        public string UserName { get; set; }

        public EditApplicationUserModel() { }
        public EditApplicationUserModel(ApplicationUser applicationUser) : this()
        {
            UserName = applicationUser.UserName;
            Request = new EditApplicationUserRequest(applicationUser);
        }
    }
}

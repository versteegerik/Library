using Library.Domain.Model;
using Library.Domain.Requests;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class ApplicationUserService
    {
        public UserManager<ApplicationUser> _userManager { get; }

        public ApplicationUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResult> CreateUser(CreateApplicationUserRequest createApplicationUserRequest)
        {
            var user = await _userManager.FindByNameAsync(createApplicationUserRequest.UserName);
            if (user != null)
            {
                return new ServiceResult("User already exists!");
            }

            var newApplicationUser = new ApplicationUser(createApplicationUserRequest);

            var result = await _userManager.CreateAsync(newApplicationUser);
            return new ServiceResult(result);
        }

        public async Task<ServiceResult> EditUser(EditApplicationUserRequest editApplicationUserRequest)
        {
            var user = await _userManager.FindByIdAsync(editApplicationUserRequest.Id);
            if (user == null)
            {
                return new ServiceResult("User not found!");
            }
            var result = await _userManager.UpdateAsync(user);
            return new ServiceResult(result);
        }
    }
}

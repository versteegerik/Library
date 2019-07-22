using Library.Domain.Common;
using Library.Domain.Models;
using Library.Domain.Requests;
using Microsoft.AspNetCore.Identity;
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

        public async Task<ServiceResult<ApplicationUser>> CreateUser(CreateApplicationUserRequest createApplicationUserRequest, string partialCallbackUrl)
        {
            var user = await _userManager.FindByNameAsync(createApplicationUserRequest.UserName);
            if (user != null)
            {
                return new ServiceResult<ApplicationUser>("User already exists!", null);
            }

            var newApplicationUser = new ApplicationUser(createApplicationUserRequest);
            var result = await _userManager.CreateAsync(newApplicationUser, createApplicationUserRequest.Password);

            return new ServiceResult<ApplicationUser>(result, newApplicationUser);
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

        public async Task<ServiceResult> DeleteUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new ServiceResult("User not found!");
            }
            var result = await _userManager.DeleteAsync(user);
            return new ServiceResult(result);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user) => await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }
}

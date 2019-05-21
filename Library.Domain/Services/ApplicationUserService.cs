using Library.Domain.Model;
using Library.Domain.Requests;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Web;

namespace Library.Domain.Services
{
    public class ApplicationUserService
    {
        private readonly IMailService _mailService;
        public UserManager<ApplicationUser> _userManager { get; }

        public ApplicationUserService(UserManager<ApplicationUser> userManager, IMailService mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
        }

        public async Task<ServiceResult> CreateUser(CreateApplicationUserRequest createApplicationUserRequest, string partialCallbackUrl)
        {
            var user = await _userManager.FindByNameAsync(createApplicationUserRequest.UserName);
            if (user != null)
            {
                return new ServiceResult("User already exists!");
            }

            var newApplicationUser = new ApplicationUser(createApplicationUserRequest);
            var result = await _userManager.CreateAsync(newApplicationUser, createApplicationUserRequest.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(newApplicationUser);                
                var callbackUrl = $"{partialCallbackUrl}?userId={newApplicationUser.Id}&code={HttpUtility.UrlEncode(code)}";
                await _mailService.SendApplicationUserConfirmEmail(newApplicationUser, callbackUrl);
            }

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
    }
}

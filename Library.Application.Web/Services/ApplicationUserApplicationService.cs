using Library.Application.Services.MailService;
using Library.Domain.Common;
using Library.Infrastructure.Security.Models.Requests;
using Library.Infrastructure.Security.Services;
using System.Threading.Tasks;
using System.Web;

namespace Library.Application.Web.Services
{
    public class ApplicationUserApplicationService
    {
        private readonly IMailService _mailService;
        private readonly ApplicationUserService _applicationUserService;

        public ApplicationUserApplicationService(ApplicationUserService applicationUserService, IMailService mailService)
        {
            _applicationUserService = applicationUserService;
            _mailService = mailService;
        }

        public async Task<ServiceResult> CreateUser(CreateApplicationUserRequest createApplicationUserRequest, string partialCallbackUrl)
        {
            var result = await _applicationUserService.CreateUser(createApplicationUserRequest, partialCallbackUrl);
            if (result.Succeeded)
            {
                var newApplicationUser = result.Result;
                var code = await _applicationUserService.GenerateEmailConfirmationTokenAsync(newApplicationUser);                
                var callbackUrl = $"{partialCallbackUrl}?userId={newApplicationUser.Id}&code={HttpUtility.UrlEncode(code)}";
                await _mailService.SendApplicationUserConfirmEmail(newApplicationUser, callbackUrl);
            }

            return result;
        }
        
        public async Task<ServiceResult> EditUser(EditApplicationUserRequest editApplicationUserRequest) => await _applicationUserService.EditUser(editApplicationUserRequest);

        public async Task<ServiceResult> DeleteUserById(string id) => await _applicationUserService.DeleteUserById(id);
    }
}

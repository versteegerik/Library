using Library.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Application.Web.Common
{
    public abstract class ApplicationUserControllerBase : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserControllerBase(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        protected async Task<ApplicationUser> CurrentUser()  => await userManager.GetUserAsync(User);
    }
}

using Library.Infrastructure.Security.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.Web.Common
{
    public abstract class BaseController : Controller
    {
    }

    [Authorize]
    public abstract class LoggedInController: BaseController
    {
        protected CurrentUserService _currentUserService { get; }

        public LoggedInController(CurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}

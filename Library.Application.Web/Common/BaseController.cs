using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.Web.Common
{
    [Authorize]
    public abstract class BaseController : Controller
    {
    }
}

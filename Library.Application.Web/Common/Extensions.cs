using Library.Domain.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Library.Application.Web.Common
{
    public static class Extensions
    {
        public static void AddModelError(this ModelStateDictionary modelState, ServiceResult serviceResult)
        {
            foreach(var error in serviceResult.Errors)
            {
                modelState.AddModelError("", error);
            }
        }
    }
}

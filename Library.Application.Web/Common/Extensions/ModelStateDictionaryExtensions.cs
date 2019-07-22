using Library.Domain.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Library.Application.Web.Common.Extensions
{
    public static class ModelStateDictionaryExtensions
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

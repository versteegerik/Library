using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Application.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedByNamespace(this IServiceCollection services, Assembly assembly, string @namespace)
        {
            foreach (var type in assembly.GetTypesInNamespace(@namespace))
            {
                services.AddScoped(type);
            }
        }           
    }
}

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Application.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services, Assembly assembly)
        {
            foreach (var type in assembly.GetTypesInNamespace("Library.Domain.Repositories"))
            {
                services.AddScoped(type);
            }
        }
        public static void AddServices(this IServiceCollection services, Assembly assembly)
        {
            foreach (var type in assembly.GetTypesInNamespace("Library.Domain.Services"))
            {
                services.AddScoped(type);
            }
        }
    }
}

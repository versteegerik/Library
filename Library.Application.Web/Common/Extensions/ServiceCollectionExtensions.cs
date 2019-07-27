using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Library.Application.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedByNamespace(this IServiceCollection services, Assembly assembly, string @namespace, string nameEndsWith)
        {
            foreach (var type in assembly.GetTypesInNamespace(@namespace).Where(_ => _.Name.EndsWith(nameEndsWith)))
            {
                services.AddScoped(type);
            }
        }           
    }
}

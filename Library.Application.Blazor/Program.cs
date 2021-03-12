using Library.Application.Blazor.Data;
using Library.Application.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library.Application.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();

            // Create a new scope
            using (var scope = builder.Services.CreateScope())
            {
                // Get the DbContext instance
                var roleManager = scope.ServiceProvider.GetRequiredService<ApplicationRoleManager>();

                //Do the migration asynchronously
                roleManager.InitRoles().GetAwaiter().GetResult();
            }

            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

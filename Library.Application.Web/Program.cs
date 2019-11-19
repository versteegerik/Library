using Library.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Library.Application.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrWhiteSpace(environment))
            {
                throw new Exception("ASPNETCORE_ENVIRONMENT is not set");
            }
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environment}.json")
                .AddUserSecrets<Startup>()
                .Build();

            DatabaseInitialize(configuration);
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void DatabaseInitialize(IConfigurationRoot configuration)
        {
            var dbManager = new DatabaseManager(configuration.GetConnectionString("DefaultConnection"));
            dbManager.Initialize();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

using FluentValidation.AspNetCore;
using Library.Application.Blazor.Areas.Identity;
using Library.Application.Blazor.Data;
using Library.Application.Blazor.Data.NHibernateOverrides;
using Library.Application.Providers;
using Library.Application.Security;
using Library.Common.Properties;
using Library.Domain.Services;
using Library.Domain.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeterLeslieMorris.Blazor.Validation;
using System.Reflection;
using Versteey.Infrastructure.Persistence.NHibernatePersistence;

namespace Library.Application.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(BookService));
            var assemblyForOverrides = Assembly.GetAssembly(typeof(BookMap));
            services.AddMvc()
                .AddDataAnnotationsLocalization(options => { options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(Resources)); })
                .AddFluentValidation();

            services.AddRazorPages();

            services.AddServerSideBlazor();
            services.AddFormValidation(config => config.AddDataAnnotationsValidation().AddFluentValidation(typeof(CreateBookRequestValidator).Assembly));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddUserStore<ApplicationUserStore>()
                .AddUserManager<ApplicationUserManager>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddSignInManager<ApplicationSignInManager>()
                // You **cannot** use .AddEntityFrameworkStores() when you customize everything
                //.AddEntityFrameworkStores<ApplicationDbContext, int>()
                .AddDefaultTokenProviders();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
            //services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            //{
            //    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
            //    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
            //});

            services.AddNHibernate(Configuration.GetConnectionString("DefaultConnection"), assembly, assemblyForOverrides);

            //Domain Services
            services.AddTransient<AuthorService>();
            services.AddTransient<BookService>();
            services.AddTransient<PersonService>();

            //Providers
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var manager = new DatabaseManager(Configuration.GetConnectionString("DefaultConnection"));
            manager.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

using FeedbackApp.Web.Views.Shared.DataTables;
using FluentValidation.AspNetCore;
using Library.Application.Common;
using Library.Application.Models.Requests.Validators;
using Library.Application.Persistence;
using Library.Application.Services;
using Library.Application.Services.MailService;
using Library.Application.Web.Common;
using Library.Application.Web.Common.Extensions;
using Library.Application.Web.Services;
using Library.Domain.Common;
using Library.Domain.Models.Requests.Validators;
using Library.Domain.Services;
using Library.Infrastructure.Audit.Common;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Persistence;
using Library.Infrastructure.Security.Models;
using Library.Infrastructure.Security.Models.Requests.Validators;
using Library.Infrastructure.Security.Persistence;
using Library.Infrastructure.Security.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScopedByNamespace(typeof(NewsMessageService).Assembly, "Library.Application.Services", "Service");
            services.AddScopedByNamespace(typeof(BookService).Assembly, "Library.Domain.Services", "Service");
            services.AddScopedByNamespace(typeof(ApplicationUserService).Assembly, "Library.Infrastructure.Security.Services", "Service");
            services.AddScopedByNamespace(typeof(ApplicationUserApplicationService).Assembly, "Library.Application.Web.Services", "ApplicationService");

            services.AddDbContext<IApplicationPersistence, ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IAuditPersistence, AuditDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IDomainPersistence, DomainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ISecurityPersistence, SecurityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            ConfigureSecurity(services);

            services.Configure<MailServiceSettings>(Configuration.GetSection("MailServiceSettings"));
            services.AddScoped<IMailService, MailService>();
            //services.AddHttpContextAccessor();

            AddMvc(services);
        }

        private static void AddMvc(IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateNewsMessageRequestValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<CreateBookRequestValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<CreateApplicationUserRequestValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<DataTablesViewModelValidator>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private void ConfigureSecurity(IServiceCollection services)
        {
            services.AddDbContext<SecurityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<SecurityDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UseErrorHandling(app, env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMiddleware<RequestMiddleware>();
            UseMvc(app);
        }

        private static void UseErrorHandling(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Release"))
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
        }

        private static void UseMvc(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}

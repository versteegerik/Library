using FluentValidation.AspNetCore;
using Library.Application.Services.MailService;
using Library.Domain.Model;
using Library.Domain.Repositories;
using Library.Domain.Services;
using Library.Domain.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            AddServices(services);
            AddRepositories(services);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<SecurityStampValidatorOptions>(config =>
            {
                config.ValidationInterval = TimeSpan.FromMinutes(1);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton<IEmailSender, MailService>();
            services.AddSingleton<IMailService, MailService>(x => (MailService)x.GetService<IEmailSender>());
            services.AddHttpContextAccessor();
            services.Configure<MailServiceSettings>(Configuration.GetSection("MailServiceSettings"));

            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateBookRequestValidator>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<BookService>();
            services.AddScoped<NewsMessageService>();

        }
        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<BookRepository>();
            services.AddScoped<NewsMessageRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}");
            });
        }
    }
}

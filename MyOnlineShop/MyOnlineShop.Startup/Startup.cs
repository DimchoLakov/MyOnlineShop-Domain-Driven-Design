namespace MyOnlineShop.Startup
{
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MyOnlineShop.Application;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Domain;
    using MyOnlineShop.Infrastructure;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDomain()
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddDatabaseDeveloperPageExceptionFilter()
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddRazorPages();

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();
            //.AddWeb();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app
                //.UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapRazorPages();
                })
                .Initialize();
        }
    }
}

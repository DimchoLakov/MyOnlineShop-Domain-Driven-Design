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
    using MyOnlineShop.Startup.Middlewares;
    using MyOnlineShop.Startup.Services;
    using System.Net;
    using System.Threading.Tasks;

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
                .AddScoped<ICurrentToken, CurrentTokenService>()
                .AddTransient<JwtCookieAuthenticationMiddleware>()
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
                .UseMiddleware<ValidationExceptionHandlerMiddleware>()
                .UseStatusCodePages(async context =>
                await Task.Run(() =>
                {
                    var request = context.HttpContext.Request;
                    var response = context.HttpContext.Response;

                    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                    {
                        response.Redirect($"/Identity/Login?returnUrl={request.Path}");
                    }

                    if (response.StatusCode == (int)HttpStatusCode.NotFound)
                    {
                        response.Redirect($"/Home/Error/?statusCode={response.StatusCode}");
                    }
                }))
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseMiddleware<JwtCookieAuthenticationMiddleware>()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapRazorPages();
                })
                .Initialize();
        }
    }
}

namespace MyOnlineShop.Web
{
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Web.Controllers;
    using MyOnlineShop.Web.Middlewares;
    using MyOnlineShop.Web.Services;
    using System.IO;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWeb(
            this IServiceCollection services,
            IWebHostEnvironment webHostEnvironment)
        {
            services
                .AddDatabaseDeveloperPageExceptionFilter()
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddScoped<ICurrentToken, CurrentTokenService>()
                .AddTransient<JwtCookieAuthenticationMiddleware>()
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddRazorPages();

            var assembly = typeof(HomeController).Assembly;

            services
                .AddControllersWithViews()
                .AddApplicationPart(assembly)
                .AddRazorRuntimeCompilation(options => 
                {
                    var webAssemblyPath = Path.GetFullPath(Path.Combine(webHostEnvironment.ContentRootPath, "..", "MyOnlineShop.Web"));
                    options.FileProviders.Add(new PhysicalFileProvider(webAssemblyPath));
                })
                .AddNewtonsoftJson();

            return services;
        }
    }
}

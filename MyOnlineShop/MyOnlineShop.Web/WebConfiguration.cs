namespace MyOnlineShop.Web
{
    using FluentValidation.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Web.Controllers;
    using MyOnlineShop.Web.Middlewares;
    using MyOnlineShop.Web.Services;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
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
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson();

            return services;
        }
    }
}

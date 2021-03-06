namespace MyOnlineShop.Application
{
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyOnlineShop.Application.Common;
    using System.Reflection;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .Configure<ApplicationSettings>(
                    configuration.GetSection(nameof(ApplicationSettings)),
                    builder => builder.BindNonPublicProperties = true)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddEventHandlers();

            return services;
        }

        private static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            services
                .Scan(scan => scan.FromCallingAssembly()
                                  .AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
                                  .AsImplementedInterfaces()
                                  .WithTransientLifetime());

            return services;
        }
    }
}

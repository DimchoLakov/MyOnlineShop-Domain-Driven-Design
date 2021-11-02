namespace MyOnlineShop.Domain
{
    using Microsoft.Extensions.DependencyInjection;

    using MyOnlineShop.Domain.Common;

    public static class DomainConfiguration
    {

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services
                .AddFactories()
                .AddInitialData();
        }

        private static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services
                .Scan(scan => scan.FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IFactory<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());

            return services;
        }

        private static IServiceCollection AddInitialData(this IServiceCollection services)
        {
            services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IInitialData)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return services;
        }
    }
}

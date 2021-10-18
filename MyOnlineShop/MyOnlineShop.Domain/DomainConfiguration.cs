namespace MyOnlineShop.Domain
{
    using Microsoft.Extensions.DependencyInjection;
    
    using MyOnlineShop.Domain.Common;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services
                .Scan(scan => scan.FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IFactory<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());

            return services;
        }
    }
}

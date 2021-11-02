namespace MyOnlineShop.Infrastructure
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Identity;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Infrastructure.Catalog;
    using MyOnlineShop.Infrastructure.Common;
    using MyOnlineShop.Infrastructure.Common.Events;
    using MyOnlineShop.Infrastructure.Common.Persistance;
    using MyOnlineShop.Infrastructure.Identity;
    using System.Text;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddDatabase(configuration)
                .AddIdentity(configuration)
                .AddRepositories()
                .AddTransient<IEventDispatcher, EventDispatcher>();

            return services;
        }

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddDbContext<MyOnlineShopDbContext>(config =>
                {
                    config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(MyOnlineShopDbContext).Assembly.FullName));
                })
                .AddScoped<ICatalogDbContext>(provider => provider.GetRequiredService<MyOnlineShopDbContext>())
                .AddTransient<IInitializer, DatabaseInitializer>()
                .AddTransient<IDataSeeder, IdentityDataSeeder>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                  .Scan(scan => scan
                      .FromCallingAssembly()
                      .AddClasses(classes => classes
                          .AssignableTo(typeof(IDomainRepository<>))
                          .AssignableTo(typeof(IQueryRepository<>)))
                      .AsImplementedInterfaces()
                      .WithTransientLifetime());

            return services;
        }

        private static IServiceCollection AddIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<MyOnlineShopDbContext>();

            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddHttpContextAccessor();
            services.AddTransient<IIdentity, IdentityService>();
            services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();

            return services;
        }
    }
}

namespace MyOnlineShop.Startup
{
    using Infrastructure.Common;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using MyOnlineShop.Domain.Common;
    using System.IO;

    public static class ApplicationInitialization
    {
        public static IApplicationBuilder UseStaticFilesFromWebAssembly(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            string pathToWwwRootInWebAssembly = Path.GetFullPath(Path.Combine(env.ContentRootPath, "..", "MyOnlineShop.Web", "wwwroot"));

            return app.UseStaticFiles(
                new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(pathToWwwRootInWebAssembly)
                });
        }

        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IInitializer>();

            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            var dataSeeders = serviceScope.ServiceProvider.GetServices<IDataSeeder>();

            foreach (var seeder in dataSeeders)
            {
                seeder.SeedData();
            }

            return app;
        }
    }
}

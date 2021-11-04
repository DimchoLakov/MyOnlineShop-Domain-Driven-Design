namespace MyOnlineShop.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.FileProviders;
    using MyOnlineShop.Web;
    using System.IO;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseStaticFilesFromWebAssembly(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            string solutionPath = env.ContentRootPath.Substring(0, env.ContentRootPath.LastIndexOf(@"\") + 1);

            string webAssemblyFullName = typeof(WebConfiguration).Assembly.ManifestModule.Name;
            webAssemblyFullName = webAssemblyFullName.Substring(0, webAssemblyFullName.LastIndexOf("."));

            string fullPathToWebWwwRoot = Path.Combine(solutionPath, webAssemblyFullName, "wwwroot");

            return app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fullPathToWebWwwRoot)
            });
        }
    }
}

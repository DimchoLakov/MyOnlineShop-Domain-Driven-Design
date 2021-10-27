namespace MyOnlineShop.Infrastructure.Catalog
{
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Infrastructure.Common.Persistance;

    internal interface ICatalogDbContext : IDbContext
    {
        DbSet<Product> Products { get; }

        DbSet<ProductOption> ProductOptions { get; }

        DbSet<Category> Categories { get; }
    }
}

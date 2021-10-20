namespace MyOnlineShop.Application.Catalog.Products.Queries.Common
{
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Catalog.Models.Products;

    public class ProductOutputModel : IMapFrom<Product>
    {
        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;
        
        public decimal Price { get; private set; }

        public string Code { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;
    }
}

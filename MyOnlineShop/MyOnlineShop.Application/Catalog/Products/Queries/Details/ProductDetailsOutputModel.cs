namespace MyOnlineShop.Application.Catalog.Products.Queries.Details
{
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using System;

    public class ProductDetailsOutputModel : IMapFrom<Product>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public decimal Price { get; private set; }

        public double Weight { get; private set; }

        public string Code { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public int StockAvailable { get; private set; }

        public int MaxStock { get; private set; }

        public bool IsOnSale { get; private set; }

        public bool IsArchived { get; private set; }

        public ProductType Type { get; private set; } = default!;

        public DateTime DateCreated { get; private set; }

        public DateTime? DateUpdated { get; private set; }
    }
}

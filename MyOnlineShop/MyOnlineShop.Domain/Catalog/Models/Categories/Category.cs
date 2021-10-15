namespace MyOnlineShop.Domain.Catalog.Models.Categories
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;

    using System.Collections.Generic;

    public class Category : Entity<int>, IAggregateRoot
    {
        private readonly List<Product> products;

        internal Category(
            string name,
            string imageUrl,
            int order,
            bool isActive = true)
        {
            this.Name = name;
            this.ImageUrl = imageUrl;
            this.Order = order;
            this.IsActive = isActive;

            this.products = new List<Product>();
        }

        public string Name { get; private set; }

        public string ImageUrl { get; private set; }

        public int Order { get; private set; }

        public bool IsActive { get; private set; }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
    }
}

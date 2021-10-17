namespace MyOnlineShop.Domain.Catalog.Models.Categories
{
    using MyOnlineShop.Domain.Catalog.Exceptions.Categories;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Common.Models;

    using System.Collections.Generic;

    using static ModelConstants.Category;

    public class Category : Entity<int>, IAggregateRoot
    {
        private readonly List<Product> products;

        internal Category(
            string name,
            string imageUrl,
            int order,
            bool isActive = true)
        {
            this.Validate(name, imageUrl, order);

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

        private void Validate(string name, string imageUrl, int order)
        {
            this.ValidateName(name);
            this.ValidateImageUrl(imageUrl);
            this.ValidateOrder(order);
        }

        private void ValidateOrder(int order)
        {
            Guard.AgainstOutOfRange<InvalidCategoryException>(order, OrderMin, OrderMax, nameof(this.Order));
        }

        private void ValidateImageUrl(string imageUrl)
        {
            Guard.ForValidUrl<InvalidCategoryException>(imageUrl, nameof(this.ImageUrl));
        }

        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidCategoryException>(name, NameMinLength, NameMaxLength, nameof(this.Name));
        }
    }
}

namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Catalog.Exceptions.Products;
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Common.Models;

    using System;
    using System.Collections.Generic;

    using static ModelConstants.Product;

    public class Product : Entity<int>, IAggregateRoot
    {
        private readonly List<Category> categories;

        internal Product(
            string name,
            string description,
            decimal price,
            double weight,
            string code,
            string imageUrl,
            int stockAvailable,
            int maxStock,
            ProductType type,
            bool isOnSale = false,
            bool isArchived = false)
        {
            this.Validate(
                name,
                description,
                price,
                weight,
                code,
                imageUrl,
                stockAvailable,
                maxStock);

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Weight = weight;
            this.Code = code;
            this.ImageUrl = imageUrl;
            this.StockAvailable = stockAvailable;
            this.MaxStock = maxStock;
            this.Type = type;
            this.IsOnSale = isOnSale;
            this.IsArchived = isArchived;

            this.DateCreated = DateTime.Now;

            this.categories = new List<Category>();
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public double Weight { get; private set; }

        public string Code { get; private set; }

        public string ImageUrl { get; private set; }

        public int StockAvailable { get; private set; }

        public int MaxStock { get; private set; }

        public bool IsOnSale { get; private set; }

        public bool IsArchived { get; private set; }

        public ProductType Type { get; private set; }

        public DateTime DateCreated { get; private set; }

        public DateTime? DateUpdated { get; private set; }

        public IReadOnlyCollection<Category> Categories => this.categories.AsReadOnly();

        private void Validate(
            string name,
            string description,
            decimal price,
            double weight,
            string code,
            string imageUrl,
            int stockAvailable,
            int maxStock)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
            this.ValidatePrice(price);
            this.ValidateWeight(weight);
            this.ValidateCode(code);
            this.ValidateImageUrl(imageUrl);
            this.ValidateStockAvailable(stockAvailable);
            this.ValidateMaxStock(maxStock);
        }

        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidProductException>(name, NameMinLength, NameMaxLength, nameof(this.Name));
        }

        private void ValidateDescription(string description)
        {
            Guard.ForStringLength<InvalidProductException>(description, DescriptionMinLength, DescriptionMaxLength, nameof(this.Description));
        }

        private void ValidatePrice(decimal price)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(price, MinPrice, MaxPrice, nameof(this.Price));
        }

        private void ValidateWeight(double weight)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(weight, MinWeight, MaxWeight, nameof(this.Weight));
        }

        private void ValidateCode(string code)
        {
            Guard.ForStringLength<InvalidProductException>(code, MinCodeLength, MaxCodeLength, nameof(this.Code));
        }

        private void ValidateImageUrl(string imageUrl)
        {
            Guard.ForValidUrl<InvalidProductException>(imageUrl, nameof(this.ImageUrl));
        }

        private void ValidateStockAvailable(int stockAvailable)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(stockAvailable, MinStockAvailable, MaxStockAvailable, nameof(this.StockAvailable));
        }

        private void ValidateMaxStock(int maxStock)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(maxStock, MinStock, MaxStock, nameof(this.MaxStock));
        }
    }
}

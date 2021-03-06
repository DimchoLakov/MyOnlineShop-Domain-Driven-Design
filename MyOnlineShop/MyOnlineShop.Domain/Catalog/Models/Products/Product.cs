namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Catalog.Events;
    using MyOnlineShop.Domain.Catalog.Exceptions.Products;
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Domain.Common.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Product : Entity<int>, IAggregateRoot
    {
        private readonly List<Category> categories;
        private readonly List<ProductOption> options;

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
                maxStock,
                type);

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
            this.options = new List<ProductOption>();
        }

        private Product(
            string name,
            string description,
            decimal price,
            double weight,
            string code,
            string imageUrl,
            int stockAvailable,
            int maxStock,
            bool isOnSale = false,
            bool isArchived = false)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Weight = weight;
            this.Code = code;
            this.ImageUrl = imageUrl;
            this.StockAvailable = stockAvailable;
            this.MaxStock = maxStock;
            this.IsOnSale = isOnSale;
            this.IsArchived = isArchived;

            this.Type = ProductType.General;

            this.DateCreated = DateTime.Now;

            this.categories = new List<Category>();
            this.options = new List<ProductOption>();
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

        public IReadOnlyCollection<ProductOption> Options => this.options.AsReadOnly();

        private void Validate(
            string name,
            string description,
            decimal price,
            double weight,
            string code,
            string imageUrl,
            int stockAvailable,
            int maxStock,
            ProductType type)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
            this.ValidatePrice(price);
            this.ValidateWeight(weight);
            this.ValidateCode(code);
            this.ValidateImageUrl(imageUrl);
            this.ValidateStockAvailable(stockAvailable);
            this.ValidateMaxStock(maxStock);
            this.ValidateType(type);
        }

        public Product AddCategory(Category category)
        {
            this.categories.Add(category);

            return this;
        }

        public Product RemoveCategory(Category category)
        {
            this.categories.Remove(category);

            return this;
        }

        public Product AddOption(string name, decimal? price)
        {
            this.options.Add(new ProductOption(name, price));

            return this;
        }

        public Product RemoveOption(ProductOption option)
        {
            this.options.Remove(option);

            return this;
        }

        public ProductOption GetOption(string name)
        {
            return this.options
                .First(o => o.Name == name);
        }

        public ProductOption GetOption(int optionId)
        {
            return this.options
                .First(o => o.Id == optionId);
        }

        public Product UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            this.DateUpdated = DateTime.Now;

            this.RaiseEvent(new ProductNameUpdatedEvent(this.Id, this.Name));

            return this;
        }

        public Product UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            this.DateUpdated = DateTime.Now;

            this.RaiseEvent(new ProductDescriptionUpdatedEvent(this.Id, this.Description));

            return this;
        }

        public Product UpdatePrice(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;

            this.DateUpdated = DateTime.Now;

            this.RaiseEvent(new ProductPriceUpdatedEvent(this.Id, this.Price));

            return this;
        }

        public Product UpdateWeight(double weight)
        {
            this.ValidateWeight(weight);
            this.Weight = weight;

            this.DateUpdated = DateTime.Now;

            this.RaiseEvent(new ProductWeightUpdatedEvent(this.Id, this.Weight));

            return this;
        }

        public Product UpdateCode(string code)
        {
            this.ValidateCode(code);
            this.Code = code;

            this.DateUpdated = DateTime.Now;

            return this;
        }

        public Product UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;

            this.DateUpdated = DateTime.Now;

            this.RaiseEvent(new ProductImageUrlUpdatedEvent(this.Id, this.ImageUrl));

            return this;
        }

        public Product UpdateStockAvailable(int stockAvailable)
        {
            this.ValidateStockAvailable(stockAvailable);
            this.StockAvailable = stockAvailable;

            this.DateUpdated = DateTime.Now;

            return this;
        }

        public Product UpdateMaxStock(int maxStock)
        {
            this.ValidateMaxStock(maxStock);
            this.MaxStock = maxStock;

            this.DateUpdated = DateTime.Now;

            return this;
        }

        public Product UpdateType(ProductType type)
        {
            this.Type = type;

            this.DateUpdated = DateTime.Now;

            return this;
        }

        public Product UpdateType(int typeValue)
        {
            this.Type = Enumeration.FromValue<ProductType>(typeValue);

            this.DateUpdated = DateTime.Now;

            return this;
        }

        public Product UpdateIsOnSale(bool isOnSale)
        {
            this.IsOnSale = isOnSale;

            this.DateUpdated = DateTime.Now;

            return this;
        }

        public Product UpdateIsArchived(bool isArchived)
        {
            this.IsArchived = isArchived;

            this.DateUpdated = DateTime.Now;

            return this;
        }

        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidProductException>(name, ModelConstants.Product.NameMinLength, ModelConstants.Product.NameMaxLength, nameof(this.Name));
        }

        private void ValidateDescription(string description)
        {
            Guard.ForStringLength<InvalidProductException>(description, ModelConstants.Product.DescriptionMinLength, ModelConstants.Product.DescriptionMaxLength, nameof(this.Description));
        }

        private void ValidatePrice(decimal price)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(price, ModelConstants.Product.MinPrice, ModelConstants.Product.MaxPrice, nameof(this.Price));
        }

        private void ValidateWeight(double weight)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(weight, ModelConstants.Product.MinWeight, ModelConstants.Product.MaxWeight, nameof(this.Weight));
        }

        private void ValidateCode(string code)
        {
            Guard.ForStringLength<InvalidProductException>(code, ModelConstants.Product.MinCodeLength, ModelConstants.Product.MaxCodeLength, nameof(this.Code));
        }

        private void ValidateImageUrl(string imageUrl)
        {
            Guard.ForValidUrl<InvalidProductException>(imageUrl, nameof(this.ImageUrl));
        }

        private void ValidateStockAvailable(int stockAvailable)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(stockAvailable, ModelConstants.Product.MinStockAvailable, ModelConstants.Product.MaxStockAvailable, nameof(this.StockAvailable));
        }

        private void ValidateMaxStock(int maxStock)
        {
            Guard.AgainstOutOfRange<InvalidProductException>(maxStock, ModelConstants.Product.MinStock, ModelConstants.Product.MaxStock, nameof(this.MaxStock));
        }

        private void ValidateType(ProductType type)
        {
            Guard.AgainstNull<InvalidProductException, ProductType>(type, nameof(this.Type));
        }
    }
}

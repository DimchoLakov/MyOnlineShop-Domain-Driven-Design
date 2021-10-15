namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Common;

    using System;
    using System.Collections.Generic;

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
    }
}

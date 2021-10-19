namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Catalog.Exceptions.Products;
    using MyOnlineShop.Domain.Common.Models;

    using static ModelConstants.ProductOption;

    public class ProductOption : Entity<int>
    {
        internal ProductOption(
            string name,
            decimal? price)
        {
            this.ValidateName(name);
            this.ValidatePrice(price);

            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }

        public decimal? Price { get; private set; }

        public ProductOption UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }

        public ProductOption UpdatePrice(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;

            return this;
        }

        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidProductOptionException>(name, NameMinLength, NameMaxLength, nameof(this.Name));
        }

        private void ValidatePrice(decimal? price)
        {
            if (price != null)
            {
                Guard.AgainstOutOfRange<InvalidProductOptionException>(price.Value, MinPrice, MaxPrice, nameof(this.Price));
            }
        }
    }
}

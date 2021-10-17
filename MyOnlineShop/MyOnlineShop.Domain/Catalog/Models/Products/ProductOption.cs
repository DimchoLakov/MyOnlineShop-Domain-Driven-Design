namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Catalog.Exceptions.Products;
    using MyOnlineShop.Domain.Common.Models;

    using static ModelConstants.ProductOption;

    public class ProductOption : Entity<int>
    {
        public ProductOption(
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

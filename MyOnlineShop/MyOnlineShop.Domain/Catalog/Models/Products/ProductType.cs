namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Common.Models;

    public class ProductType : Enumeration
    {
        public static readonly ProductType Fashion = new ProductType(1, nameof(Fashion));
        public static readonly ProductType Electronics = new ProductType(2, nameof(Electronics));
        public static readonly ProductType Toys = new ProductType(3, nameof(Toys));
        public static readonly ProductType Food = new ProductType(4, nameof(Food));
        public static readonly ProductType Appliances = new ProductType(5, nameof(Appliances));

        private ProductType(int value, string name) : base(value, name)
        {
        }
    }
}

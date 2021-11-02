namespace MyOnlineShop.Domain.Catalog.Models.Products
{
    using MyOnlineShop.Domain.Common.Models;

    public class ProductType : Enumeration
    {
        public static readonly ProductType General = new ProductType(1, nameof(General));
        public static readonly ProductType Fashion = new ProductType(2, nameof(Fashion));
        public static readonly ProductType Electronics = new ProductType(3, nameof(Electronics));
        public static readonly ProductType Toys = new ProductType(4, nameof(Toys));
        public static readonly ProductType Food = new ProductType(5, nameof(Food));
        public static readonly ProductType Appliances = new ProductType(6, nameof(Appliances));
        public static readonly ProductType Vehicles = new ProductType(7, nameof(Vehicles));

        private ProductType(int value)
            : this(value, FromValue<ProductType>(value).Name)
        {
        }

        private ProductType(int value, string name) 
            : base(value, name)
        {
        }
    }
}

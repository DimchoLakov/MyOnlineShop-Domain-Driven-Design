namespace MyOnlineShop.Domain.Catalog.Models
{
    public class ModelConstants
    {
        public class Category
        {
            public const int OrderMin = 1;
            public const int OrderMax = int.MaxValue;
            public const int NameMinLength = 1;
            public const int NameMaxLength = byte.MaxValue;
        }

        public class Product
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 2048;
            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = ushort.MaxValue;
            public const decimal MinPrice = 0m;
            public const decimal MaxPrice = decimal.MaxValue;
            public const double MinWeight = 0d;
            public const double MaxWeight = double.MaxValue;
            public const int MinCodeLength = 8;
            public const int MaxCodeLength = 8;
            public const int MinStockAvailable = 0;
            public const int MaxStockAvailable = int.MaxValue;
            public const int MinStock = 0;
            public const int MaxStock = int.MaxValue;
            public const int MinProductType = 1;
            public const int MaxProductType = 7;
        }

        public class ProductOption
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = byte.MaxValue;
            public const decimal MinPrice = 0m;
            public const decimal MaxPrice = decimal.MaxValue;
        }
    }
}

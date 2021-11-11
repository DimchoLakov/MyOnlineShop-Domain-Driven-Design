namespace MyOnlineShop.Domain.Shopping.Models
{
    public class ModelConstants
    {
        public class ShoppingCartItem
        {
            public const int ProductNameMinLength = 1;
            public const int ProductNameMaxLength = 2048;
            public const int ProductDescriptionMinLength = 1;
            public const int ProductDescriptionMaxLength = ushort.MaxValue;
            public const decimal MinProductPrice = 0m;
            public const decimal MaxProductPrice = decimal.MaxValue;
            public const double MinProductWeight = 0d;
            public const double MaxProductWeight = double.MaxValue;
        }
    }
}

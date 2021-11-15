namespace MyOnlineShop.Domain.Ordering.Models
{
    public class ModelConstants
    {
        public class Address
        {
            public const int MinAddressLineLength = 1;
            public const int MaxAddressLineLength = 1024;
            public const int MinPostCodeLength = 1;
            public const int MaxPostCodeLength = 32;
            public const int MinTownLength = 1;
            public const int MaxTownLength = 128;
            public const int MinCountryLength = 1;
            public const int MaxCountryLength = 128;
        }

        public class OrderItem
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 2048;
            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = ushort.MaxValue;
            public const decimal MinProductPrice = 0m;
            public const decimal MaxProductPrice = decimal.MaxValue;
            public const int MinQuantity = 1;
            public const int MaxQuantity = int.MaxValue;
        }
    }
}

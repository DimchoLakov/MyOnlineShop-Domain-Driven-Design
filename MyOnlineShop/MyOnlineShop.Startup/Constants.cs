namespace MyOnlineShop.Startup
{
    public class Constants
    {
        public const string HomeUrl = "/";

        public class Authentication
        {
            public const string CookieName = "Authentication";
        }

        public class Authorization
        {
            public const string AuthorizationHeaderName = "Authorization";

            public const string JwtAuthorizationHeaderValuePrefix = "Bearer";
        }

        public class Roles
        {
            public const string AdministratorRoleName = "Administrator";
        }

        public class Areas
        {
            public const string AdminAreaName = "Admin";
        }

        public class Products
        {
            public const string NotFoundMessage = "Product not found!";
        }

        public class ControllerViewData
        {
            public const string FromPageKey = "FromPage";
            public const string ProductNameKey = "Name";
            public const string ProductDescriptionKey = "Description";
            public const string ProductMinPriceKey = "MinPrice";
            public const string ProductMaxPriceKey = "MaxPrice";
        }
    }
}

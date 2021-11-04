namespace MyOnlineShop.Web
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
    }
}

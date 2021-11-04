namespace MyOnlineShop.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using MyOnlineShop.Web.Services;
    using System.Threading.Tasks;
    using static Constants;

    public class JwtCookieAuthenticationMiddleware : IMiddleware
    {
        private readonly ICurrentToken currentToken;

        public JwtCookieAuthenticationMiddleware(ICurrentToken token)
        {
            this.currentToken = token;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
         {
            string token = context
                .Request
                .Cookies[Authentication.CookieName];

            if (!string.IsNullOrWhiteSpace(token))
            {
                this.currentToken.Set(token);

                context
                    .Request
                    .Headers
                    .Append(Authorization.AuthorizationHeaderName, $"{Authorization.JwtAuthorizationHeaderValuePrefix} {token}");
            }

            await next.Invoke(context);
        }
    }
}

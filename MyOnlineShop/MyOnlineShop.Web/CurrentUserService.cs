namespace MyOnlineShop.Web
{
    using Microsoft.AspNetCore.Http;
    using MyOnlineShop.Application.Common.Contracts;
    using System;
    using System.Security.Claims;
    using static Constants;

    public class CurrentUserService : ICurrentUser
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = this.user.FindFirstValue(ClaimTypes.NameIdentifier);
            this.Username = this.user.FindFirstValue(ClaimTypes.Email);
            this.IsAdministrator = this.user.IsInRole(Roles.AdministratorRoleName);
        }

        public string UserId { get; }

        public string Username { get; }

        public bool IsAdministrator { get; }
    }
}
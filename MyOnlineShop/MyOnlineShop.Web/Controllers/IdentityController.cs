namespace MyOnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Identity.Commands.CreateUser;
    using MyOnlineShop.Application.Identity.Commands.LoginUser;
    using System;
    using System.Threading.Tasks;
    using static MyOnlineShop.Web.Constants;

    public class IdentityController : BaseController
    {
        public IActionResult Login()
        {
            return View(new LoginUserCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand, string returnUrl = "")
        {
            var result = await this.Mediator.Send(loginUserCommand);
            if (!result.Succeeded)
            {
                this.ModelState.AddModelError(string.Empty, string.Join(Environment.NewLine, result.Errors));
                return this.View(loginUserCommand);
            }

            string token = result.Data;

            this.Response
                .Cookies
                .Append(
                    Authentication.CookieName,
                    token,
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        MaxAge = TimeSpan.FromDays(1)
                    });

            if (!string.IsNullOrWhiteSpace(returnUrl) &&
                Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.Redirect(HomeUrl);
        }

        public IActionResult Register()
        {
            return View(new CreateUserCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommand createUserCommand, string returnUrl = "")
        {
            var result = await this.Mediator.Send(createUserCommand);
            if (!result.Succeeded)
            {
                this.ModelState.AddModelError(string.Empty, string.Join(Environment.NewLine, result.Errors));
                return this.View(createUserCommand);
            }

            if (!string.IsNullOrWhiteSpace(returnUrl) &&
                Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.Redirect(HomeUrl);
        }

        public IActionResult Logout()
        {
            this.Response
                .Cookies
                .Delete(Authentication.CookieName);

            return this.Redirect(HomeUrl);
        }
    }
}

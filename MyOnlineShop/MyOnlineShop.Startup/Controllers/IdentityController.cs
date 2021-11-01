namespace MyOnlineShop.Startup.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Identity.Commands.CreateUser;
    using MyOnlineShop.Application.Identity.Commands.LoginUser;
    using System;
    using System.Threading.Tasks;
    using static MyOnlineShop.Startup.Constants;

    public class IdentityController : BaseController
    {
        public IActionResult Login()
        {
            return View(new LoginUserCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            var result = await this.Mediator.Send(loginUserCommand);
            if (!result.Succeeded)
            {
                this.ModelState.AddModelError(string.Empty, string.Join(Environment.NewLine, result.Errors));
                return this.View(loginUserCommand);
            }

            return this.Redirect(HomeUrl);
        }

        public IActionResult Register()
        {
            return View(new CreateUserCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommand createUserCommand)
        {
            var result = await this.Mediator.Send(createUserCommand);
            if (!result.Succeeded)
            {
                this.ModelState.AddModelError(string.Empty, string.Join(Environment.NewLine, result.Errors));
                return this.View(createUserCommand);
            }

            return this.Redirect(HomeUrl);
        }
    }
}

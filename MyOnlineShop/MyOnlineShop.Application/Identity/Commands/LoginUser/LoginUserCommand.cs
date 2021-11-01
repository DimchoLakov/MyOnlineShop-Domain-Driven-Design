namespace MyOnlineShop.Application.Identity.Commands.LoginUser
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using System.ComponentModel.DataAnnotations;

    public class LoginUserCommand : UserInputModel, IRequest<Result<string>>
    {
        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}

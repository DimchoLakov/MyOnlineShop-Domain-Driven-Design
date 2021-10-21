namespace MyOnlineShop.Application.Identity.Commands.LoginUser
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class LoginUserCommand : UserInputModel, IRequest<Result>
    {
    }
}

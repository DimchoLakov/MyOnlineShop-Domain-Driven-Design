namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class CreateUserCommand : CreateUserInputModel, IRequest<Result>
    {
    }
}

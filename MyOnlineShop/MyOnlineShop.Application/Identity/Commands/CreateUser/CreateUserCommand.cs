namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string ConfirmPassword { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;
    }
}

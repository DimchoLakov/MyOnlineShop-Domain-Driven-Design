namespace MyOnlineShop.Application.Identity.Commands.ChangePassword
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class ChangePasswordCommand : IRequest<Result>
    {
        public string CurrentPassword { get; set; } = default!;

        public string NewPassword { get; set; } = default!;
    }
}

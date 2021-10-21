namespace MyOnlineShop.Application.Identity.Commands.LoginUser
{
    using FluentValidation;
    using static Constants.User;

    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .MinimumLength(EmailMinLength)
                .MaximumLength(EmailMaxLength)
                .EmailAddress()
                .NotEmpty();

            RuleFor(u => u.Password)
                .MinimumLength(PasswordMinLength)
                .MaximumLength(PasswordMaxLength)
                .NotEmpty();
        }
    }
}

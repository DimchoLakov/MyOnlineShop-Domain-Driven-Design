namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    using FluentValidation;
    using static Constants.User;

    public class LoginUserCommandValidator : AbstractValidator<CreateUserCommand>
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

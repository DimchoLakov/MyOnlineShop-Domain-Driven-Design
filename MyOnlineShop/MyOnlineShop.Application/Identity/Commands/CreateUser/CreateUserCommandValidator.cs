namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    using FluentValidation;
    using static Constants.User;
    using static Domain.Identity.ModelConstants.User;

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

            RuleFor(u => u.ConfirmPassword)
                .MinimumLength(PasswordMinLength)
                .MaximumLength(PasswordMaxLength)
                .NotEmpty();

            RuleFor(u => u.Password)
                .Equal(u => u.ConfirmPassword);

            RuleFor(u => u.FirstName)
                .MinimumLength(FirstNameMinLength)
                .MaximumLength(FirstNameMaxLength)
                .NotEmpty();

            RuleFor(u => u.LastName)
                .MinimumLength(LastNameMinLength)
                .MaximumLength(LastNameMaxLength)
                .NotEmpty();
        }
    }
}

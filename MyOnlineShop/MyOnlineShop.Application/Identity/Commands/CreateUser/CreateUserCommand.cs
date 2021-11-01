namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using System.ComponentModel.DataAnnotations;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = default!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = default!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = default!;
    }
}

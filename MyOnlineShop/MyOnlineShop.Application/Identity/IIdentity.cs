namespace MyOnlineShop.Application.Identity
{
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Identity.Commands;
    using MyOnlineShop.Application.Identity.Commands.ChangePassword;
    using MyOnlineShop.Application.Identity.Commands.CreateUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result> Register(CreateUserCommand userInput);

        Task<Result<string>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}

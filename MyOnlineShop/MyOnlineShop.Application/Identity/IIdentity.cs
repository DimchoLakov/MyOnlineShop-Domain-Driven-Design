namespace MyOnlineShop.Application.Identity
{
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Identity.Commands;
    using MyOnlineShop.Application.Identity.Commands.ChangePassword;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}

namespace MyOnlineShop.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Identity;
    using MyOnlineShop.Application.Identity.Commands;
    using MyOnlineShop.Application.Identity.Commands.ChangePassword;
    using MyOnlineShop.Application.Identity.Commands.CreateUser;
    using System.Linq;
    using System.Threading.Tasks;

    internal class IdentityService : IIdentity
    {
        private const string InvalidCredentialsErrorMessage = "Invalid Credentials!";

        private readonly UserManager<User> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(
            UserManager<User> userManager, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(changePasswordInput.UserId);

            if (user == null)
            {
                return InvalidCredentialsErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                                                            user,
                                                            changePasswordInput.CurrentPassword,
                                                            changePasswordInput.NewPassword);

            var errors = identityResult
                .Errors
                .Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result<string>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return Result<string>.Failure(InvalidCredentialsErrorMessage);
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return Result<string>.Failure(InvalidCredentialsErrorMessage);
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return Result<string>.SuccessWith(token);
        }

        public async Task<Result> Register(CreateUserCommand userInput)
        {
            var user = new User(
                userInput.FirstName, 
                userInput.LastName, 
                userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
        }
    }
}

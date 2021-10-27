namespace MyOnlineShop.Application.Identity.Commands.LoginUser
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<string>>
    {
        private readonly IIdentity identity;

        public LoginUserCommandHandler(IIdentity identity)
        {
            this.identity = identity;
        }

        public async Task<Result<string>> Handle(
            LoginUserCommand request, 
            CancellationToken cancellationToken)
        {
            return await this.identity.Login(request);
        }
    }
}

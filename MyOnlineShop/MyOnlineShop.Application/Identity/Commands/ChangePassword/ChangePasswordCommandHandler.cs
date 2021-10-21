namespace MyOnlineShop.Application.Identity.Commands.ChangePassword
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly IIdentity identity;
        private readonly ICurrentUser currentUser;

        public ChangePasswordCommandHandler(
            IIdentity identity, 
            ICurrentUser currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await this.identity.ChangePassword(
                new ChangePasswordInputModel(
                    currentUser.UserId, 
                    request.CurrentPassword, 
                    request.NewPassword));

            return result;
        }
    }
}

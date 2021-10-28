namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IIdentity identity;

        public CreateUserCommandHandler(IIdentity identity)
        {
            this.identity = identity;
        }

        public async Task<Result> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            return await this.identity.Register(request);
        }
    }
}

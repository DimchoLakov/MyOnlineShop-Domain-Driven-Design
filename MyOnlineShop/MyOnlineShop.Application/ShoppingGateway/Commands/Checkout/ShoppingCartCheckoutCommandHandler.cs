namespace MyOnlineShop.Application.ShoppingGateway.Commands.Checkout
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class ShoppingCartCheckoutCommandHandler : IRequestHandler<ShoppingCartCheckoutCommand, Result>
    {
        public async Task<Result> Handle(
            ShoppingCartCheckoutCommand request, 
            CancellationToken cancellationToken)
        {
            return await Task.Run(() => Result.Success);
        }
    }
}

namespace MyOnlineShop.Application.Shopping.Commands.ClearCart
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class ClearShoppingCartCommandHandler : IRequestHandler<ClearShoppingCartCommand, Result>
    {
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;

        public ClearShoppingCartCommandHandler(IShoppingCartDomainRepository shoppingCartDomainRepository)
        {
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
        }

        public async Task<Result> Handle(
            ClearShoppingCartCommand request,
            CancellationToken cancellationToken)
        {
            var shoppingCart = await this.shoppingCartDomainRepository
                                         .FindWithCartItems(request.UserId, cancellationToken);

            if (shoppingCart == null)
            {
                throw new NotFoundException(nameof(shoppingCart), request.UserId);
            }

            shoppingCart.Clear();

            await this.shoppingCartDomainRepository
                      .SaveAsync(shoppingCart, cancellationToken);

            return Result.Success;
        }
    }
}

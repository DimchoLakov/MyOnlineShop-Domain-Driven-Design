namespace MyOnlineShop.Application.ShoppingGateway.Commands.AddProduct
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Repositories.Products;
    using MyOnlineShop.Domain.Shopping.Factories;
    using MyOnlineShop.Domain.Shopping.Repositories;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddProductToShoppingCartCommandHandler : IRequestHandler<AddProductToShoppingCartCommand, Result>
    {
        private readonly IProductDomainRepository productDomainRepository;
        private readonly IShoppingCartDomainRepository shoppingCartDomainRepository;
        private readonly IShoppingCartFactory shoppingCartFactory;

        public AddProductToShoppingCartCommandHandler(
            IProductDomainRepository productDomainRepository,
            IShoppingCartDomainRepository shoppingCartDomainRepository,
            IShoppingCartFactory shoppingCartFactory)
        {
            this.productDomainRepository = productDomainRepository;
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
            this.shoppingCartFactory = shoppingCartFactory;
        }

        public async Task<Result> Handle(
            AddProductToShoppingCartCommand request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                return Result.Failure("User not authenticated!");
            }

            var product = await this.productDomainRepository.Find(request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.ProductId);
            }

            var shoppingCart = await this.shoppingCartDomainRepository
                                         .FindWithCartItems(request.UserId, cancellationToken);
            if (shoppingCart == null)
            {
                shoppingCart = this.shoppingCartFactory
                                   .WithUserId(request.UserId)
                                   .Build();
            }

            var cartItem = shoppingCart.GetCartItem(request.ProductId);
            if (cartItem == null)
            {
                shoppingCart.AddCartItem(
                                product.Id,
                                quantity: request.Quantity,
                                product.Name,
                                product.Weight,
                                product.Price,
                                product.Description,
                                product.ImageUrl);
            }
            else
            {
                cartItem.UpdateQuantity(request.Quantity);
            }

            await this.shoppingCartDomainRepository.SaveAsync(shoppingCart, cancellationToken);

            return Result.Success;
        }
    }
}

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
        private readonly ICurrentUser currentUser;

        public AddProductToShoppingCartCommandHandler(
            IProductDomainRepository productDomainRepository,
            IShoppingCartDomainRepository shoppingCartDomainRepository,
            IShoppingCartFactory shoppingCartFactory,
            ICurrentUser currentUser)
        {
            this.productDomainRepository = productDomainRepository;
            this.shoppingCartDomainRepository = shoppingCartDomainRepository;
            this.shoppingCartFactory = shoppingCartFactory;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            AddProductToShoppingCartCommand request,
            CancellationToken cancellationToken)
        {
            string currentUserId = this.currentUser.UserId;
            if (string.IsNullOrEmpty(currentUserId))
            {
                return Result.Failure("User not authenticated!");
            }

            var product = await this.productDomainRepository.Find(request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.ProductId);
            }

            var shoppingCart = await this.shoppingCartDomainRepository.FindWithCartItems(currentUserId, cancellationToken);
            if (shoppingCart == null)
            {
                shoppingCart = this.shoppingCartFactory
                    .WithUserId(currentUserId)
                    .Build();
            }

            var cartItem = shoppingCart.GetCartItem(request.ProductId);
            if (cartItem == null)
            {
                shoppingCart.AddCartItem(
                                product.Id,
                                quantity: 1,
                                product.Name,
                                product.Weight,
                                product.Price,
                                product.Description,
                                product.ImageUrl);
            }
            else
            {
                cartItem.UpdateQuantity(1);
            }

            await this.shoppingCartDomainRepository.SaveAsync(shoppingCart, cancellationToken);

            return Result.Success;
        }
    }
}

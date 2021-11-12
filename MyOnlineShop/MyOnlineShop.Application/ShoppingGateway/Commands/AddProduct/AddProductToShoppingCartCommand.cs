namespace MyOnlineShop.Application.ShoppingGateway.Commands.AddProduct
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class AddProductToShoppingCartCommand : IRequest<Result>
    {
        public AddProductToShoppingCartCommand(int productId)
        {
            this.ProductId = productId;
        }

        public int ProductId { get; private set; }
    }
}

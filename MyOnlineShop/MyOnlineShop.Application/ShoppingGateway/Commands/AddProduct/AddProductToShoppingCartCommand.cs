namespace MyOnlineShop.Application.ShoppingGateway.Commands.AddProduct
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class AddProductToShoppingCartCommand : IRequest<Result>
    {
        public AddProductToShoppingCartCommand(
            int productId,
            string userId,
            int quantity = 1)
        {
            this.ProductId = productId;
            this.UserId = userId;
            this.Quantity = quantity;
        }

        public int ProductId { get; private set; }

        public string UserId { get; private set; }

        public int Quantity { get; private set; }
    }
}

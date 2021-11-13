namespace MyOnlineShop.Application.Shopping.Commands.RemoveCartItem
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class RemoveCartItemCommand : IRequest<Result>
    {
        public RemoveCartItemCommand(
            int productId,
            string userId)
        {
            this.ProductId = productId;
            this.UserId = userId;
        }

        public int ProductId { get; private set; }

        public string UserId { get; private set; }
    }
}

namespace MyOnlineShop.Application.Shopping.Commands.ClearCart
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class ClearShoppingCartCommand : IRequest<Result>
    {
        public ClearShoppingCartCommand(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; private set; }
    }
}

namespace MyOnlineShop.Application.ShoppingGateway.Commands.Common
{
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Shopping.Models;

    public class CartItemCheckoutOutputModel : IMapFrom<ShoppingCartItem>
    {
        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public string ProductName { get; private set; } = default!;

        public string ProductDescription { get; private set; } = default!;

        public decimal ProductPrice { get; private set; }

        public string ProductImageUrl { get; private set; } = default!;

        public decimal Price => this.ProductPrice * this.Quantity;
    }
}

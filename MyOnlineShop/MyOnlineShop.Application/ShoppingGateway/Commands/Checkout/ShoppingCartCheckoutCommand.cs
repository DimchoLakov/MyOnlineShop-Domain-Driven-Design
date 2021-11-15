namespace MyOnlineShop.Application.ShoppingGateway.Commands.Checkout
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.InputOutputModels.Input.Address;
    using MyOnlineShop.Application.ShoppingGateway.Commands.Common;
    using System.Collections.Generic;

    public class ShoppingCartCheckoutCommand : IRequest<Result>
    {
        public ShoppingCartCheckoutCommand()
        {
        }

        public ShoppingCartCheckoutCommand(
            string userId,
            string firstName,
            string lastName,
            IEnumerable<CartItemCheckoutOutputModel> cartItems)
            : this()
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CartItems = cartItems;
        }

        public string UserId { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public IEnumerable<CartItemCheckoutOutputModel> CartItems { get; set; } = new List<CartItemCheckoutOutputModel>();

        public AddressInputModel AddressInputModel { get; set; } = default!;
    }
}

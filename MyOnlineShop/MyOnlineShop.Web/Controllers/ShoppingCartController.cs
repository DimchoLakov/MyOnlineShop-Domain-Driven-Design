namespace MyOnlineShop.Web.Controllers
{
    using Application.Shopping.Commands.RemoveCartItem;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Shopping.Commands.ClearCart;
    using MyOnlineShop.Application.Shopping.Queries.CartItems;
    using MyOnlineShop.Application.ShoppingGateway.Commands.AddProduct;
    using MyOnlineShop.Application.ShoppingGateway.Commands.Checkout;
    using MyOnlineShop.Application.ShoppingGateway.Queries.Checkout;
    using System.Threading.Tasks;

    [Authorize]
    public class ShoppingCartController : BaseController
    {
        private readonly ICurrentUser currentUser;

        public ShoppingCartController(ICurrentUser currentUser)
        {
            this.currentUser = currentUser;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.Mediator.Send(new ShoppingCartItemsQuery());

            return this.View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(int productId, int quantity, int? fromPage = 1)
        {
            await this.Mediator.Send(new AddProductToShoppingCartCommand(productId, this.currentUser.UserId, quantity));

            return this.Redirect($"/Products/Index/?page={fromPage}");
        }

        [HttpPost]
        public async Task<IActionResult> Clear()
        {
            await this.Mediator.Send(new ClearShoppingCartCommand(this.currentUser.UserId));

            return this.Redirect(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            await this.Mediator.Send(new RemoveCartItemCommand(productId, this.currentUser.UserId));

            return this.Redirect(nameof(Index));
        }

        public async Task<IActionResult> Checkout()
        {
            var shoppingCartChechoutCommand = await this.Mediator.Send(new ShoppingCartCheckoutQuery(this.currentUser.UserId));

            return this.View(shoppingCartChechoutCommand);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(ShoppingCartCheckoutCommand shoppingCartCheckoutCommand)
        {
            await this.Mediator.Send(shoppingCartCheckoutCommand);

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult Success()
        {
            return this.View();
        }
    }
}

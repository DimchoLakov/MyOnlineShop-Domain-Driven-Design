namespace MyOnlineShop.Startup.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Shopping.Commands.ClearCart;
    using MyOnlineShop.Application.Shopping.Queries.CartItems;
    using MyOnlineShop.Application.ShoppingGateway.Commands.AddProduct;
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

        //[HttpPost]
        //public async Task<IActionResult> RemoveItem(int productId)
        //{
        //    try
        //    {
        //        await this.shoppingCartService.RemoveItem(productId, this.currentUserService.UserId);

        //        return this.Redirect(nameof(Index));
        //    }
        //    catch (Refit.ApiException apiEx)
        //    {
        //        if (apiEx.HasContent)
        //        {
        //            JsonConvert
        //                .DeserializeObject<List<string>>(apiEx.Content)
        //                .ForEach(error => this.ModelState.AddModelError(string.Empty, error));
        //        }
        //        else
        //        {
        //            this.ModelState.AddModelError(string.Empty, ErrorConstants.InternalServerErrorMessage);
        //        }

        //        this.HandleException(apiEx);
        //    }

        //    return this.Redirect(nameof(Index));
        //}

        //public async Task<IActionResult> Checkout()
        //{
        //    try
        //    {
        //        var shoppingCartOrderWrapperViewModel = await this.shoppingCartGatewayService.GetCheckout();

        //        return this.View(shoppingCartOrderWrapperViewModel);
        //    }
        //    catch (Refit.ApiException apiEx)
        //    {
        //        if (apiEx.HasContent)
        //        {
        //            JsonConvert
        //                .DeserializeObject<List<string>>(apiEx.Content)
        //                .ForEach(error => this.ModelState.AddModelError(string.Empty, error));
        //        }
        //        else
        //        {
        //            this.ModelState.AddModelError(string.Empty, ErrorConstants.InternalServerErrorMessage);
        //        }

        //        this.HandleException(apiEx);
        //    }

        //    return this.View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Checkout(OrderAddressViewModel orderAddressViewModel)
        //{
        //    try
        //    {
        //        await this.shoppingCartGatewayService.Checkout(orderAddressViewModel);

        //        return this.RedirectToAction(nameof(Success));
        //    }
        //    catch (Refit.ApiException apiEx)
        //    {
        //        if (apiEx.HasContent)
        //        {
        //            JsonConvert
        //                .DeserializeObject<List<string>>(apiEx.Content)
        //                .ForEach(error => this.ModelState.AddModelError(string.Empty, error));
        //        }
        //        else
        //        {
        //            this.ModelState.AddModelError(string.Empty, ErrorConstants.InternalServerErrorMessage);
        //        }

        //        this.HandleException(apiEx);
        //    }

        //    return this.View();
        //}

        //public IActionResult Success()
        //{
        //    return this.View("Success", ShoppingCartConstants.SuccessMessage);
        //}
    }
}

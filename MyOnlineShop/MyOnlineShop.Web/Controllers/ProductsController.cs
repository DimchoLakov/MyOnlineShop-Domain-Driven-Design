namespace MyOnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Catalog.Products.Queries.Details;
    using MyOnlineShop.Application.Catalog.Products.Queries.Search;
    using System.Threading.Tasks;

    public class ProductsController : BaseController
    {
        public async Task<IActionResult> Index(
            string name,
            string description,
            decimal? minPrice,
            decimal? maxPrice,
            int page = 1)
        {
            var searchProductsQuery = new SearchProductsQuery(name, description, minPrice, maxPrice, page);

            var result = await this.Mediator.Send(searchProductsQuery);

            this.ViewData[Constants.ControllerViewData.ProductNameKey] = name;
            this.ViewData[Constants.ControllerViewData.ProductDescriptionKey] = description;
            this.ViewData[Constants.ControllerViewData.ProductMinPriceKey] = minPrice;
            this.ViewData[Constants.ControllerViewData.ProductMaxPriceKey] = maxPrice;
            this.ViewData[Constants.ControllerViewData.FromPageKey] = page;

            return this.View(result);
        }

        public async Task<IActionResult> Details(int id, int? fromPage = 1)
        {
            var produdct = await this.Mediator.Send(new ProductDetailsQuery(id));
            if (produdct == null)
            {
                return this.NotFound();
            }

            this.ViewData[Constants.ControllerViewData.FromPageKey] = fromPage;

            return this.View(produdct);
        }
    }
}

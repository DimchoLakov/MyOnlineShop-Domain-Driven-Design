namespace MyOnlineShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Catalog.Products.Commands.AddToCategory;
    using MyOnlineShop.Application.Catalog.Products.Commands.Create;
    using MyOnlineShop.Application.Catalog.Products.Commands.Edit;
    using MyOnlineShop.Application.Catalog.Products.Commands.RemoveFromCategory;
    using MyOnlineShop.Application.Catalog.Products.Queries.Details;
    using MyOnlineShop.Application.Catalog.Products.Queries.Edit;
    using MyOnlineShop.Application.Catalog.Products.Queries.Search;
    using System.Threading.Tasks;

    [Authorize(Roles = Constants.Roles.AdministratorRoleName)]
    [Area(Constants.Areas.AdminAreaName)]
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

        public IActionResult Create()
        {
            return this.View(new CreateProductCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand createProductCommand)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createProductCommand);
            }

            var result = await this.Mediator.Send(createProductCommand);
            if (!result.Succeeded)
            {
                return this.View(createProductCommand);
            }

            return this.RedirectToAction(nameof(this.Details), new { id = result.Data });
        }

        public async Task<IActionResult> Edit(int id, int? page = 1)
        {
            var editProductCommand = await this.Mediator.Send(new EditProductQuery(id));

            this.ViewData[Constants.ControllerViewData.FromPageKey] = page;

            return this.View(editProductCommand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductCommand editProductCommand, int page = 1)
        {
            var result = await this.Mediator.Send(editProductCommand);
            if (result.Data)
            {
                return this.RedirectToAction(nameof(Index), new { page });
            }

            return this.View(editProductCommand);
        }

        [HttpPost]
        public async Task<IActionResult> Archive(int id)
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> Unarchive(int id)
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> AddToCategory(int productId, int categoryId, int page = 1)
        {
            var result = await this.Mediator.Send(new AddProductToCategoryCommand(productId, categoryId));
            if (!result.Succeeded)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(this.Edit), new { id = productId, page });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCategory(int productId, int categoryId, int page = 1)
        {
            var result = await this.Mediator.Send(new RemoveCategoryFromProductCommand(productId, categoryId));
            if (!result.Succeeded)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(this.Edit), new { id = productId, page });
        }
    }
}

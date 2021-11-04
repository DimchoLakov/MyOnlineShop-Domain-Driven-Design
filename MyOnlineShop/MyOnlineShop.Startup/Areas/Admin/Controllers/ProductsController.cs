namespace MyOnlineShop.Startup.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Catalog.Products.Queries.Details;
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

            this.ViewData["Name"] = name;
            this.ViewData["Description"] = description;
            this.ViewData["MinPrice"] = minPrice;
            this.ViewData["MaxPrice"] = maxPrice;

            return this.View(result);
        }

        public async Task<IActionResult> Details(int id, int? fromPage = 1)
        {
            var produdct = await this.Mediator.Send(new ProductDetailsQuery(id));
            if (produdct == null)
            {
                return this.NotFound();
            }

            this.ViewData["FromPage"] = fromPage;

            return this.View(produdct);
        }

        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => this.View());
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        //{
        //    return await Task.Run(() => this.View());
        //}

        public async Task<IActionResult> Edit(int id, int? fromPage = 1)
        {
            return await Task.Run(() => this.View());
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(EditProductViewModel editProductViewModel)
        //{
        //    return await Task.Run(() => this.View());
        //}

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
    }
}

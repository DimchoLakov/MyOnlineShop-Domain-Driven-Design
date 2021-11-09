namespace MyOnlineShop.Startup.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Catalog.Categories.Commands.ChangeStatus;
    using MyOnlineShop.Application.Catalog.Categories.Commands.Create;
    using MyOnlineShop.Application.Catalog.Categories.Queries;
    using System.Threading.Tasks;

    [Authorize(Roles = Constants.Roles.AdministratorRoleName)]
    [Area(Constants.Areas.AdminAreaName)]
    public class CategoriesController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var categories = await this.Mediator.Send(new AllCategoriesQuery());

            return this.View(categories);
        }

        public IActionResult Create()
        {
            return this.View(new CreateCategoryCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand createCategoryCommand)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createCategoryCommand);
            }

            var result = await this.Mediator.Send(createCategoryCommand);
            if (result.Succeeded)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(createCategoryCommand);
        }

        [HttpPost]
        public async Task<IActionResult> StatusChange(int id)
        {
            await this.Mediator.Send(new CategoryChangeStatusCommand(id));

            return this.RedirectToAction(nameof(Index));
        }
    }
}

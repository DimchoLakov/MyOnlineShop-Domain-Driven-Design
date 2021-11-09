namespace MyOnlineShop.Startup.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Catalog.Categories.Commands.ChangeStatus;
    using MyOnlineShop.Application.Catalog.Categories.Commands.Create;
    using MyOnlineShop.Application.Catalog.Categories.Commands.Delete;
    using MyOnlineShop.Application.Catalog.Categories.Queries;
    using MyOnlineShop.Application.Catalog.Categories.Queries.Delete;
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

        public async Task<IActionResult> Delete(int id)
        {
            var deleteCategoryCommand = await this.Mediator.Send(new DeleteCategoryQuery(id));

            return this.View(deleteCategoryCommand);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategoryCommand deleteCategoryCommand)
        {
            var result = await this.Mediator.Send(deleteCategoryCommand);
            if (result.Succeeded)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(deleteCategoryCommand);
        }
    }
}

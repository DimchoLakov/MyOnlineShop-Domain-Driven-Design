namespace MyOnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Application.Ordering.Queries.Details;
    using MyOnlineShop.Application.Ordering.Queries.Mine;
    using System.Threading.Tasks;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly ICurrentUser currentUser;

        public OrdersController(ICurrentUser currentUser)
        {
            this.currentUser = currentUser;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.Mediator.Send(new MyOrdersQuery(this.currentUser.UserId));

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await this.Mediator.Send(new OrderDetailsQuery(id));

            return this.View(result);
        }
    }
}

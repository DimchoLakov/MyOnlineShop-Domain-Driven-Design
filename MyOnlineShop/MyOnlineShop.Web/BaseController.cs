namespace MyOnlineShop.Web
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator
            => this.mediator ??= (IMediator)this.HttpContext
                .RequestServices
                .GetService(typeof(IMediator))!;
    }
}

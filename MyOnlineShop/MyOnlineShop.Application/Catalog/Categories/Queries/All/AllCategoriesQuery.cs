namespace MyOnlineShop.Application.Catalog.Categories.Queries
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Categories.Queries.All;
    using System.Collections.Generic;

    public class AllCategoriesQuery : IRequest<IEnumerable<CategoryOutputModel>>
    {
    }
}

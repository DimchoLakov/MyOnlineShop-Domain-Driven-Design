namespace MyOnlineShop.Application.Catalog.Categories
{
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICategoryQueryRepository : IQueryRepository<Category>
    {
        Task<IEnumerable<TOutputModel>> GetAll<TOutputModel>(CancellationToken cancellationToken = default);

        Task<int> GetMaxOrder(CancellationToken cancellationToken = default);

        Task<bool> Exists(string name, CancellationToken cancellationToken = default);
    }
}

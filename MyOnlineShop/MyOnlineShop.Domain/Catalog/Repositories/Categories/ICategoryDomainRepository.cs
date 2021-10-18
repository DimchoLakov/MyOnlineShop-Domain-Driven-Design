namespace MyOnlineShop.Domain.Catalog.Repositories.Categories
{
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICategoryDomainRepository : IDomainRepository<Category>
    {
        Task<Category> Find(int id, CancellationToken cancellationToken = default);

        Task<Category> Find(string name, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}

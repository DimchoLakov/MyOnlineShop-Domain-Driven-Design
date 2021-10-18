namespace MyOnlineShop.Domain.Catalog.Repositories.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IProductDomainRepository : IDomainRepository<Product>
    {
        Task<Product> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<ProductOption> GetProductOption(int productId, string optionName, CancellationToken cancellationToken = default);

        Task<ProductOption> GetProductOption(int productId, int optionId, CancellationToken cancellationToken = default);

        Task<bool> DeleteProductOption(int productId, int optionId, CancellationToken cancellationToken = default);
    }
}

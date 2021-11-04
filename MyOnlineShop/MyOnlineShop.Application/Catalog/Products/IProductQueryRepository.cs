namespace MyOnlineShop.Application.Catalog.Products
{
    using MyOnlineShop.Application.Catalog.Products.Queries.Details;
    using MyOnlineShop.Application.Common.Contracts;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IProductQueryRepository : IQueryRepository<Product>
    {
        Task<ProductDetailsOutputModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);

        Task<List<TOutputModel>> GetProductListing<TOutputModel>(
            Specification<Product> productSpecification, 
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> GetTotalPages(
            Specification<Product> productSpecification,
            int productsPerPage,
            CancellationToken cancellationToken = default);
    }
}

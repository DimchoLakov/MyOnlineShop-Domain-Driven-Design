namespace MyOnlineShop.Infrastructure.Catalog.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Application.Catalog.Products;
    using MyOnlineShop.Application.Catalog.Products.Queries.Details;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Infrastructure.Common.Persistance;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ProductQueryRepository : DataRepository<ICatalogDbContext, Product>,
        IProductQueryRepository
    {
        private readonly IMapper mapper;

        public ProductQueryRepository(
            ICatalogDbContext dbContext,
            IMapper mapper)
            : base(dbContext)
        {
            this.mapper = mapper;
        }

        public async Task<ProductDetailsOutputModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
        {
            var products = this.All()
                               .Where(p => p.Id == id);

            return await this.mapper
                .ProjectTo<ProductDetailsOutputModel>(products)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TOutputModel>> GetProductListing<TOutputModel>(
            Specification<Product> productSpecification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
        {
            var products = this.All()
                .Where(productSpecification)
                .Skip(skip)
                .Take(take);

            return await this.mapper
                .ProjectTo<TOutputModel>(products)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetTotalPages(
            Specification<Product> productSpecification,
            CancellationToken cancellationToken = default)
        {
            return await this.All()
                .Where(productSpecification)
                .CountAsync(cancellationToken);
        }
    }
}

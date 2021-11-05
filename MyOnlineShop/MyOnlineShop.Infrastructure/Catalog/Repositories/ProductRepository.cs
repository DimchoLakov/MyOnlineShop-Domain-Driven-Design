namespace MyOnlineShop.Infrastructure.Catalog.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Application.Catalog.Products;
    using MyOnlineShop.Application.Catalog.Products.Queries.Details;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Catalog.Repositories.Products;
    using MyOnlineShop.Domain.Common;
    using MyOnlineShop.Infrastructure.Common.Persistance;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ProductRepository : DataRepository<ICatalogDbContext, Product>,
        IProductQueryRepository,
        IProductDomainRepository
    {
        private readonly IMapper mapper;

        public ProductRepository(
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

        public async Task<List<TOutputModel>> GetProductListing<TOutputModel>(
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
            int productsPerPage,
            CancellationToken cancellationToken = default)
        {
            int count = await this.All()
                .Where(productSpecification)
                .CountAsync(cancellationToken);

            int totalPages = (int)Math.Ceiling((decimal)count / productsPerPage);
            return totalPages;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var product = await this.Find(id, cancellationToken);
            if (product == null)
            {
                return false;
            }

            this.Data.Products.Remove(product);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteProductOption(int productId, int optionId, CancellationToken cancellationToken = default)
        {
            var product = await this.Find(productId, cancellationToken);
            if (product == null)
            {
                return false;
            }

            var productOption = await this.Data
                                    .ProductOptions
                                    .FindAsync(optionId);
            if (productOption == null)
            {
                return false;
            }

            product.RemoveOption(productOption);

            await this.SaveAsync(product, cancellationToken);

            return true;
        }

        public async Task<Product> Find(int id, CancellationToken cancellationToken = default)
        {
            return await this.Data
                       .Products
                       .FindAsync(id, cancellationToken);
        }

        public async Task<ProductOption> GetProductOption(int productId, string optionName, CancellationToken cancellationToken = default)
        {
            var product = await this.Find(productId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("Product", productId);
            }

            var productOption = product.GetOption(optionName);

            return productOption;
        }

        public async Task<ProductOption> GetProductOption(int productId, int optionId, CancellationToken cancellationToken = default)
        {
            var product = await this.Find(productId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("Product", productId);
            }

            var productOption = product.GetOption(optionId);

            return productOption;
        }
    }
}

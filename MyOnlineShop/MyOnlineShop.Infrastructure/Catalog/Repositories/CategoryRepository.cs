namespace MyOnlineShop.Infrastructure.Catalog.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Application.Catalog.Categories;
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using MyOnlineShop.Infrastructure.Common.Persistance;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CategoryRepository : DataRepository<ICatalogDbContext, Category>,
        ICategoryQueryRepository,
        ICategoryDomainRepository
    {
        private readonly IMapper mapper;

        public CategoryRepository(
            ICatalogDbContext dbContext,
            IMapper mapper)
            : base(dbContext)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TOutputModel>> GetAll<TOutputModel>(CancellationToken cancellationToken = default)
        {
            return await this.mapper
                .ProjectTo<TOutputModel>(
                    this.All()
                        .OrderBy(c => c.Order))
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var category = await this.Find(id, cancellationToken);
            if (category == null)
            {
                return false;
            }

            this.Data.Categories.Remove(category);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Category> Find(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                       .Categories
                       .FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Category> Find(
            string name,
            CancellationToken cancellationToken = default)
        {
            return await this.Data
                       .Categories
                       .FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
        }

        public async Task<int> GetMaxOrder(CancellationToken cancellationToken = default)
        {
            return await this.All()
                .MaxAsync(c => c.Order, cancellationToken);
        }

        public async Task<bool> Exists(
            string name,
            CancellationToken cancellationToken = default)
        {
            return await this.All()
                .AnyAsync(c => c.Name == name, cancellationToken);
        }
    }
}

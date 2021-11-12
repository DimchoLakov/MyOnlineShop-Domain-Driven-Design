namespace MyOnlineShop.Infrastructure.Common.Persistance
{
    using MyOnlineShop.Domain.Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext dbContext)
        {
            this.Data = dbContext;
        }

        protected TDbContext Data { get; private set; }

        protected IQueryable<TEntity> All()
        {
            return this.Data.Set<TEntity>();
        }

        public async Task SaveAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}

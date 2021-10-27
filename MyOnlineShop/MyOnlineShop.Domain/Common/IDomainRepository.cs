namespace MyOnlineShop.Domain.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDomainRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task SaveAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}

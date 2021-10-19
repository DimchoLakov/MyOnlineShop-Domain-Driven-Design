namespace MyOnlineShop.Application.Common.Contracts
{
    using MyOnlineShop.Domain.Common;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}

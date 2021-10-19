namespace MyOnlineShop.Application.Common
{
    using MyOnlineShop.Domain.Common;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
    }
}

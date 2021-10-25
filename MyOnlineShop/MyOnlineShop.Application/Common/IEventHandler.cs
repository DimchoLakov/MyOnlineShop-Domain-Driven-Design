namespace MyOnlineShop.Application.Common
{
    using MyOnlineShop.Domain.Common;
    using System.Threading.Tasks;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}

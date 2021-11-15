namespace MyOnlineShop.Infrastructure.Ordering
{
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Domain.Ordering.Models.Orders;
    using MyOnlineShop.Infrastructure.Common.Persistance;

    internal interface IOrderingDbContext : IDbContext
    {
        DbSet<Order> Orders { get; }

        DbSet<OrderItem> OrderItems { get; }
    }
}

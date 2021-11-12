namespace MyOnlineShop.Infrastructure.Common.Persistance
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyOnlineShop.Domain.Catalog.Models.Categories;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common.Models;
    using MyOnlineShop.Domain.Shopping.Models;
    using MyOnlineShop.Infrastructure.Catalog;
    using MyOnlineShop.Infrastructure.Common.Events;
    using MyOnlineShop.Infrastructure.Identity;
    using MyOnlineShop.Infrastructure.Shopping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MyOnlineShopDbContext : IdentityDbContext<User>, 
        ICatalogDbContext,
        IShoppingDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> saveChangesTracker;

        public MyOnlineShopDbContext(
            DbContextOptions<MyOnlineShopDbContext> options,
            IEventDispatcher eventDispatcher) : base(options)
        {
            this.eventDispatcher = eventDispatcher;
            this.saveChangesTracker = new Stack<object>();
        }

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<ProductOption> ProductOptions { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = default!;

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.saveChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.saveChangesTracker.Pop();

            if (!this.saveChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

namespace MyOnlineShop.Application.Common
{
    using System;
    using System.Linq.Expressions;

    public abstract class SortOrder<TEntity>
    {
        public const string Ascending = "asc";
        public const string Descending = "desc";
        
        protected SortOrder(string? sortBy, string? order)
        {
            this.SortBy = sortBy;
            this.Order = order;
        }

        public string? SortBy { get; private set; }

        public string? Order { get; private set; }

        public abstract Expression<Func<TEntity, object>> ToExpression();
    }
}

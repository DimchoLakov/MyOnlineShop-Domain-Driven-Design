namespace MyOnlineShop.Domain.Catalog.Specifications.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class ProductByMinPriceSpecification : Specification<Product>
    {
        private readonly decimal? minPrice;

        public ProductByMinPriceSpecification(decimal? name)
        {
            this.minPrice = name;
        }

        protected override bool Include => this.minPrice != null;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Price >= this.minPrice;
        }
    }
}

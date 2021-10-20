namespace MyOnlineShop.Domain.Catalog.Specifications.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class ProductByMaxPriceSpecification : Specification<Product>
    {
        private readonly decimal? maxPrice;

        public ProductByMaxPriceSpecification(decimal? maxPrice)
        {
            this.maxPrice = maxPrice;
        }

        protected override bool Include => this.maxPrice != null;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => this.maxPrice >= product.Price;
        }
    }
}

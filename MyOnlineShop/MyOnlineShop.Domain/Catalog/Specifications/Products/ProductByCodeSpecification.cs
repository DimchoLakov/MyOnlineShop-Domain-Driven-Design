namespace MyOnlineShop.Domain.Catalog.Specifications.Products
{
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using MyOnlineShop.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class ProductByCodeSpecification : Specification<Product>
    {
        private readonly string? code;

        public ProductByCodeSpecification(string? code)
        {
            this.code = code;
        }

        protected override bool Include => this.code != null;

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.Code.Contains(this.code!);
        }
    }
}

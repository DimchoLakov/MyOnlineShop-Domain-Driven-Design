namespace MyOnlineShop.Application.Catalog.Products.Queries.Common
{
    using System.Collections.Generic;

    public abstract class ProductsOutputModel<TProductOutputModel>
    {
        internal ProductsOutputModel(
            IEnumerable<TProductOutputModel> products,
            int page,
            int totalPages)
        {
            this.Products = products;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TProductOutputModel> Products { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}

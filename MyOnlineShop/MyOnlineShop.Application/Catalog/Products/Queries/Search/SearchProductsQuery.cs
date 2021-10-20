namespace MyOnlineShop.Application.Catalog.Products.Queries.Search
{
    using MediatR;

    public class SearchProductsQuery : IRequest<SearchProductsOutputModel>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? MinPrice { get; set; }
        
        public decimal? MaxPrice { get; set; }

        public string? Code { get; set; }

        public int Page { get; set; } = 1;
    }
}

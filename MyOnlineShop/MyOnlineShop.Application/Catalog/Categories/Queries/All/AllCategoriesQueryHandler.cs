namespace MyOnlineShop.Application.Catalog.Categories.Queries.All
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class AllCategoriesQueryHandler : IRequestHandler<AllCategoriesQuery, IEnumerable<CategoryOutputModel>>
    {
        private readonly ICategoryQueryRepository categoryQueryRepository;

        public AllCategoriesQueryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            this.categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<IEnumerable<CategoryOutputModel>> Handle(
            AllCategoriesQuery request, 
            CancellationToken cancellationToken)
        {
            var categories = await this.categoryQueryRepository.GetAll<CategoryOutputModel>(cancellationToken);

            return categories;
        }
    }
}

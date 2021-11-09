namespace MyOnlineShop.Application.Catalog.Categories.Commands.Create
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Factories.Categories;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<int>>
    {
        private readonly ICategoryFactory categoryFactory;
        private readonly ICategoryDomainRepository categoryDomainRepository;
        private readonly ICategoryQueryRepository categoryQueryRepository;

        public CreateCategoryCommandHandler(
            ICategoryFactory categoryFactory,
            ICategoryDomainRepository categoryDomainRepository, 
            ICategoryQueryRepository categoryQueryRepository)
        {
            this.categoryFactory = categoryFactory;
            this.categoryDomainRepository = categoryDomainRepository;
            this.categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<Result<int>> Handle(
            CreateCategoryCommand request, 
            CancellationToken cancellationToken)
        {
            int maxOrder = await this.categoryQueryRepository.GetMaxOrder(cancellationToken);

            var category = this.categoryFactory
                .WithName(request.Name)
                .WithImageUrl(request.ImageUrl)
                .WithIsActive(request.IsActive)
                .WithOrder(maxOrder + 1)
                .Build();

            await this.categoryDomainRepository.SaveAsync(category, cancellationToken);

            return category.Id;
        }
    }
}

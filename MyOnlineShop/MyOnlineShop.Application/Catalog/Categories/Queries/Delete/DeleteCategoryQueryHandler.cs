namespace MyOnlineShop.Application.Catalog.Categories.Queries.Delete
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Categories.Commands.Delete;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCategoryQueryHandler : IRequestHandler<DeleteCategoryQuery, DeleteCategoryCommand>
    {
        private readonly ICategoryDomainRepository categoryDomainRepository;

        public DeleteCategoryQueryHandler(ICategoryDomainRepository categoryDomainRepository)
        {
            this.categoryDomainRepository = categoryDomainRepository;
        }

        public async Task<DeleteCategoryCommand> Handle(
            DeleteCategoryQuery request, 
            CancellationToken cancellationToken)
        {
            var category = await this.categoryDomainRepository.Find(request.Id, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException(nameof(category), request);
            }

            return new DeleteCategoryCommand(
                category.Id, 
                category.Name,
                category.ImageUrl);
        }
    }
}

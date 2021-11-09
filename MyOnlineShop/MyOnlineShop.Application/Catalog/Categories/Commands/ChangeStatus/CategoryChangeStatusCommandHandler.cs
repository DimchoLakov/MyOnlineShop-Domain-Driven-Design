namespace MyOnlineShop.Application.Catalog.Categories.Commands.ChangeStatus
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CategoryChangeStatusCommandHandler : IRequestHandler<CategoryChangeStatusCommand, Result>
    {
        private readonly ICategoryDomainRepository categoryDomainRepository;

        public CategoryChangeStatusCommandHandler(ICategoryDomainRepository categoryDomainRepository)
        {
            this.categoryDomainRepository = categoryDomainRepository;
        }

        public async Task<Result> Handle(
            CategoryChangeStatusCommand request, 
            CancellationToken cancellationToken)
        {
            var category = await this.categoryDomainRepository.Find(request.Id, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException(nameof(category), request.Id);
            }

            category.ChangeStatus();

            await this.categoryDomainRepository.SaveAsync(category, cancellationToken);

            return Result.Success;
        }
    }
}

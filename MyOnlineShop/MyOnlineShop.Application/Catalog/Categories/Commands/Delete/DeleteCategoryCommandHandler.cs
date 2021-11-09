namespace MyOnlineShop.Application.Catalog.Categories.Commands.Delete
{
    using MediatR;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly ICategoryDomainRepository categoryDomainRepository;

        public DeleteCategoryCommandHandler(ICategoryDomainRepository categoryDomainRepository)
        {
            this.categoryDomainRepository = categoryDomainRepository;
        }

        public async Task<Result> Handle(
            DeleteCategoryCommand request, 
            CancellationToken cancellationToken)
        {
            bool succeeded = await this.categoryDomainRepository.Delete(request.Id, cancellationToken);

            return
                succeeded ?
                    Result.Success :
                    Result.Failure("Category not found!");
        }
    }
}

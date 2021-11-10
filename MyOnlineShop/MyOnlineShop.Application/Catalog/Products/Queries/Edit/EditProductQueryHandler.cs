namespace MyOnlineShop.Application.Catalog.Products.Queries.Edit
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Categories;
    using MyOnlineShop.Application.Catalog.Products.Commands.Edit;
    using MyOnlineShop.Application.Common.Exceptions;
    using MyOnlineShop.Domain.Catalog.Repositories.Categories;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditProductQueryHandler : IRequestHandler<EditProductQuery, EditProductCommand>
    {
        private readonly IProductQueryRepository productQueryRepository;
        private readonly ICategoryQueryRepository categoryQueryRepository;

        public EditProductQueryHandler(
            IProductQueryRepository productQueryRepository,
            ICategoryQueryRepository categoryQueryRepository)
        {
            this.productQueryRepository = productQueryRepository;
            this.categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<EditProductCommand> Handle(
            EditProductQuery request,
            CancellationToken cancellationToken)
        {
            var productEditCommand = await this.productQueryRepository.GetProductToEdit(request.Id, cancellationToken);
            if (productEditCommand == null)
            {
                throw new NotFoundException(nameof(productEditCommand), request.Id);
            }

            var unassignedCategorySelectListItems = await this.categoryQueryRepository.UnassignedSelectListItems(request.Id, cancellationToken);
            var assignedCategoryModels = await this.productQueryRepository.AssignedCategories(request.Id, cancellationToken);

            productEditCommand.UnassignedCategorySelectListItems = unassignedCategorySelectListItems;
            productEditCommand.AssignedCategoryModels = assignedCategoryModels;

            return productEditCommand;
        }
    }
}

namespace MyOnlineShop.Application.Catalog.Products.Queries.Edit
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Products.Commands.Edit;
    using MyOnlineShop.Application.Common.Exceptions;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditProductQueryHandler : IRequestHandler<EditProductQuery, EditProductCommand>
    {
        private readonly IProductQueryRepository productQueryRepository;

        public EditProductQueryHandler(IProductQueryRepository productQueryRepository)
        {
            this.productQueryRepository = productQueryRepository;
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

            return productEditCommand;
        }
    }
}

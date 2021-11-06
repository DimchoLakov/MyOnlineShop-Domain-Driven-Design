namespace MyOnlineShop.Application.Catalog.Products.Queries.Edit
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Products.Commands.Edit;

    public class EditProductQuery : IRequest<EditProductCommand>
    {
        public EditProductQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}

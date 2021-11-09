namespace MyOnlineShop.Application.Catalog.Categories.Queries.Delete
{
    using MediatR;
    using MyOnlineShop.Application.Catalog.Categories.Commands.Delete;

    public class DeleteCategoryQuery : IRequest<DeleteCategoryCommand>
    {
        public DeleteCategoryQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}

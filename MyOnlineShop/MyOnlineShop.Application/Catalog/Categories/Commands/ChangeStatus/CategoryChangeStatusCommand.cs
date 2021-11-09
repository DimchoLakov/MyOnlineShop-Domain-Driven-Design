namespace MyOnlineShop.Application.Catalog.Categories.Commands.ChangeStatus
{
    using MediatR;
    using MyOnlineShop.Application.Common;

    public class CategoryChangeStatusCommand : IRequest<Result>
    {
        public CategoryChangeStatusCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}

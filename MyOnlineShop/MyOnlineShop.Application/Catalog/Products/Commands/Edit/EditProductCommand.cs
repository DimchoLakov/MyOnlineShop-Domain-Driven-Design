namespace MyOnlineShop.Application.Catalog.Products.Commands.Edit
{
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyOnlineShop.Application.Catalog.Products.Commands.Common;
    using MyOnlineShop.Application.Common;
    using MyOnlineShop.Application.Common.Mapping;
    using MyOnlineShop.Domain.Catalog.Models.Products;
    using System.Collections.Generic;

    public class EditProductCommand : ProductCommand,
        IRequest<Result<bool>>,
        IMapFrom<Product>
    {
        public int Id { get; set; }

        public IEnumerable<SelectListItem> UnassignedCategorySelectListItems { get; set; } = new List<SelectListItem>();

        public IEnumerable<AssignedCategoryModel> AssignedCategoryModels = new List<AssignedCategoryModel>();

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<Product, EditProductCommand>()
                .ForMember(dest => dest.Type, options => options.MapFrom(src => src.Type.Value));
        }
    }
}

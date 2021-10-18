using AutoMapper;

namespace MyOnlineShop.Application.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), this.GetType());
    }
}

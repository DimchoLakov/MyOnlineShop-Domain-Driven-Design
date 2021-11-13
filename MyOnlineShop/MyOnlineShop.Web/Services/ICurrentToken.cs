namespace MyOnlineShop.Web.Services
{
    public interface ICurrentToken
    {
        string Get();

        void Set(string token);
    }
}

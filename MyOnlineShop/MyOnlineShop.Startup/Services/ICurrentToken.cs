namespace MyOnlineShop.Startup.Services
{
    public interface ICurrentToken
    {
        string Get();

        void Set(string token);
    }
}

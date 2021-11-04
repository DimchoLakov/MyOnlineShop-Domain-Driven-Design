namespace MyOnlineShop.Startup.Services
{
    public class CurrentTokenService : ICurrentToken
    {
        private string currentToken = default!;

        public string Get()
        {
            return this.currentToken;
        }

        public void Set(string token)
        {
            this.currentToken = token;
        }
    }
}

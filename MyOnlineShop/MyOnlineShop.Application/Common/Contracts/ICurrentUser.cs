namespace MyOnlineShop.Application.Common.Contracts
{
    public interface ICurrentUser
    {
        string UserId { get; }

        string Username { get; }

        bool IsAdministrator { get; }
    }
}

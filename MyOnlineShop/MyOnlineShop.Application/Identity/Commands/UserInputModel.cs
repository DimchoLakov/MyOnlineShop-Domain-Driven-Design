namespace MyOnlineShop.Application.Identity.Commands
{
    public abstract class UserInputModel
    {
        public string Email { get; private set; } = default!;

        public string Password { get; private set; } = default!;
    }
}

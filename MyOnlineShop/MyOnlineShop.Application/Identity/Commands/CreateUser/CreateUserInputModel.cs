namespace MyOnlineShop.Application.Identity.Commands.CreateUser
{
    public class CreateUserInputModel : UserInputModel, IUser
    {
        public string FirstName { get; private set; } = default!;

        public string LastName { get; private set; } = default!;
    }
}

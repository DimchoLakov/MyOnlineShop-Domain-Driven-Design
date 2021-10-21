namespace MyOnlineShop.Application.Identity.Commands.ChangePassword
{
    public class ChangePasswordInputModel
    {
        public ChangePasswordInputModel(
            string userId,
            string currentPassword,
            string newPassword)
        {
            this.UserId = userId;
            this.CurrentPassword = currentPassword;
            this.NewPassword = newPassword;
        }

        public string UserId { get; private set; }

        public string CurrentPassword { get; private set; }

        public string NewPassword { get; private set; }
    }
}

namespace MyOnlineShop.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using MyOnlineShop.Domain.Common;
    using System.Threading.Tasks;

    public class IdentityDataSeeder : IDataSeeder
    {
        private const string FirstName = "Admin";
        private const string LastName = "Guy";
        private const string AdministratorRole = "Administrator";
        private const string AdminEmail = "admin@myonlineshop.com";
        private const string Password = "adminpass1234";

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            Task
                .Run(async () =>
                {
                    var roleExists = await this.roleManager.RoleExistsAsync(AdministratorRole);
                    if (!roleExists)
                    {
                        var adminRole = new IdentityRole(AdministratorRole);

                        await this.roleManager.CreateAsync(adminRole);
                    }

                    var user = await this.userManager.FindByEmailAsync(AdminEmail);
                    if (user == null)
                    {
                        var adminUser = new User(
                            FirstName,
                            LastName,
                            AdminEmail);

                        await userManager.CreateAsync(adminUser, Password);

                        await userManager.AddToRoleAsync(adminUser, AdministratorRole);
                    }
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}

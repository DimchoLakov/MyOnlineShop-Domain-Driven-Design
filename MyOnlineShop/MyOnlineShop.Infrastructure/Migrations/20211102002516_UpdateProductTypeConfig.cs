using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOnlineShop.Infrastructure.Migrations
{
    public partial class UpdateProductTypeConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type_Value",
                table: "Products",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Products",
                newName: "Type_Value");
        }
    }
}

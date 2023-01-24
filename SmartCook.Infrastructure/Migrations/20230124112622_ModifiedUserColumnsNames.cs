using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserColumnsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isLoggedIn",
                table: "Users",
                newName: "IsLoggedIn");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Users",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLoggedIn",
                table: "Users",
                newName: "isLoggedIn");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Users",
                newName: "imageUrl");
        }
    }
}

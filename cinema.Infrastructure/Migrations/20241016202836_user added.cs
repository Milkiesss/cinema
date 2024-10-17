using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class useradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "users",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "PriceModifire",
                table: "seats",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "FullName_firstName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName_lastName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName_firstName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "FullName_lastName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "seats",
                newName: "PriceModifire");
        }
    }
}

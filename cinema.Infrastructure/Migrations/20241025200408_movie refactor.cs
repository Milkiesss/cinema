using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class movierefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "movies",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Restriction",
                table: "movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "Restriction",
                table: "movies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "movies",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}

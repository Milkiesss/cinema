using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixScreeningCongig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartScreening",
                table: "screenings",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndScreening",
                table: "screenings",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartScreening",
                table: "screenings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndScreening",
                table: "screenings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");
        }
    }
}

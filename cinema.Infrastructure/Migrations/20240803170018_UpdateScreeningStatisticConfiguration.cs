using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScreeningStatisticConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreeningStatistics",
                table: "ScreeningStatistics");

            migrationBuilder.DropIndex(
                name: "IX_ScreeningStatistics_ScreeningId",
                table: "ScreeningStatistics");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScreeningStatistics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreeningStatistics",
                table: "ScreeningStatistics",
                columns: new[] { "ScreeningId", "ScreeningDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreeningStatistics",
                table: "ScreeningStatistics");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ScreeningStatistics",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreeningStatistics",
                table: "ScreeningStatistics",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ScreeningStatistics_ScreeningId",
                table: "ScreeningStatistics",
                column: "ScreeningId",
                unique: true);
        }
    }
}

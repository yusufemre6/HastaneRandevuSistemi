using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoktordtAy",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "DoktordtGun",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "DoktordtYil",
                table: "Doktorlar");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoktorDt",
                table: "Doktorlar",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoktorDt",
                table: "Doktorlar");

            migrationBuilder.AddColumn<int>(
                name: "DoktordtAy",
                table: "Doktorlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoktordtGun",
                table: "Doktorlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoktordtYil",
                table: "Doktorlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

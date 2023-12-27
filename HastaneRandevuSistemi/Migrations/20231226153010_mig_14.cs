using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HastaneID",
                table: "Poliklinikler",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_HastaneID",
                table: "Poliklinikler",
                column: "HastaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Poliklinikler_Hastaneler_HastaneID",
                table: "Poliklinikler",
                column: "HastaneID",
                principalTable: "Hastaneler",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poliklinikler_Hastaneler_HastaneID",
                table: "Poliklinikler");

            migrationBuilder.DropIndex(
                name: "IX_Poliklinikler_HastaneID",
                table: "Poliklinikler");

            migrationBuilder.DropColumn(
                name: "HastaneID",
                table: "Poliklinikler");
        }
    }
}

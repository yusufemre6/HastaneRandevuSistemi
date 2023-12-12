using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branslar_Branslar_BransID1",
                table: "Branslar");

            migrationBuilder.DropIndex(
                name: "IX_Branslar_BransID1",
                table: "Branslar");

            migrationBuilder.DropColumn(
                name: "BransID1",
                table: "Branslar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BransID1",
                table: "Branslar",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branslar_BransID1",
                table: "Branslar",
                column: "BransID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Branslar_Branslar_BransID1",
                table: "Branslar",
                column: "BransID1",
                principalTable: "Branslar",
                principalColumn: "BransID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_KisiTipleri_KisiTipiID",
                table: "Rol");

            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Kullanicilar_KullaniciID",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roller");

            migrationBuilder.RenameIndex(
                name: "IX_Rol_KullaniciID",
                table: "Roller",
                newName: "IX_Roller_KullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_Rol_KisiTipiID",
                table: "Roller",
                newName: "IX_Roller_KisiTipiID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roller",
                table: "Roller",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Roller_KisiTipleri_KisiTipiID",
                table: "Roller",
                column: "KisiTipiID",
                principalTable: "KisiTipleri",
                principalColumn: "KisiTipiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roller_Kullanicilar_KullaniciID",
                table: "Roller",
                column: "KullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roller_KisiTipleri_KisiTipiID",
                table: "Roller");

            migrationBuilder.DropForeignKey(
                name: "FK_Roller_Kullanicilar_KullaniciID",
                table: "Roller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roller",
                table: "Roller");

            migrationBuilder.RenameTable(
                name: "Roller",
                newName: "Rol");

            migrationBuilder.RenameIndex(
                name: "IX_Roller_KullaniciID",
                table: "Rol",
                newName: "IX_Rol_KullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_Roller_KisiTipiID",
                table: "Rol",
                newName: "IX_Rol_KisiTipiID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_KisiTipleri_KisiTipiID",
                table: "Rol",
                column: "KisiTipiID",
                principalTable: "KisiTipleri",
                principalColumn: "KisiTipiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Kullanicilar_KullaniciID",
                table: "Rol",
                column: "KullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
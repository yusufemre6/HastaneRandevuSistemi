using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Cinsiyet_CinsiyetID",
                table: "Kullanicilar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_KisiTipleri_KisiTipiID",
                table: "Kullanicilar");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciID",
                table: "Randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanicilar",
                table: "Kullanicilar");

            migrationBuilder.RenameTable(
                name: "Kullanicilar",
                newName: "Kullanici");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanicilar_KisiTipiID",
                table: "Kullanici",
                newName: "IX_Kullanici_KisiTipiID");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanicilar_CinsiyetID",
                table: "Kullanici",
                newName: "IX_Kullanici_CinsiyetID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici",
                column: "KullaniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanici_Cinsiyet_CinsiyetID",
                table: "Kullanici",
                column: "CinsiyetID",
                principalTable: "Cinsiyet",
                principalColumn: "CinsiyetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanici_KisiTipleri_KisiTipiID",
                table: "Kullanici",
                column: "KisiTipiID",
                principalTable: "KisiTipleri",
                principalColumn: "KisiTipiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Kullanici_KullaniciID",
                table: "Randevular",
                column: "KullaniciID",
                principalTable: "Kullanici",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanici_Cinsiyet_CinsiyetID",
                table: "Kullanici");

            migrationBuilder.DropForeignKey(
                name: "FK_Kullanici_KisiTipleri_KisiTipiID",
                table: "Kullanici");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Kullanici_KullaniciID",
                table: "Randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici");

            migrationBuilder.RenameTable(
                name: "Kullanici",
                newName: "Kullanicilar");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanici_KisiTipiID",
                table: "Kullanicilar",
                newName: "IX_Kullanicilar_KisiTipiID");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanici_CinsiyetID",
                table: "Kullanicilar",
                newName: "IX_Kullanicilar_CinsiyetID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanicilar",
                table: "Kullanicilar",
                column: "KullaniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Cinsiyet_CinsiyetID",
                table: "Kullanicilar",
                column: "CinsiyetID",
                principalTable: "Cinsiyet",
                principalColumn: "CinsiyetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_KisiTipleri_KisiTipiID",
                table: "Kullanicilar",
                column: "KisiTipiID",
                principalTable: "KisiTipleri",
                principalColumn: "KisiTipiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciID",
                table: "Randevular",
                column: "KullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

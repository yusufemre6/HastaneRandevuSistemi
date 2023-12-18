using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Cinsiyet_CinsiyetID",
                table: "Doktorlar");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinsiyet",
                table: "Cinsiyet");

            migrationBuilder.RenameTable(
                name: "Kullanici",
                newName: "Kullanicilar");

            migrationBuilder.RenameTable(
                name: "Cinsiyet",
                newName: "Cinsiyetler");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinsiyetler",
                table: "Cinsiyetler",
                column: "CinsiyetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Cinsiyetler_CinsiyetID",
                table: "Doktorlar",
                column: "CinsiyetID",
                principalTable: "Cinsiyetler",
                principalColumn: "CinsiyetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Cinsiyetler_CinsiyetID",
                table: "Kullanicilar",
                column: "CinsiyetID",
                principalTable: "Cinsiyetler",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Cinsiyetler_CinsiyetID",
                table: "Doktorlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Cinsiyetler_CinsiyetID",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinsiyetler",
                table: "Cinsiyetler");

            migrationBuilder.RenameTable(
                name: "Kullanicilar",
                newName: "Kullanici");

            migrationBuilder.RenameTable(
                name: "Cinsiyetler",
                newName: "Cinsiyet");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinsiyet",
                table: "Cinsiyet",
                column: "CinsiyetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Cinsiyet_CinsiyetID",
                table: "Doktorlar",
                column: "CinsiyetID",
                principalTable: "Cinsiyet",
                principalColumn: "CinsiyetID",
                onDelete: ReferentialAction.Cascade);

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
    }
}

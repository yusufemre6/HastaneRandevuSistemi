using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_KisiTipleri_KisiTipiID",
                table: "Kullanicilar");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_KisiTipiID",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Dakika",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "RandevuAy",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "RandevuGun",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "RandevuYil",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Saat",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "KisiTipiID",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullanicidtAy",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullanicidtGun",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullanicidtYil",
                table: "Kullanicilar");

            migrationBuilder.AddColumn<DateTime>(
                name: "RandevuTarihSaat",
                table: "Randevular",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "KullaniciDt",
                table: "Kullanicilar",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciID = table.Column<int>(type: "integer", nullable: false),
                    KisiTipiID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                    table.ForeignKey(
                        name: "FK_Rol_KisiTipleri_KisiTipiID",
                        column: x => x.KisiTipiID,
                        principalTable: "KisiTipleri",
                        principalColumn: "KisiTipiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rol_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rol_KisiTipiID",
                table: "Rol",
                column: "KisiTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_KullaniciID",
                table: "Rol",
                column: "KullaniciID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropColumn(
                name: "RandevuTarihSaat",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "KullaniciDt",
                table: "Kullanicilar");

            migrationBuilder.AddColumn<int>(
                name: "Dakika",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RandevuAy",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RandevuGun",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RandevuYil",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Saat",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KisiTipiID",
                table: "Kullanicilar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullanicidtAy",
                table: "Kullanicilar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullanicidtGun",
                table: "Kullanicilar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullanicidtYil",
                table: "Kullanicilar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KisiTipiID",
                table: "Kullanicilar",
                column: "KisiTipiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_KisiTipleri_KisiTipiID",
                table: "Kullanicilar",
                column: "KisiTipiID",
                principalTable: "KisiTipleri",
                principalColumn: "KisiTipiID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

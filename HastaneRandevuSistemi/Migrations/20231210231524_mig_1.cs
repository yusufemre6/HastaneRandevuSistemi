using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinsiyetler",
                columns: table => new
                {
                    CinsiyetID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CinsiyetAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyetler", x => x.CinsiyetID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    KullaniciSoyadi = table.Column<string>(type: "text", nullable: false),
                    KullanicidtGun = table.Column<int>(type: "integer", nullable: false),
                    KullanicidtAy = table.Column<int>(type: "integer", nullable: false),
                    KullanicidtYil = table.Column<int>(type: "integer", nullable: false),
                    CinsiyetID = table.Column<int>(type: "integer", nullable: false),
                    KullaniciTelNo = table.Column<string>(type: "text", nullable: false),
                    KullaniciEmail = table.Column<string>(type: "text", nullable: false),
                    RolID = table.Column<string>(type: "text", nullable: false),
                    KullaniciSifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Cinsiyetler_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyetler",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_CinsiyetID",
                table: "Kullanicilar",
                column: "CinsiyetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Cinsiyetler");
        }
    }
}

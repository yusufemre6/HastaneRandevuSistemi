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
                name: "Branslar",
                columns: table => new
                {
                    BransID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BransAdi = table.Column<string>(type: "text", nullable: false),
                    BransID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branslar", x => x.BransID);
                    table.ForeignKey(
                        name: "FK_Branslar_Branslar_BransID1",
                        column: x => x.BransID1,
                        principalTable: "Branslar",
                        principalColumn: "BransID");
                });

            migrationBuilder.CreateTable(
                name: "Cinsiyet",
                columns: table => new
                {
                    CinsiyetID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CinsiyetAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyet", x => x.CinsiyetID);
                });

            migrationBuilder.CreateTable(
                name: "Dereceler",
                columns: table => new
                {
                    DereceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DereceAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dereceler", x => x.DereceID);
                });

            migrationBuilder.CreateTable(
                name: "Durumlar",
                columns: table => new
                {
                    DurumID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DurumAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durumlar", x => x.DurumID);
                });

            migrationBuilder.CreateTable(
                name: "HastaneTurleri",
                columns: table => new
                {
                    HastaneTurID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HastaneTurAdi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaneTurleri", x => x.HastaneTurID);
                });

            migrationBuilder.CreateTable(
                name: "KisiTipleri",
                columns: table => new
                {
                    KisiTipiID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KisiTipiAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiTipleri", x => x.KisiTipiID);
                });

            migrationBuilder.CreateTable(
                name: "MuayeneTurleri",
                columns: table => new
                {
                    MuayeneTurID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MuayeneTurAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuayeneTurleri", x => x.MuayeneTurID);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    PoliklinikID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PoliklinikAdi = table.Column<int>(type: "integer", nullable: false),
                    BransID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.PoliklinikID);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_Branslar_BransID",
                        column: x => x.BransID,
                        principalTable: "Branslar",
                        principalColumn: "BransID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoktorAdi = table.Column<string>(type: "text", nullable: false),
                    DoktorSoyadi = table.Column<string>(type: "text", nullable: false),
                    DoktordtGun = table.Column<int>(type: "integer", nullable: false),
                    DoktordtAy = table.Column<int>(type: "integer", nullable: false),
                    DoktordtYil = table.Column<int>(type: "integer", nullable: false),
                    CinsiyetID = table.Column<int>(type: "integer", nullable: false),
                    DoktorTelNo = table.Column<string>(type: "text", nullable: false),
                    DoktorEmail = table.Column<string>(type: "text", nullable: false),
                    DereceID = table.Column<int>(type: "integer", nullable: false),
                    BransID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.DoktorID);
                    table.ForeignKey(
                        name: "FK_Doktorlar_Branslar_BransID",
                        column: x => x.BransID,
                        principalTable: "Branslar",
                        principalColumn: "BransID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doktorlar_Cinsiyet_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyet",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doktorlar_Dereceler_DereceID",
                        column: x => x.DereceID,
                        principalTable: "Dereceler",
                        principalColumn: "DereceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    HastaneID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HastaneAdi = table.Column<string>(type: "text", nullable: false),
                    HastaneTurID = table.Column<int>(type: "integer", nullable: false),
                    HastaneAdresi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.HastaneID);
                    table.ForeignKey(
                        name: "FK_Hastaneler_HastaneTurleri_HastaneTurID",
                        column: x => x.HastaneTurID,
                        principalTable: "HastaneTurleri",
                        principalColumn: "HastaneTurID",
                        onDelete: ReferentialAction.Cascade);
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
                    KisiTipiID = table.Column<int>(type: "integer", nullable: false),
                    KullaniciSifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Cinsiyet_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyet",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_KisiTipleri_KisiTipiID",
                        column: x => x.KisiTipiID,
                        principalTable: "KisiTipleri",
                        principalColumn: "KisiTipiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciID = table.Column<int>(type: "integer", nullable: false),
                    BransID = table.Column<int>(type: "integer", nullable: false),
                    PoliklinikID = table.Column<int>(type: "integer", nullable: false),
                    HastaneID = table.Column<int>(type: "integer", nullable: false),
                    DoktorID = table.Column<int>(type: "integer", nullable: false),
                    DurumID = table.Column<int>(type: "integer", nullable: false),
                    MuayeneTurID = table.Column<int>(type: "integer", nullable: false),
                    RandevuGun = table.Column<int>(type: "integer", nullable: false),
                    RandevuAy = table.Column<int>(type: "integer", nullable: false),
                    RandevuYil = table.Column<int>(type: "integer", nullable: false),
                    Saat = table.Column<int>(type: "integer", nullable: false),
                    Dakika = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuID);
                    table.ForeignKey(
                        name: "FK_Randevular_Branslar_BransID",
                        column: x => x.BransID,
                        principalTable: "Branslar",
                        principalColumn: "BransID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Doktorlar_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Durumlar_DurumID",
                        column: x => x.DurumID,
                        principalTable: "Durumlar",
                        principalColumn: "DurumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Hastaneler_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hastaneler",
                        principalColumn: "HastaneID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_MuayeneTurleri_MuayeneTurID",
                        column: x => x.MuayeneTurID,
                        principalTable: "MuayeneTurleri",
                        principalColumn: "MuayeneTurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Poliklinikler_PoliklinikID",
                        column: x => x.PoliklinikID,
                        principalTable: "Poliklinikler",
                        principalColumn: "PoliklinikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branslar_BransID1",
                table: "Branslar",
                column: "BransID1");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_BransID",
                table: "Doktorlar",
                column: "BransID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_CinsiyetID",
                table: "Doktorlar",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_DereceID",
                table: "Doktorlar",
                column: "DereceID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastaneler_HastaneTurID",
                table: "Hastaneler",
                column: "HastaneTurID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_CinsiyetID",
                table: "Kullanicilar",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KisiTipiID",
                table: "Kullanicilar",
                column: "KisiTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_BransID",
                table: "Poliklinikler",
                column: "BransID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_BransID",
                table: "Randevular",
                column: "BransID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DurumID",
                table: "Randevular",
                column: "DurumID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HastaneID",
                table: "Randevular",
                column: "HastaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_KullaniciID",
                table: "Randevular",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_MuayeneTurID",
                table: "Randevular",
                column: "MuayeneTurID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PoliklinikID",
                table: "Randevular",
                column: "PoliklinikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Durumlar");

            migrationBuilder.DropTable(
                name: "Hastaneler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "MuayeneTurleri");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropTable(
                name: "Dereceler");

            migrationBuilder.DropTable(
                name: "HastaneTurleri");

            migrationBuilder.DropTable(
                name: "Cinsiyet");

            migrationBuilder.DropTable(
                name: "KisiTipleri");

            migrationBuilder.DropTable(
                name: "Branslar");
        }
    }
}

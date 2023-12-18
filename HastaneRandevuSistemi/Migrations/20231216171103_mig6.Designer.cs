﻿// <auto-generated />
using HastaneRandevuSistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231216171103_mig6")]
    partial class mig6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Brans", b =>
                {
                    b.Property<int>("BransID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BransID"));

                    b.Property<string>("BransAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BransID");

                    b.ToTable("Branslar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Cinsiyet", b =>
                {
                    b.Property<int>("CinsiyetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CinsiyetID"));

                    b.Property<string>("CinsiyetAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CinsiyetID");

                    b.ToTable("Cinsiyetler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Derece", b =>
                {
                    b.Property<int>("DereceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DereceID"));

                    b.Property<string>("DereceAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DereceID");

                    b.ToTable("Dereceler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoktorID"));

                    b.Property<int>("BransID")
                        .HasColumnType("integer");

                    b.Property<int>("CinsiyetID")
                        .HasColumnType("integer");

                    b.Property<int>("DereceID")
                        .HasColumnType("integer");

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoktorEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoktorSoyadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoktorTelNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DoktordtAy")
                        .HasColumnType("integer");

                    b.Property<int>("DoktordtGun")
                        .HasColumnType("integer");

                    b.Property<int>("DoktordtYil")
                        .HasColumnType("integer");

                    b.HasKey("DoktorID");

                    b.HasIndex("BransID");

                    b.HasIndex("CinsiyetID");

                    b.HasIndex("DereceID");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Durum", b =>
                {
                    b.Property<int>("DurumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DurumID"));

                    b.Property<string>("DurumAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DurumID");

                    b.ToTable("Durumlar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Hastane", b =>
                {
                    b.Property<int>("HastaneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HastaneID"));

                    b.Property<string>("HastaneAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HastaneAdresi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HastaneTurID")
                        .HasColumnType("integer");

                    b.HasKey("HastaneID");

                    b.HasIndex("HastaneTurID");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.HastaneTur", b =>
                {
                    b.Property<int>("HastaneTurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HastaneTurID"));

                    b.Property<string>("HastaneTurAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HastaneTurID");

                    b.ToTable("HastaneTurleri");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.KisiTipi", b =>
                {
                    b.Property<int>("KisiTipiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KisiTipiID"));

                    b.Property<string>("KisiTipiAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("KisiTipiID");

                    b.ToTable("KisiTipleri");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KullaniciID"));

                    b.Property<int>("CinsiyetID")
                        .HasColumnType("integer");

                    b.Property<int>("KisiTipiID")
                        .HasColumnType("integer");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciSifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciSoyadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciTelNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("KullanicidtAy")
                        .HasColumnType("integer");

                    b.Property<int>("KullanicidtGun")
                        .HasColumnType("integer");

                    b.Property<int>("KullanicidtYil")
                        .HasColumnType("integer");

                    b.HasKey("KullaniciID");

                    b.HasIndex("CinsiyetID");

                    b.HasIndex("KisiTipiID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.MuayeneTur", b =>
                {
                    b.Property<int>("MuayeneTurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MuayeneTurID"));

                    b.Property<string>("MuayeneTurAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MuayeneTurID");

                    b.ToTable("MuayeneTurleri");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Poliklinik", b =>
                {
                    b.Property<int>("PoliklinikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PoliklinikID"));

                    b.Property<int>("BransID")
                        .HasColumnType("integer");

                    b.Property<int>("PoliklinikAdi")
                        .HasColumnType("integer");

                    b.HasKey("PoliklinikID");

                    b.HasIndex("BransID");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RandevuID"));

                    b.Property<int>("BransID")
                        .HasColumnType("integer");

                    b.Property<int>("Dakika")
                        .HasColumnType("integer");

                    b.Property<int>("DoktorID")
                        .HasColumnType("integer");

                    b.Property<int>("DurumID")
                        .HasColumnType("integer");

                    b.Property<string>("HastaneAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HastaneID")
                        .HasColumnType("integer");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("integer");

                    b.Property<int>("MuayeneTurID")
                        .HasColumnType("integer");

                    b.Property<int>("PoliklinikID")
                        .HasColumnType("integer");

                    b.Property<int>("RandevuAy")
                        .HasColumnType("integer");

                    b.Property<int>("RandevuGun")
                        .HasColumnType("integer");

                    b.Property<int>("RandevuYil")
                        .HasColumnType("integer");

                    b.Property<int>("Saat")
                        .HasColumnType("integer");

                    b.HasKey("RandevuID");

                    b.HasIndex("BransID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("DurumID");

                    b.HasIndex("HastaneID");

                    b.HasIndex("KullaniciID");

                    b.HasIndex("MuayeneTurID");

                    b.HasIndex("PoliklinikID");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Doktor", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Brans", null)
                        .WithMany("Doktorlar")
                        .HasForeignKey("BransID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Cinsiyet", null)
                        .WithMany("Doktorlar")
                        .HasForeignKey("CinsiyetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Derece", null)
                        .WithMany("Doktorlar")
                        .HasForeignKey("DereceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Hastane", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.HastaneTur", null)
                        .WithMany("Hastaneeler")
                        .HasForeignKey("HastaneTurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Kullanici", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Cinsiyet", "Cinsiyet")
                        .WithMany("Kullanicilar")
                        .HasForeignKey("CinsiyetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.KisiTipi", null)
                        .WithMany("Kullanicilar")
                        .HasForeignKey("KisiTipiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinsiyet");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Poliklinik", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Brans", null)
                        .WithMany("Poliklinikler")
                        .HasForeignKey("BransID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Randevu", b =>
                {
                    b.HasOne("HastaneRandevuSistemi.Models.Brans", null)
                        .WithMany("Randevular")
                        .HasForeignKey("BransID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Doktor", null)
                        .WithMany("Randevular")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Durum", null)
                        .WithMany("Randevular")
                        .HasForeignKey("DurumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Hastane", null)
                        .WithMany("Randevular")
                        .HasForeignKey("HastaneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Kullanici", null)
                        .WithMany("Randevular")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.MuayeneTur", null)
                        .WithMany("Randevular")
                        .HasForeignKey("MuayeneTurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneRandevuSistemi.Models.Poliklinik", null)
                        .WithMany("Randevular")
                        .HasForeignKey("PoliklinikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Brans", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("Poliklinikler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Cinsiyet", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("Kullanicilar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Derece", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Doktor", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Durum", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Hastane", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.HastaneTur", b =>
                {
                    b.Navigation("Hastaneeler");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.KisiTipi", b =>
                {
                    b.Navigation("Kullanicilar");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Kullanici", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.MuayeneTur", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("HastaneRandevuSistemi.Models.Poliklinik", b =>
                {
                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}

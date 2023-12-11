using System;
using Microsoft.EntityFrameworkCore;
namespace HastaneRandevuSistemi.Models
{
	public class ApplicationDbContext:DbContext
	{
		public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Brans> Branslar{ get; set; }
        public DbSet<Derece> Dereceler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Durum> Durumlar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<HastaneTur> HastaneTurleri { get; set; }
        public DbSet<KisiTipi> KisiTipleri { get; set; }
        public DbSet<MuayeneTur> MuayeneTurleri { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=HastaneRandevuSistemi;User Id=postgres;Password=54321");
        }
    }
}


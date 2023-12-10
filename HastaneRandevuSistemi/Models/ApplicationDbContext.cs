using System;
using Microsoft.EntityFrameworkCore;
namespace HastaneRandevuSistemi.Models
{
	public class ApplicationDbContext:DbContext
	{
		public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Cinsiyet> Cinsiyetler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=HastaneRandevuSistemi;User Id=postgres;Password=54321");
        }
    }
}


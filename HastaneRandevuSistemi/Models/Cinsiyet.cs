using System;
namespace HastaneRandevuSistemi.Models
{
	public class Cinsiyet
	{
		public int CinsiyetID { get; set; }
		public string CinsiyetAdi { get; set; }
		public ICollection<Kullanici> Kullanicilar { get; set; }
        public ICollection<Doktor> Doktorlar { get; set; }
    }
}


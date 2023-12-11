using System;
namespace HastaneRandevuSistemi.Models
{
	public class Poliklinik
	{
		public int PoliklinikID{ get; set; }
        public int PoliklinikAdi { get; set; }
		public int BransID { get; set; }
		public ICollection<Randevu> Randevular { get; set; }
    }
}


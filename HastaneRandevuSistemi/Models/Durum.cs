using System;
namespace HastaneRandevuSistemi.Models
{
	public class Durum
	{
		public int DurumID{ get; set; }
        public string DurumAdi { get; set; }
        public ICollection<Randevu> Randevular{ get; set; }
    }
}


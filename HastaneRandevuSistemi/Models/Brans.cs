using System;
namespace HastaneRandevuSistemi.Models
{
	public class Brans
	{
        public int BransID { get; set; }
        public string BransAdi { get; set; }
        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Poliklinik> Poliklinikler { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}


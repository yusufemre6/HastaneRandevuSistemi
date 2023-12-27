using System;
namespace HastaneRandevuSistemi.Models
{
	public class Hastane
	{
		public int HastaneID { get; set; }
        public string HastaneAdi { get; set; }
        public int HastaneTurID { get; set; }
        public string HastaneAdresi { get; set; }
        public ICollection<Randevu> Randevular{ get; set; }
        public ICollection<Poliklinik> Poliklinikler { get; set; }
    }
}


using System;
namespace HastaneRandevuSistemi.Models
{
	public class HastaneTur
	{
		public int HastaneTurID { get; set; }
        public string HastaneTurAdi { get; set; }
		public ICollection<Hastane> Hastaneeler { get; set; }
    }
}
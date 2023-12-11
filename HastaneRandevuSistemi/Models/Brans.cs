using System;
namespace HastaneRandevuSistemi.Models
{
	public class Brans
	{
        public int BransID { get; set; }
        public string BransAdi { get; set; }
        public ICollection<Doktor> Doktorlar { get; set; }
    }
}


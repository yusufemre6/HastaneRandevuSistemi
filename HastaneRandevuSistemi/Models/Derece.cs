using System;
namespace HastaneRandevuSistemi.Models
{
	public class Derece
	{
        public int DereceID { get; set; }
        public string DereceAdi { get; set; }
        public ICollection<Doktor> Doktorlar{ get; set; }
    }
}


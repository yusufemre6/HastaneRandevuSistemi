using System;
namespace HastaneRandevuSistemi.Models
{
	public class KisiTipi
	{
        public int KisiTipiID{ get; set; }
        public string KisiTipiAdi { get; set; }
        public ICollection<Kullanici> Kullanicilar { get; set; }
    }
}


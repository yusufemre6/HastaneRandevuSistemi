using System;
using System.ComponentModel.DataAnnotations;
namespace HastaneRandevuSistemi.Models
{
	public class Randevu
	{
		public int RandevuID{ get; set; }
        public int KullaniciID { get; set; }
        public int BransID { get; set; }
        public int PoliklinikID { get; set; }
        public int HastaneID { get; set; }
        public int DoktorID { get; set; }
        public int DurumID{ get; set; }
        public int MuayeneTurID { get; set; }
        public DateTime RandevuTarihSaat { get; set; }
    }
}


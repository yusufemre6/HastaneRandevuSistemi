using System;
namespace HastaneRandevuSistemi.Models
{
	public class DoktorModel
	{
        public int DoktorID { get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
        public DateTime DoktorDt { get; set; }
        public int CinsiyetID { get; set; }
        public string DoktorTelNo { get; set; }
        public string DoktorEmail { get; set; }
        public int DereceID { get; set; }
        public int BransID { get; set; }
        public int HastaneID { get; set; }
    }
}


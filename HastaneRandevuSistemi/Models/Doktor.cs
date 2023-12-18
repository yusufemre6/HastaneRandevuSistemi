using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models;

public class Doktor{
    public int DoktorID { get; set; }
    public string DoktorAdi { get; set; }
    public string DoktorSoyadi { get; set; }
    public int DoktordtGun { get; set; }
    [Required(ErrorMessage = "Dogum Ayı Giriniz!")]
    public int DoktordtAy { get; set; }
    [Required(ErrorMessage = "Dogum Yılı Giriniz!")]
    public int DoktordtYil { get; set; }
    public int CinsiyetID { get; set; }
    public string DoktorTelNo { get; set; }
    public string DoktorEmail { get; set; }
    public int DereceID { get; set; }
    public int BransID { get; set; }
    public ICollection<Poliklinik> Poliklinikler { get; set; }
    public ICollection<Randevu> Randevular { get; set; }
    
}
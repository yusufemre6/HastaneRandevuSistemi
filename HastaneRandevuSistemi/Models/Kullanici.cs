using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models;

public class Kullanici {

    [Key]
    public int KullaniciID { get; set; }
    
    public string KullaniciAdi { get; set; }
    
    public string KullaniciSoyadi { get; set; }
    
    public DateTime KullaniciDt { get; set; }
   
    [Display(Name ="Cinsiyet")]
    public int CinsiyetID { get; set; }
    
    public string KullaniciTelNo { get; set; }
    
    public string KullaniciEmail { get; set; }
    
    public string KullaniciSifre { get; set; }
    
    public ICollection<Randevu> Randevular { get; set; }
    public ICollection<Rol> Roller { get; set; }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models;

public class Kullanici {

    [Key]
    public int KullaniciID { get; set; }
    //[Required(ErrorMessage = "Adınızı Giriniz!")]
    public string KullaniciAdi { get; set; }
    //[Required(ErrorMessage = "Soyadınızı Giriniz!")]
    public string KullaniciSoyadi { get; set; }
    //[Required(ErrorMessage = "Dogum Günü Giriniz!")]
    public int KullanicidtGun { get; set; }
    //[Required(ErrorMessage = "Dogum Ayı Giriniz!")]
    public int KullanicidtAy { get; set; }
    //[Required(ErrorMessage = "Dogum Yılı Giriniz!")]
    public int KullanicidtYil { get; set; }
    //[Required(ErrorMessage = "Cinsiyet Giriniz!")]
    [Display(Name ="Cinsiyet")]
    public int CinsiyetID { get; set; }
    public Cinsiyet Cinsiyet { get; set; }
    //[Phone(ErrorMessage="Geçerli Telefon Numarası Giriniz!")]
    //[Required(ErrorMessage = "Telefon Numarası Giriniz!")]
    public string KullaniciTelNo { get; set; }
    //[Required(ErrorMessage="Mail Adresi Giriniz!")]
    public string KullaniciEmail { get; set; }
    //[Required(ErrorMessage="Şifrenizi Giriniz!")]
    public string KullaniciSifre { get; set; }
    public ICollection<Randevu> Randevular { get; set; }
    public ICollection<Rol> Roller { get; set; }
}
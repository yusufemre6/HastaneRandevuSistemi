using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models;

public class Kullanici{
    [Required(ErrorMessage="Adınızı Giriniz!")]
    public string Adi { get; set; }
    [Required(ErrorMessage="Soyadınızı Giriniz!")]
    public string Soyadi { get; set; }
    [Required(ErrorMessage="Dogum Günü Giriniz!")]
    public int dtGun { get; set; }
    [Required(ErrorMessage="Dogum Ayı Giriniz!")]
    public int dtAy { get; set; }
    [Required(ErrorMessage="Dogum Yılı Giriniz!")]
    public int dtYil { get; set; }
    public bool Cinsiyet { get; set; }
    [Phone(ErrorMessage="Geçerli Telefon Numarası Giriniz!")]
    [Required(ErrorMessage = "Telefon Numarası Giriniz!")]
    public string TelNo { get; set; }
    [Required(ErrorMessage="Mail Adresi Giriniz!")]
    public string Email { get; set; }
    public string Rol { get; set; }
    [Required(ErrorMessage="Şifrenizi Giriniz!")]
    public string Sifre { get; set; }
    [Compare("Sifre" ,ErrorMessage="Şifreler Eşleşmemektedir!")]
    public string SifreDogrulama { get; set; }
}
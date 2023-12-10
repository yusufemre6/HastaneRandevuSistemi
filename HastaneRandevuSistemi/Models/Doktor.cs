using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models;

public class Doktor{
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public int dtGun { get; set; }
    [Required(ErrorMessage = "Dogum Ayı Giriniz!")]
    public int dtAy { get; set; }
    [Required(ErrorMessage = "Dogum Yılı Giriniz!")]
    public int dtYil { get; set; }
    public string Cinsiyet { get; set; }
    public string TelNo { get; set; }
    public string Email { get; set; }
    public string Derece { get; set; }
    public string Brans { get; set; }
}
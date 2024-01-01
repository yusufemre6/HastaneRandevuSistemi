using FluentValidation;

namespace HastaneRandevuSistemi.Models.Validators
{
	public class KullaniciValidator :AbstractValidator<Kullanici>
	{
		public KullaniciValidator()
		{
			RuleFor( x => x.KullaniciEmail).NotNull().WithMessage("Email boş olamaz");
			RuleFor(x => x.KullaniciEmail).EmailAddress().WithMessage("Lütfen Doğru bir email adressi giriniz ");
			RuleFor(x => x.KullaniciAdi).NotNull().NotEmpty().WithMessage("Ad boş olamaz");
			RuleFor(x => x.KullaniciSoyadi).NotNull().NotEmpty().WithMessage("soyAd boş olamaz");
			RuleFor(x => x.CinsiyetID).NotNull().NotEmpty().WithMessage("Cinsiyet boş olamaz");
			RuleFor(x => x.KullaniciTelNo).NotNull().NotEmpty().WithMessage("Telefon numarası boş olamaz");
			RuleFor(x => x.KullaniciSifre).NotNull().NotEmpty().WithMessage("Ad boş olamaz");
			


		}



	}
}

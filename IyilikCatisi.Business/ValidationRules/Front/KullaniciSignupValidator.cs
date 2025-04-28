using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Front;

namespace IyilikCatisi.Business.ValidationRules.Front
{
	public class KullaniciSignupValidator : AbstractValidator<KullaniciSignupVm>
	{

		IKullanicilarBS _kullaniciBS;
		public KullaniciSignupValidator(IKullanicilarBS kullaniciBS)
		{
			_kullaniciBS = kullaniciBS;
			RuleFor(x => x.Adi).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez");
			RuleFor(x => x.Soyadi).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez");
			RuleFor(x => x.Sifre).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").WithMessage("Şifreniz en az 8 karekterden oluşmalıdır. Ayrıca bir büyük harf, bir küçük harf ve bir özel ifade içermelidir(#?!@$%^&*- gibi)");

			RuleFor(x => x.SifreTekrar).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Equal(x => x.Sifre).WithMessage("Şifreler Eşleşmiyor");

			RuleFor(x => x.Email).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Must(KullaniliyorMu).WithMessage("Bu kullanıcı zaten kayıtlı, farklı bir emaille kayıt olmayı deneyiniz").EmailAddress().WithMessage("Lütfen Geçerli Bir Email Giriniz.");


			RuleFor(x => x.CepTel).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Must(KullaniliyorMuCepTel).WithMessage("Bu kullanıcı zaten kayıtlı, farklı bir telefon numarasıyla kayıt olmayı deneyiniz");
		}


		public bool KullaniliyorMu(string arg)
		{

			Kullanicilar k = _kullaniciBS.Get(x => x.Email == arg);
			if (k != null)
			{
				// Bu email kullanılıyor
				return false;
			}
			else
			{
				// email yok kayıt olabilirsin
				return true;
			}


		}

		public bool KullaniliyorMuCepTel(string arg)
		{

			Kullanicilar k = _kullaniciBS.Get(x => x.CepTel == arg);
			if (k != null)
			{
				// Bu tel kullanılıyor
				return false;
			}
			else
			{
				// tel yok kayıt olabilirsin
				return true;
			}


		}

	}

}

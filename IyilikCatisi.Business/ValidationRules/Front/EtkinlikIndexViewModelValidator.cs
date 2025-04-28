using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;

namespace IyilikCatisi.Business.ValidationRules.Front
{
	public class EtkinlikIndexViewModelValidator:AbstractValidator<EtkinlikIndexViewModel>
	{
		public EtkinlikIndexViewModelValidator() 
		{
			RuleFor(x => x.Baslik).NotNull().WithMessage("Lütfen Başlık Giriniz").NotEmpty().WithMessage("Lütfen Başlık Giriniz");

			RuleFor(x => x.Aciklama).NotNull().WithMessage("Lütfen Açıklama Giriniz").NotEmpty().WithMessage("Lütfen Açıklama Giriniz").MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz");

			RuleFor(x => x.Tarih).NotNull().WithMessage("Lütfen Tarihi Giriniz.").NotEmpty().WithMessage("Lütfen Tarihi Giriniz.");

			RuleFor(x => x.Konum).NotNull().WithMessage("Lütfen Konumu Giriniz.").NotEmpty().WithMessage("Lütfen Konumu Giriniz.");
		}
	}
}

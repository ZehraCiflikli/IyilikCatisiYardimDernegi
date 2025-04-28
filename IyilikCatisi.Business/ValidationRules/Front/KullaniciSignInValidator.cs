using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Front;
using FluentValidation;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;

namespace IyilikCatisi.Business.ValidationRules.Front
{
    public class KullaniciSignInValidator : AbstractValidator<KullaniciSignInVm>
    {

        IKullanicilarBS _kullaniciBS;
        public KullaniciSignInValidator(IKullanicilarBS kullaniciBS)
        {

            RuleFor(x => x.Sifre).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez");

            RuleFor(x => x.Email).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez");
        }

    }
}
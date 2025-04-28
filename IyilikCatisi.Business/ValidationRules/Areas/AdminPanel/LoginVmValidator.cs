using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;

namespace IyilikCatisi.Business.ValidationRules.Areas.AdminPanel
{
    public class LoginVmValidator:AbstractValidator<LoginVm>
    {
        public LoginVmValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen E-postanızı giriniz").NotEmpty().WithMessage("Lütfen E-postanızı giriniz");

            RuleFor(x=> x.Sifre).NotNull().WithMessage("Lütfen şifrenizi giriniz").NotEmpty().WithMessage("Lütfen şifrenizi giriniz").MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz");

            RuleFor(x => x.GuvenlikKodu).NotNull().WithMessage("Lütfen güvenlik kodunu giriniz.").NotEmpty().WithMessage("Lütfen güvenlik kodunu giriniz.");

        }
    }
}

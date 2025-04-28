using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.Statics;
using IyilikCatisi.WebCoreUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IyilikCatisi.WebCoreUI.Filters
{
    public class RolFilter:ActionFilterAttribute
    {
        private string[] _allowedRols;
        public RolFilter(params string[] allowedRols)
        {
            _allowedRols = allowedRols;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Kullanicilar kullanici = context.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifYonetici);
            bool Allowed = false;

            foreach (KullaniciRol rol in kullanici.KullaniciRols)
            {

                foreach (string item in _allowedRols)
                {
                    if (rol.Rol.RolAdi == item)
                    {
                        Allowed = true;
                        break;
                    }
                }
            }

            if (!Allowed)
            {
                context.Result = new RedirectResult("/AdminPanel/Yonetici/YetkinizYok");

            }
            base.OnActionExecuting(context);
        }
    }
}

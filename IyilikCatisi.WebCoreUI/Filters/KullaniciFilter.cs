using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.Statics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using IyilikCatisi.WebCoreUI.Extensions;

namespace IyilikCatisi.WebCoreUI.Filters
{
    public class KullaniciFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //action metot çalıştırılmadan önceki kodlar

            Kullanicilar kullanici = context.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifKullanici);
            if (kullanici == null)
            {

                context.Result = new RedirectResult("/Kullanici/Login");

            }



            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
    
}

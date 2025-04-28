using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.Statics;
using IyilikCatisi.WebCoreUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IyilikCatisi.WebCoreUI.Filters
{
    public class YoneticiFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //action metot çalıştırılmadan önceki kodlar

            Kullanicilar kullanici = context.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifYonetici);
            if (kullanici == null)
            {

                context.Result = new RedirectResult("/AdminPanel/Yonetici/Login");

            }



            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}

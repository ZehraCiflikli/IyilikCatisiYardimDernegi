using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.Statics;
using IyilikCatisi.WebCoreUI.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IyilikCatisi.WebCoreUI.Filters
{
    public class MenuFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string path=context.HttpContext.Request.Path.Value ?? "";

            IMenuBs _menuBs = (IMenuBs)context.HttpContext.RequestServices.GetService(typeof(IMenuBs));

            Menu menu = _menuBs.Get(x => x.Url == path, false, "MenuYetkis", "MenuYetkis.Rol", "MenuYetkis.Rol.KullaniciRols", "MenuYetkis.Rol.KullaniciRols.Kullanici");

            Kullanicilar kullanici = context.HttpContext.Session.GetObject<Kullanicilar>(SessionKeys.AktifYonetici);

            bool Allowed = false;

            foreach(MenuYetki myetki in menu.MenuYetkis)
            {
                foreach(KullaniciRol krol in kullanici.KullaniciRols)
                {
                    if(myetki.SelectYetki==true && krol.Id==myetki.RolId)
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
            {
                
            }

            base.OnActionExecuting(context);
        }
    }
}

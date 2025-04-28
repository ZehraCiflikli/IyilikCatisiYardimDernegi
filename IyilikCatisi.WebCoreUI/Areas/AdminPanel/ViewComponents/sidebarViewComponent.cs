using Infrastructure.Enum;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using IyilikCatisi.WebCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class sidebarViewComponent:ViewComponent
    {
        IMenuBs _menuBs;
        ISessionManager _session;
        public sidebarViewComponent(IMenuBs menuBs,ISessionManager session)
        { 
            _menuBs = menuBs;
            _session = session;
        
        }
        public IViewComponentResult Invoke()
        {
            
            var menuler = _menuBs.GetAll(filter: x => x.Aktif == true, orderby:x=>x.Sira, sorted:Sorted.ASC, Tracking:false, "MenuYetkis", "MenuYetkis.Rol", "MenuYetkis.Rol.KullaniciRols", "MenuYetkis.Rol.KullaniciRols.Kullanici");
            SideBarViewModel model = new SideBarViewModel();
            model.Menuler = menuler;
            return View(model);
        }
    }
}

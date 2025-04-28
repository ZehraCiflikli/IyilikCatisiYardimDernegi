using Infrastructure.Enum;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using IyilikCatisi.Model.ViewModel.Areas.StandartKullaniciPanel;
using IyilikCatisi.WebCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.StandartKullaniciPanel.ViewComponents
{
    public class yanMenuViewComponent : ViewComponent
    {
        IMenuBs _menuBs;
        ISessionManager _session;
        public yanMenuViewComponent(IMenuBs menuBs, ISessionManager session)
        {
            _menuBs = menuBs;
            _session = session;

        }
        public IViewComponentResult Invoke()
        {
            var menuler = _menuBs.GetAll(filter: x => x.Aktif == true, orderby: x => x.Sira, sorted: Sorted.ASC, Tracking: false, "MenuYetkis", "MenuYetkis.Rol", "MenuYetkis.Rol.KullaniciRols", "MenuYetkis.Rol.KullaniciRols.Kullanici");
            YanMenuViewModel model = new YanMenuViewModel();
            model.Menuler = menuler;
            return View(model);
        }
    }
}

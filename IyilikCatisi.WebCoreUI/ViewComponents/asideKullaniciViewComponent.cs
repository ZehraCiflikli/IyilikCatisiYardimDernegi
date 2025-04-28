using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.MVCCoreUI.ViewComponents
{
    public class asideKullaniciViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}

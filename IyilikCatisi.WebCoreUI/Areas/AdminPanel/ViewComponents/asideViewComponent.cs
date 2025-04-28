using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class asideViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}

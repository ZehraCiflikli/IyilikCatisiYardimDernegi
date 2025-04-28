using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class mainHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}

using IyilikCatisi.WebCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{

	[Area("AdminPanel")]
	[YoneticiFilter]
	public class PanelController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

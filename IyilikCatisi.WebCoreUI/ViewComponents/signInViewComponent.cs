using IyilikCatisi.Model.ViewModel.Front;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.ViewComponents
{
	public class signInViewComponent: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			KullaniciSignInVm model = new KullaniciSignInVm();
			return View(model);

		}
	}
}

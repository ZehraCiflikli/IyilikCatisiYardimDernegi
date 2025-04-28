using IyilikCatisi.Model.ViewModel.Front;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.ViewComponents
{
	public class signUpViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			KullaniciSignupVm model = new KullaniciSignupVm();
			return View(model);
		}

	}
}

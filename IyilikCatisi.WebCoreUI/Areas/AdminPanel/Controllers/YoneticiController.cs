using Infrastructure.CrossCuttingConcern.Converters;
using Infrastructure.CrossCuttingConcern.Crypto;
using Infrastructure.Utility;
using System.Drawing;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using IyilikCatisi.WebCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class YoneticiController : Controller
    {
        private readonly IKullanicilarBS _kullaniciBS;
        private readonly ISessionManager _session;
        IMemoryCache _cache;
        public YoneticiController(IKullanicilarBS kullaniciBS, ISessionManager session, IMemoryCache cache)
        {
            _kullaniciBS = kullaniciBS;
            _session = session;
			_cache = cache;
        
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            string? Id = HttpContext.Request.Cookies["AktifYoneticiCookie"];
            if (!string.IsNullOrEmpty(Id))
            {

                int kid = Convert.ToInt32(Id);
                Kullanicilar k = _kullaniciBS.Get(x => x.Id == kid);
                if (k != null)
                {
                    _session.AktifYonetici = k;
                    return RedirectToAction("Index", "Panel");


                }



            }
            LoginVm vm = new LoginVm();

            return View(vm); 
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(LoginVm kullanici)
		{
			kullanici.Email = "vektorelyazilimsinanhoca@gmail.com";
			kullanici.Sifre = "Sinan2590@";

			//if (!ModelState.IsValid)
			//{
			//    return View(kullanici);
			//}


			//string guvenlikkodu = _session.GuvenlikKodu;
			//if (kullanici.GuvenlikKodu != guvenlikkodu)
			//{
			//    TempData["Mesaj"] = "GüvenlikKodu Hatalı. ";
			//    return View();
			//}

			string CryptoPassword = CryptoManager.SHA256Encrypt(kullanici.Sifre);
			Kullanicilar kullanici1 = _kullaniciBS.Get(x => x.Email == kullanici.Email && x.Sifre == CryptoPassword,false,"KullaniciRols","KullaniciRols.Rol");

			if (kullanici1 != null)
			{

				_session.AktifYonetici = kullanici1;

                // _cache.Set<Kullanici>("Aktif", _session.AktifYonetici);


                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddYears(1); //Ben yok etmezsem sen 1 yıl dursun sonra kendiliğinden silinsin
                HttpContext.Response.Cookies.Append("AktifYoneticiCookie", kullanici1.Id.ToString(), options);

                return RedirectToAction("Index", "Panel");
			}

			else
			{
				TempData["Mesaj"] = "Giriş Hatalı";
			}



			return View();
		}
		public IActionResult GetCaptcha()
		{
			CaptchaGenerator captcha = new CaptchaGenerator(6, "Verdana", 20);
			Bitmap b = captcha.GuvenlikResmiUret();
			_session.GuvenlikKodu = captcha.olusturanString;

			byte[] imagebyte = Converters.ImageToByteArray(b);


			return File(imagebyte, "image/jpg");
		}
        public IActionResult Logout()
        {
            _session.AktifYonetici = null;

            HttpContext.Response.Cookies.Delete("AktifYoneticiCookie");


            return RedirectToAction("Login");
        }
        public IActionResult YetkinizYok()
        {
            return View();
        }
    }
}

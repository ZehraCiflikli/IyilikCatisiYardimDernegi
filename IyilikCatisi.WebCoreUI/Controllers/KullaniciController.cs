using System.Drawing;
using AutoMapper;
using Infrastructure.CrossCuttingConcern.Comunication;
using Infrastructure.CrossCuttingConcern.Converters;
using Infrastructure.CrossCuttingConcern.Crypto;
using Infrastructure.Utility;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using IyilikCatisi.Model.ViewModel.Front;
using IyilikCatisi.WebCoreUI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IyilikCatisi.WebCoreUI.Controllers
{

    public class KullaniciController : Controller
    {

        IKullanicilarBS _kullaniciBS;
        IMapper _mapper;
        MailIslemleri _mailIslemleri;
        IConfiguration _conf;
		IKullaniciRolBS _kullaniciRolBS;
		ISessionManager _session;
		


		public KullaniciController(IKullanicilarBS kullaniciBS, IMapper mapper, MailIslemleri mailIslemleri, IConfiguration conf, IKullaniciRolBS kullaniciRolBS, ISessionManager session)
		{
			_kullaniciBS = kullaniciBS;
			_mapper = mapper;
			_mailIslemleri = mailIslemleri;
			_conf = conf;
			_kullaniciRolBS = kullaniciRolBS;
			_session = session;
		}




		[HttpPost]
		
        public IActionResult Add(KullaniciSignupVm vm)
        {


            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage).ToList();

				// Model State üzerinden  RuleFor(x => x.Adi) da belirtilen ifade key onun la iilgili dönene mesaj da value olacak şekilde bir nesne oluşturup cshtml tarafına dönüp ilgili nesneleri yakalayabiliriz.

				return View("Login",vm);//Json(new { result = false, errors = errors, mesaj = "Bilgilerinizi Kontrol Ediniz" });
            }


            Kullanicilar kullanici = _mapper.Map<Kullanicilar>(vm);
            //kullanici.Sifre = CryptoManager.SHA256Encrypt(vm.Sifre);
            kullanici.Sifre = CryptoManager.AESEncrypt(vm.Sifre, "SparkMarketKey");
            kullanici.UniqueId = Guid.NewGuid();
            kullanici.Aktif = true;



            kullanici = _kullaniciBS.Insert(kullanici);

			KullaniciRol kullaniciRol = new KullaniciRol();
			kullaniciRol.KullaniciId=kullanici.Id;
			kullaniciRol.RolId = 5;
			kullaniciRol.Aktif = true;

			_kullaniciRolBS.Insert(kullaniciRol);

			// Mail Gönderme İşlemi Yapılacak.
			string website = _conf.GetSection("websitehost").Value;
            _mailIslemleri.Send(kullanici.Email, "SparkMarket", "Merhaba " + kullanici.Adi + " İyilik Çatısı derneğine hoşgeldiniz <br><a href='" + website + "/Kullanici/EmailOnay/" + kullanici.UniqueId + "'> Lütfen emailinizi onaylamak için tıklayınız.</a>");

            // Mail Atarak Mail Onay İşlemi Yapılacak
            return View("KayitOnay");


        }



        public IActionResult EmailOnay(Guid id)
        {

            Kullanicilar k = _kullaniciBS.Get(x => x.UniqueId == id);

            if (k == null)
            {
                return RedirectToAction("EmailOnay", "Kullanici");// ??????
            }
            else
            {
                k.Aktif = true;
				k.EpostaOnay = true;
                k.UniqueId = Guid.NewGuid();
                _kullaniciBS.Update(k);
                return View();
            }

        }


        public IActionResult YetkisizIslem()
		{
            return View();
        }

        public IActionResult KayitOnay()
        {
            return View();
        }


        public IActionResult Login()
		{
            string? Id = HttpContext.Request.Cookies["AktifKullaniciCookie"];
            if (!string.IsNullOrEmpty(Id))
            {

                int kid = Convert.ToInt32(Id);
                Kullanicilar k = _kullaniciBS.Get(x => x.Id == kid);
                if (k != null)
                {
                    _session.AktifKullanici = k;
                    return RedirectToAction("Index", "KullaniciPanel","StandartKullanici");


                }

            }
			return View();
			
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		//   ASP.NET Core'da Siteler Arası İstek Sahteciliği (XSRF/CSRF) saldırılarını önleme
		public IActionResult Login(KullaniciSignInVm model)
		{

			//if (!ModelState.IsValid)
			//{
			//	return View(model);
			//}

			if (!ModelState.IsValid)
			{

				var errors = ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage).ToList();

				// Model State üzerinden  RuleFor(x => x.Adi) da belirtilen ifade key onun la iilgili dönene mesaj da value olacak şekilde bir nesne oluşturup cshtml tarafına dönüp ilgili nesneleri yakalayabiliriz.

				return Json(new { result = false, errors = errors, mesaj = "Bilgilerinizi Kontrol Ediniz" });
			}


			string CryptoPassword = CryptoManager.AESEncrypt(model.Sifre, "SparkMarketKey");

            Kullanicilar kullanici = _kullaniciBS.Get(x => x.Email == model.Email && x.Sifre == CryptoPassword);


			if (kullanici != null && kullanici.EpostaOnay != null && kullanici.EpostaOnay==true)
			{
				_session.AktifKullanici = kullanici;

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1); //Ben yok etmezsem sen 1 gün dursun sonra kendiliğinden silinsin
                HttpContext.Response.Cookies.Append("AktifYoneticiCookie", kullanici.Id.ToString(), options);

                //return RedirectToAction("Index", "KullaniciPanel");
                return Json(new {result=true});
			}
			else if (kullanici.EpostaOnay == null || kullanici.EpostaOnay==false)
			{
				return Json(new { result = false, errors = new List<string> { "Lütfen Epostanızı Kontrol Edin!" } });
			}
			else 
			{
				// Hatalı Giriş
				TempData["Mesaj"] = "Giriş Hatalı. ";

			}

			return Json(new { result = false });
        }


	
		public IActionResult SifremiUnuttum()
		{
			return View();
		}


        [HttpPost]
        public IActionResult SifremiUnuttum(string Email)
        {
            Kullanicilar k = _kullaniciBS.Get(x => x.Email == Email);
            if (k == null)
            {
                return Json(new { result = false, message = "Kullanıcı Bulunamadı" });
            }
            else
            {

                //MailManager.Send("sinanarslanweb@gmail.com", "Şifre Hatırlatma", "Merhaba " + user.UserName + " <a href='http://localhost:5127/Kullanici/YeniSifre/" + user.UniqueId + "'> Şifrenizi yeniden oluşturmak için tıklayınız</a>"); // RouteValue

                _mailIslemleri.Send("sinanarslanweb@gmail.com", "Şifre Hatırlatma", "Merhaba " + k.Adi + " <a href='http://localhost:5127/Kullanici/YeniSifre?uniqueid=" + k.UniqueId + "'> Şifrenizi yeniden oluşturmak için tıklayınız</a>"); // QueryString 

            }

            return View();
        }


        public IActionResult YeniSifre(string uniqueid)
		{

			Kullanicilar kullanici = _kullaniciBS.Get(x => x.UniqueId.ToString() == uniqueid);

			if (kullanici == null)
			{
				return RedirectToAction("YetkinizYok");
			}
			return View();

		}
		////[AktifYoneticiFilter("Admin","Muhasebe")]
		///
		[HttpPost]
		public IActionResult YeniSifre(string uniqueid, string newPassword)
		{


			Kullanicilar kullanici = _kullaniciBS.Get(x => x.UniqueId.ToString() == uniqueid);

			if (kullanici == null)
			{
				return RedirectToAction("YetkinizYok");
			}
			else
			{
				kullanici.Sifre = newPassword;
				kullanici.UniqueId = Guid.NewGuid();

				_kullaniciBS.Update(kullanici);

			}


			return View();
		}



		
		//public IActionResult Dashboard()
		//      {





		//          return View();
		//      }

	}
}

using System.Drawing;
using AutoMapper;
using Infrastructure.CrossCuttingConcern.Comunication;
using Infrastructure.CrossCuttingConcern.Crypto;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Front;
using IyilikCatisi.WebCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IyilikCatisi.WebCoreUI.Areas.StandartKullaniciPanel.Controllers
{
    [KullaniciFilter]
    [Area("StandartKullaniciPanel")]
    public class KullaniciPanelController : Controller
    {
        private readonly IKullanicilarBS _kullaniciBS;
        private readonly ISessionManager _session;
        private readonly IMapper _mapper;


        public KullaniciPanelController(IKullanicilarBS kullaniciBS, ISessionManager session, IMapper mapper)
        {
            _kullaniciBS = kullaniciBS;
            _session = session;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            KullaniciProfilVm model = _mapper.Map<KullaniciProfilVm>(_session.AktifKullanici);
            return View(model);
        }

        public IActionResult Guncelle(KullaniciProfilVm model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Hata"] = "Lütfen formu eksiksiz ve doğru doldurunuz.";
                return RedirectToAction("Index");
            }

            Kullanicilar k = _kullaniciBS.Get(x => x.Id == model.Id);

            k.Adi = model.Adi;
            k.Soyadi = model.Soyadi;
            k.Email = model.Email;
            k.CepTel = model.CepTel;
            k.TcKimlikNo = model.TcKimlikNo;
            k.DogumTarihi = model.DogumTarihi;
            k.Adres = model.Adres;


            if (!string.IsNullOrEmpty(model.YeniSifre) && !string.IsNullOrEmpty(model.YeniSifreTekrar))
            {
                // Mevcut şifrenin doğruluğunu kontrol et

                if (CryptoManager.AESDecrypt(k.Sifre, "SparkMarketKey") != model.Sifre)
                {
                    TempData["Hata"] = "Mevcut şifreyi yanlış girdiniz.";
                    return View(model);
                }

                // Yeni şifre ve tekrarının uyuştuğunu kontrol et
                if (model.YeniSifre != model.YeniSifreTekrar)
                {
                    TempData["Hata"] = "Yeni şifreler uyuşmuyor.";
                    return View(model);
                }

                // Yeni şifreyi şifrele ve güncelle
                if (!string.IsNullOrEmpty(model.YeniSifre))
                {
                    k.Sifre = CryptoManager.AESEncrypt(model.YeniSifre, "SparkMarketKey");
                }
            }





            // Profil resmi vs varsa buraya eklersin

            //if (model.ResimDosyasi != null )
            //{
               
            //    IFormFile file = model.ResimDosyasi;
                
                
            //        if (!file.ContentType.Contains("image/"))
            //        {
            //             TempData["Hata"] = "Lütfen bir resim dosyası seçiniz.";
            //             return View(model);
            //        }
            //        if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
            //        {
            //              TempData["Hata"] = "Resim 10MB'dan büyük olamaz.";
            //              return View(model);
                    
            //        }
            //        string extension = Path.GetExtension(file.FileName);
            //        string newFileName = DateTime.Now.Ticks.ToString() + extension;

            //        string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/kullanici/" + newFileName;
            //        using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
            //        {
            //            file.CopyTo(fs);
            //            k.Resim = "/images/kullanici/" + newFileName;
            //        }
                
            //}

            if (model.ResimDosyasi != null)
            {
                // Fotoğrafın geçerli bir formatta olduğundan emin olalım
                if (!model.ResimDosyasi.ContentType.Contains("image/"))
                {
                    TempData["Hata"] = "Lütfen bir resim dosyası seçiniz.";
                    return View(model);
                }

                // Fotoğrafın boyutunu kontrol edelim
                if (model.ResimDosyasi.Length > 10485760) // 10MB'dan büyükse
                {
                    TempData["Hata"] = "Resim 10MB'dan büyük olamaz.";
                    return View(model);
                }

                // Yeni fotoğrafı dosyaya kaydedelim
                string extension = Path.GetExtension(model.ResimDosyasi.FileName);
                string newFileName = DateTime.Now.Ticks.ToString() + extension;
                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "kullanici", newFileName);

                using (var fs = new FileStream(uploadpath, FileMode.Create))
                {
                    model.ResimDosyasi.CopyTo(fs);
                }

                // Resmin veritabanına kaydedilmesi
                k.Resim = "/images/kullanici/" + newFileName;
            }



            _kullaniciBS.Update(k);
            _session.AktifKullanici = k;

            TempData["Success"] = "Kullanıcı bilgileri başarıyla güncellenmiştir.";

            return RedirectToAction("Index");

          
        }




        public IActionResult Cikis()
        {
            _session.AktifKullanici = null;

            HttpContext.Response.Cookies.Delete("AktifKullaniciCookie");


            return RedirectToAction("Login", "Kullanici");
        }
    }
}

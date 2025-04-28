using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DernekController : Controller
    {
        private readonly IDernekBS _dernekBS;
        private readonly ITarihceBs _tarihceBS;
        private readonly ITuzukBS _tuzukBS;
        private readonly IYonetimKuruluBS _yonetimKuruluBS;
        private readonly IDenetimKuruluBS _denetimKuruluBS;
        private readonly IMapper _mapper;


        public DernekController(IDernekBS dernekBS, ITarihceBs tarihceBS, ITuzukBS tuzukBS, IYonetimKuruluBS yonetimKuruluBS, IDenetimKuruluBS denetimKuruluBS, IMapper mapper)
        {
            _dernekBS = dernekBS;
            _tarihceBS = tarihceBS;
            _tuzukBS = tuzukBS;
            _yonetimKuruluBS = yonetimKuruluBS;
            _denetimKuruluBS = denetimKuruluBS;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Tarihce()
        {
            Tarihce tarihce = _tarihceBS.GetAll().FirstOrDefault();
			return View(tarihce != null ? tarihce : new Tarihce());
        }

        [HttpPost]
        public IActionResult Tarihce(Tarihce tarihce)
        {
            if (tarihce.Id == 0)
                _tarihceBS.Insert(tarihce);
            else
                _tarihceBS.Update(tarihce);

            return RedirectToAction("Tarihce");
        }

        [HttpGet]
        public IActionResult Tuzuk()
        {
            Tuzuk tuzuk = _tuzukBS.GetAll().FirstOrDefault();
            return View(tuzuk != null ? tuzuk : new Tuzuk());
        }

        [HttpPost]
        public IActionResult Tuzuk(Tuzuk tuzuk)
        {
            if (tuzuk.Id == 0)
                _tuzukBS.Insert(tuzuk);
            else
                _tuzukBS.Update(tuzuk);

            return RedirectToAction("Tuzuk");
        }

        [HttpGet]
        public IActionResult YonetimKurulu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YonetimKuruluListele()
        {
            List<YonetimKurulu> yonetimKurulu = _yonetimKuruluBS.GetAll();

            return Json(new { data = yonetimKurulu });
        }


        public IActionResult YonetimKuruluAktifPasif(int id, bool aktif)
        {
            YonetimKurulu yonetimKurulu = _yonetimKuruluBS.Get(x => x.Id == id);
            yonetimKurulu.Aktif = aktif;
            _yonetimKuruluBS.Update(yonetimKurulu);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }






        [HttpPost]
        public IActionResult YonetimKuruluEkle(IFormCollection data)
        {
           
            YonetimKurulu yk=new YonetimKurulu();
           
            yk.AdSoyadi = data["AdSoyadi"];
            yk.Unvan = data["Unvan"];
            yk.Eposta = data["Eposta"];
            yk.GoreveBaslangicTarihi = DateOnly.Parse(data["GoreveBaslangicTarihi"]);
            yk.Meslek = data["Meslek"];
            yk.İkamet = data["İkamet"];
            yk.Aciklama = data["Aciklama"];

            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/dernek/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        yk.Resim = "/images/dernek/" + newFileName;
                    }
                }

            }
            else
            {
				yk.Resim = "/adminassets/img/person.png";
			}
            _yonetimKuruluBS.Insert(yk);
            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult YonetimKurulunuGetir(int id)
        {


            YonetimKurulu yk = _yonetimKuruluBS.Get(x => x.Id == id);

            return Json(new { result = true, model = yk });

        }



        [HttpPost]
        public IActionResult YonetimKuruluGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            YonetimKurulu yk = _yonetimKuruluBS.Get(x => x.Id == Id);

            yk.AdSoyadi = data["AdSoyadi"];
            yk.Unvan = data["Unvan"];
            yk.Eposta = data["Eposta"];
            yk.GoreveBaslangicTarihi = DateOnly.Parse(data["GoreveBaslangicTarihi"].ToString());
            yk.Meslek = data["Meslek"];
            yk.İkamet = data["İkamet"];
            yk.Aciklama = data["Aciklama"];


            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/dernek/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        yk.Resim = "/images/dernek/" + newFileName;
                    }
                }

            }





            _yonetimKuruluBS.Update(yk);



            return Json(new { result = true, mesaj = "Yönetim Kurulu Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult YonetimKuruluSil(int id)
        {
            YonetimKurulu yk = _yonetimKuruluBS.Get(x => x.Id == id);

            _yonetimKuruluBS.Delete(yk);

            return Json(new { result = true });
        }


        [HttpGet]
        public IActionResult DenetimKurulu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DenetimKuruluListele()
        {
            List<DenetimKurulu> denetimKurulu = _denetimKuruluBS.GetAll();

            return Json(new { data = denetimKurulu });
        }


        public IActionResult DenetimKuruluAktifPasif(int id, bool aktif)
        {
            DenetimKurulu denetimKurulu = _denetimKuruluBS.Get(x => x.Id == id);
            denetimKurulu.Aktif = aktif;
            _denetimKuruluBS.Update(denetimKurulu);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }






        [HttpPost]
        public IActionResult DenetimKuruluEkle(IFormCollection data)
        {

            DenetimKurulu dk = new DenetimKurulu();
            
            dk.AdSoyad = data["AdSoyad"];
            dk.Unvan = data["Unvan"];
            dk.Eposta = data["Eposta"];
            dk.GoreveBaslangicTarihi = DateOnly.Parse(data["GoreveBaslangicTarihi"]);
            dk.Meslek = data["Meslek"];
            dk.İkamet = data["İkamet"];
          

            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/dernek/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        dk.Resim = "/images/dernek/" + newFileName;
                    }
                }

            }
            _denetimKuruluBS.Insert(dk);
            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult DenetimKurulunuGetir(int id)
        {


            DenetimKurulu dk = _denetimKuruluBS.Get(x => x.Id == id);

            return Json(new { result = true, model = dk });

        }



        [HttpPost]
        public IActionResult DenetimKuruluGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            DenetimKurulu dk = _denetimKuruluBS.Get(x => x.Id == Id);

            dk.AdSoyad = data["AdSoyad"];
            dk.Unvan = data["Unvan"];
            dk.Eposta = data["Eposta"];
            dk.GoreveBaslangicTarihi = DateOnly.Parse(data["GoreveBaslangicTarihi"].ToString());
            dk.Meslek = data["Meslek"];
            dk.İkamet = data["İkamet"];
            
           


            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/dernek/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        dk.Resim = "/images/dernek/" + newFileName;
                    }
                }

            }





            _denetimKuruluBS.Update(dk);



            return Json(new { result = true, mesaj = "Yönetim Kurulu Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult DenetimKuruluSil(int id)
        {
            DenetimKurulu dk = _denetimKuruluBS.Get(x => x.Id == id);

            _denetimKuruluBS.Delete(dk);

            return Json(new { result = true });


        }

        [HttpGet]
        public IActionResult DernekSayfaEkleme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DernekSayfaListele()
        {
            List<Dernek> dernek = _dernekBS.GetAll();

            return Json(new { data = dernek });
        }


        public IActionResult DernekSayfaAktifPasif(int id, bool aktif)
        {
            Dernek dernek = _dernekBS.Get(x => x.Id == id);
            dernek.Aktif = aktif;
            _dernekBS.Update(dernek);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }


        [HttpPost]
        public IActionResult DernekSayfaEkle(IFormCollection data)
        {

            Dernek dernek = new Dernek();
            dernek.SiraNo = Convert.ToInt32(data["SiraNo"]);
            dernek.SayfaAdi = data["SayfaAdi"];
            dernek.Icerik = data["Icerik"];
            

           
            _dernekBS.Insert(dernek);
            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult DernekSayfaGetir(int id)
        {


            Dernek dernek = _dernekBS.Get(x => x.Id == id);

            return Json(new { result = true, model = dernek });

        }



        [HttpPost]
        public IActionResult DernekSayfaGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Dernek dernek = _dernekBS.Get(x => x.Id == Id);

            dernek.SiraNo = Convert.ToInt32(data["SiraNo"]);
            dernek.SayfaAdi = data["SayfaAdi"];
            dernek.Icerik = data["Icerik"];

            _dernekBS.Update(dernek);



            return Json(new { result = true, mesaj = "Dernek Sayfası Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult DernekSayfaSil(int id)
        {
            Dernek dernek = _dernekBS.Get(x => x.Id == id);

            _dernekBS.Delete(dernek);

            return Json(new { result = true });


        }


    }
}

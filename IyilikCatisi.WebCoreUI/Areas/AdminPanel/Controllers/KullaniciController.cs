using AutoMapper;
using Infrastructure.CrossCuttingConcern.Crypto;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StackExchange.Redis;
using static StackExchange.Redis.Role;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class KullaniciController : Controller
    {
        private readonly IKullanicilarBS _kullaniciBS;
        private readonly IRollerBS _rolBS;
        private readonly IKullaniciRolBS _kullaniciRolBS;
        private readonly IMapper _mapper;
        public KullaniciController(IKullanicilarBS kullaniciBS, IRollerBS rolBS, IKullaniciRolBS kullaniciRolBS, IMapper mapper)
        {
            _kullaniciBS = kullaniciBS;
            _rolBS = rolBS;
            _kullaniciRolBS = kullaniciRolBS;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            KullaniciIndexViewModel model = new KullaniciIndexViewModel();
            model.Rols = _rolBS.GetAll().Select(x => new SelectListItem() { Text = x.RolAdi, Value = x.Id.ToString() }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult KullaniciListele()
        {
            List<Kullanicilar> kullanicilar = _kullaniciBS.GetAll(includelist: ["KullaniciRols", "KullaniciRols.Rol"]);
            List<KullaniciIndexViewModel> model = _mapper.Map<List<KullaniciIndexViewModel>>(kullanicilar);

            return Json(new {data = model });
        }
        public IActionResult KullaniciEkle(KullaniciIndexViewModel vm)  
        {
            Kullanicilar kullanici = _mapper.Map<Kullanicilar>(vm);
            kullanici.UniqueId = Guid.NewGuid();
            kullanici.Aktif = true;
            kullanici.Sifre = CryptoManager.AESEncrypt(vm.Sifre, "SparkMarketKey");
            kullanici.UyelikTarihi = DateTime.Now;
            kullanici.DogumTarihi = DateTime.Now;
             if (vm.KullaniciFoto != null)
            {
                IFormFile file = vm.KullaniciFoto;
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

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/kullanici/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        kullanici.Resim = "/images/kullanici/" + newFileName;
                    }
                }

            }
            Kullanicilar eklenenkullanici = _kullaniciBS.Insert(kullanici);
            string[] seciliRoller = vm.RolIds[0].Split(',');

            for (int i = 0; i < seciliRoller.Length; i++)
            {
                _kullaniciRolBS.Insert(new KullaniciRol { KullaniciId = eklenenkullanici.Id, RolId = int.Parse(seciliRoller[i]) });
            }

            return Json(new { result = true, mesaj = "Kullanıcı başarıyla eklendi." });
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Kullanicilar kullanici = _kullaniciBS.GetById(id);
            kullanici.Aktif = aktif;
            _kullaniciBS.Update(kullanici);
            return Json(new { result = true, mesaj = "Aktiflik başarıyla güncellendi." });
        }
        public IActionResult DigerBilgiler(int id)
        {
            Kullanicilar kullanici = _kullaniciBS.Get(x => x.Id == id);

            KullaniciIndexViewModel model = _mapper.Map<KullaniciIndexViewModel>(kullanici);


            return Json(new { result = true, model = model });
        }
        public IActionResult KullaniciBilgileriniGetir(int id)
        {


            Kullanicilar k = _kullaniciBS.Get(x => x.Id == id, includelist: ["KullaniciRols.Rol"]);
            KullaniciIndexViewModel model = _mapper.Map<KullaniciIndexViewModel>(k);

          


            return Json(new { result = true, model = model });

        }

        [HttpPost]
        public IActionResult Guncelle(IFormCollection data)
        {

            string[] yeniRoller = data["GRolIds"].ToString().Split(',');
            if (yeniRoller.Length <= 0)
                return Json(new { result = false, mesaj = "Rol Seçiniz!" });


            int Id = Convert.ToInt32(data["Id"]);
            Kullanicilar k = _kullaniciBS.Get(x => x.Id == Id);

            k.Adi = data["Adi"];
            k.Soyadi = data["Soyadi"];
            k.Email = data["Email"];
            k.CepTel = data["CepTel"];
            k.TcKimlikNo = Convert.ToInt32(data["TcKimlikNo"]);
            k.DogumTarihi = Convert.ToDateTime(data["DogumTarihi"]);
            k.Adres = data["Adres"];

            List<KullaniciRol> eskiRoller = _kullaniciRolBS.GetAll(x => x.KullaniciId == k.Id && x.Aktif == true);

            for (int i = 0; i < eskiRoller.Count; i++)
            {
                eskiRoller[i].Aktif = false;
                _kullaniciRolBS.Delete(eskiRoller[i]);
            }

            for (int i = 0; i < yeniRoller.Length; i++)
            {
                _kullaniciRolBS.Insert(new KullaniciRol { KullaniciId = k.Id, RolId = Convert.ToInt32(yeniRoller[i]),Aktif=true });
            }



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

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/kullanici/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        k.Resim = "/images/kullanici/" + newFileName;
                    }
                }

            }

            // Kullanıcıyı güncelle
            _kullaniciBS.Update(k);




            Kullanicilar yeni = _kullaniciBS.Get(x => x.Id == k.Id, includelist: ["KullaniciRols.Rol"]);
            KullaniciIndexViewModel model = _mapper.Map<KullaniciIndexViewModel>(yeni);



            return Json(new { result = true, mesaj = "Kullanıcı Başarıyla Güncellendi",model=model});
        }

        public IActionResult KullaniciSil(int id)
        {
            
            List<KullaniciRol> kroller = _kullaniciRolBS.GetAll(x => x.KullaniciId == id);
            for (int i = 0; i < kroller.Count(); i++)
            {
                _kullaniciRolBS.Delete(kroller[i]);
            }
                  
            _kullaniciBS.DeleteById(id);

            return Json(new { result = true, mesaj = "Kullanıcı başarıyla silindi." });
        }

        //public IActionResult RolModal(int id)
        //{
        //    Kullanici kullanici = kullaniciBS.Get(x => x.Id == id, includelist: ["KullaniciRols", "KullaniciRols.Rol"]);

        //    List<Rol> roller = rolBS.GetAll();

        //    KullaniciRolVm model = new KullaniciRolVm();
        //    model.KullaniciId = id;
        //    model.Roller = roller.Select(x => new SelectListItem() { Text = x.RolAdi, Value = x.Id.ToString(), Selected = kullanici.KullaniciRols.Select(x => x.RolId).Contains(x.Id) ? true : false }).ToList();

        //    return PartialView("RolModalPartial", model);
        //}

        //public IActionResult RolGuncelle(KullaniciIndexViewModel vm)
        //{
        //    List<KullaniciRol> kullaniciRol = _kullaniciRolBS.GetAll(x => x.KullaniciId == vm.Id);
        //    foreach (KullaniciRol item in kullaniciRol)
        //    {
        //        _kullaniciRolBS.Delete(item);
        //    }
        //    if (vm.RolIds != null)
        //    {
        //        foreach (int item in vm.RolIds)
        //        {
        //            _kullaniciRolBS.Insert(new KullaniciRol() { KullaniciId = vm.Id, RolId = item });
        //        }
        //    }

        //    return Json(new { result = true, mesaj = "Kullanıcı Roller başarıyla güncellendi" });
        //}
 

        //public IActionResult UpdateModal(int id)
        //{
        //    Kullanici kullanici = kullaniciBS.Get(x => x.Id == id, includelist: ["KullaniciTipiNavigation"]);
        //    KullaniciVm model = _mapper.Map<KullaniciVm>(kullanici);
        //    model.KullaniciTipleri = kullaniciTipiBS.GetAll().Select(x => new SelectListItem() { Text = x.KullaniciTipiAdi, Value = x.Id.ToString(), Selected = kullanici.KullaniciTipi == x.Id ? true : false }).ToList();
        //    return PartialView("UpdateModal", model);
        //}
        //public IActionResult Guncelle(KullaniciIndexViewModel vm)
        //{
        //    Kullanicilar kullanici = _kullaniciBS.GetById(vm.Id);
        //    kullanici.Adi = vm.Adi;
        //    kullanici.Soyadi = vm.Soyadi;
        //    kullanici.Email = vm.Email;
        //    kullanici.Sifre = vm.Sifre;
        //    _kullaniciBS.Update(kullanici);

        //    return Json(new { result = true, mesaj = "Kullanıcı başarıyla güncellendi." });
        //}


  
    }
}

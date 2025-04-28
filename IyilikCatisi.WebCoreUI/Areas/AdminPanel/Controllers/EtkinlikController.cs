using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class EtkinlikController : Controller
    {
        private readonly IEtkinlikBS _etkinlikBS;
        private readonly IEtkinlikFotograflariBS _etkinlikFotograflariBS;
        private readonly IMapper _mapper;
        public EtkinlikController(IEtkinlikBS etkinlikBS, IMapper mapper, IEtkinlikFotograflariBS etkinlikFotograflariBS)
        {
            _etkinlikBS = etkinlikBS;
            _mapper = mapper;
            _etkinlikFotograflariBS = etkinlikFotograflariBS;
        }
        public IActionResult Index()
        {
            EtkinlikIndexViewModel model = new EtkinlikIndexViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult EtkinlikListele()
        {
            List<Etkinlik> etkinlik = _etkinlikBS.GetAll(includelist: ["EtkinlikFotograflaris"]);
            List<EtkinlikIndexViewModel> model = _mapper.Map<List<EtkinlikIndexViewModel>>(etkinlik);

            return Json(new { data = model });
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Etkinlik etkinlik = _etkinlikBS.Get(x => x.Id == id);
            etkinlik.Aktif = aktif;
            _etkinlikBS.Update(etkinlik);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }

        [HttpPost]
        public IActionResult EtkinlikEkle(IFormCollection data)
        {

            Etkinlik e = new Etkinlik();
            DateOnly dateOnly;

			DateOnly.TryParse(data["Tarih"], out dateOnly);

			e.Baslik = data["Baslik"];
            e.Aciklama = data["Aciklama"];
            e.Tarih = dateOnly;

            e.Saat = TimeOnly.Parse(data["Saat"]);
            e.Konum = data["Konum"];
            e.Telefon = Convert.ToInt32(data["Telefon"]);

            Etkinlik etkinlik = _etkinlikBS.Insert(e);

            if (data.Files.Count != 0)
            {
                for (int i = 0; i < data.Files.Count; i++)
                {
                    IFormFile file = data.Files[i];
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

                        string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/etkinlik/" + newFileName;
                        using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                        {
                            file.CopyTo(fs);
                            _etkinlikFotograflariBS.Insert(new EtkinlikFotograflari { EtkinlikId=etkinlik.Id,Fotograf="/images/etkinlik/" + newFileName });
                            //yk.Resim = "/images/dernek/" + newFileName;
                        }
                    }
                }

            }
          
            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult EtkinlikGetir(int id)
        {


            Etkinlik e = _etkinlikBS.Get(x => x.Id == id, includelist: ["EtkinlikFotograflaris"]);

            EtkinlikIndexViewModel model = _mapper.Map<EtkinlikIndexViewModel>(e);

            return Json(new { result = true, model = model });

        }



        [HttpPost]
        public IActionResult EtkinlikGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Etkinlik e = _etkinlikBS.Get(x => x.Id == Id);

            e.Baslik = data["Baslik"];
            e.Aciklama = data["Aciklama"];
            e.Tarih = DateOnly.Parse(data["Tarih"]);
            e.Saat = TimeOnly.Parse(data["Saat"]);
            e.Konum = data["Konum"];
            e.Telefon = Convert.ToInt32(data["Telefon"]);


            if (data.Files.Count != 0)
            {
                for (int i = 0; i < data.Files.Count; i++)
                {
                    IFormFile file = data.Files[i];
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

                        string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/etkinlik/" + newFileName;
                        using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                        {
                            file.CopyTo(fs);
                            _etkinlikFotograflariBS.Insert(new EtkinlikFotograflari { EtkinlikId = e.Id, Fotograf = "/images/etkinlik/" + newFileName });
                           
                            //yk.Resim = "/images/dernek/" + newFileName;
                        }
                    }
                }

            }


            _etkinlikBS.Update(e);



            return Json(new { result = true, mesaj = "Etkinlik Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult EtkinlikSil(int id)
        {
            Etkinlik e = _etkinlikBS.Get(x => x.Id == id);

            _etkinlikBS.Delete(e);

            return Json(new { result = true });
        }
    }
}

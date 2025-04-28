using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HaberlerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHaberlerBS _haberlerBS;
        public HaberlerController(IHaberlerBS haberlerBS, IMapper mapper)
        {
            _haberlerBS = haberlerBS;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            HaberlerIndexViewModel model = new HaberlerIndexViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult HaberlerListele()
        {
            List<Haberler> haberler = _haberlerBS.GetAll();
            List<HaberlerIndexViewModel> model = _mapper.Map<List<HaberlerIndexViewModel>>(haberler);

            return Json(new { data = model });
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Haberler haber = _haberlerBS.Get(x => x.Id == id);
            haber.Aktif = aktif;
            _haberlerBS.Update(haber);

            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });
        }

        [HttpPost]
        public IActionResult HaberEkle(IFormCollection data)
        {
            Haberler h = new Haberler();
            h.Baslik = data["Baslik"];
            h.Yazar = data["Yazar"];
            h.Icerik = data["Icerik"];
            h.Etiketler = data["Etiketler"];
            h.YayinTarihi = DateOnly.Parse(data["YayinTarihi"]);
            //h.GoruntulenmeSayisi = Convert.ToInt32(data["GoruntulenmeSayisi"]);
            
            _haberlerBS.Insert(h);
            return Json(new { result = true });
        }

        [HttpPost]
        public IActionResult HaberGetir(int id)
        {
            Haberler h = _haberlerBS.Get(x => x.Id == id);
            return Json(new { result = true, model = h });
        }

        [HttpPost]
        public IActionResult HaberGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Haberler h = _haberlerBS.Get(x => x.Id == Id);

            h.Baslik = data["Baslik"];
            h.Yazar = data["Yazar"];
            h.Icerik = data["Icerik"];
            h.Etiketler = data["Etiketler"];
            h.YayinTarihi = DateOnly.Parse(data["YayinTarihi"]);
            //h.GoruntulenmeSayisi = Convert.ToInt32(data["GoruntulenmeSayisi"]);
            //h.GuncellemeTarihi = DateTime.Now;

            _haberlerBS.Update(h);
            return Json(new { result = true, mesaj = "Haber Başarıyla Güncellendi" });
        }

        [HttpPost]
        public IActionResult HaberSil(int id)
        {
            Haberler h = _haberlerBS.Get(x => x.Id == id);
            _haberlerBS.Delete(h);
            return Json(new { result = true });
        }
    }
} 
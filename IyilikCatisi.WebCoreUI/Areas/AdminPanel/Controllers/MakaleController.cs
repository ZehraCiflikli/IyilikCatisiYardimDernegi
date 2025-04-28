using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MakaleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMakalelerBS _makaleBS;
        public MakaleController(IMakalelerBS makaleBS, IMapper mapper)
        {
            _makaleBS = makaleBS;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            MakaleIndexViewModel model = new MakaleIndexViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult MakaleListele()
        {
            List<Makaleler> Makale = _makaleBS.GetAll();
            List<MakaleIndexViewModel> model = _mapper.Map<List<MakaleIndexViewModel>>(Makale);

            return Json(new { data = model });
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Makaleler makale = _makaleBS.Get(x => x.Id == id);
            makale.Aktif = aktif;
            _makaleBS.Update(makale);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }

        [HttpPost]
        public IActionResult MakaleEkle(IFormCollection data)
        {

            Makaleler m = new Makaleler();
            m.Baslik = data["Baslik"];
            m.Icerik = data["Icerik"];
            m.AnahtarKelime = data["AnahtarKelime"];
            m.YayinTarihi = DateOnly.Parse(data["YayinTarihi"]);
            //m.GoruntulenmeSayisi = Convert.ToInt32(data["GoruntulenmeSayisi"]);

            _makaleBS.Insert(m);
            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult MakaleGetir(int id)
        {


            Makaleler m = _makaleBS.Get(x => x.Id == id);

            return Json(new { result = true, model = m });

        }



        [HttpPost]
        public IActionResult MakaleGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Makaleler m = _makaleBS.Get(x => x.Id == Id);

            m.Icerik = data["Icerik"];
            m.AnahtarKelime = data["AnahtarKelime"];
            m.YayinTarihi = DateOnly.Parse(data["YayinTarihi"]);
           
           
            _makaleBS.Update(m);



            return Json(new { result = true, mesaj = "Makale Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult MakaleSil(int id)
        {
            Makaleler m = _makaleBS.Get(x => x.Id == id);

            _makaleBS.Delete(m);

            return Json(new { result = true });
        }
    }
}

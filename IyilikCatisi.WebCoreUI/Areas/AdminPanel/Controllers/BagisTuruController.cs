using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BagisTuruController : Controller
    {
        private readonly IBagisTuruBS _bagisTuruBS;
        private readonly IMapper _mapper;
        

        public BagisTuruController(IBagisTuruBS bagisTuruBS, IMapper mapper)
        {
            _bagisTuruBS = bagisTuruBS;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            BagisTuruIndexViewModel model = new BagisTuruIndexViewModel();
            model.BagisTuruListe = _bagisTuruBS.GetAll();

            return View(model);
        }


        [HttpPost]
        public IActionResult Listele()
        {
            List<BagisTuru> bagisTuru = _bagisTuruBS.GetAll().ToList();
            return Json(new { data = bagisTuru });
        }


        [HttpPost]
        public IActionResult Ekle(IFormCollection data)
        {
            BagisTuru b = new BagisTuru();
            b.BagisTuruAdi = data["BagisTuruAdi"];
            b.VarsayilanTutar =Convert.ToDecimal( data["VarsayilanTutar"]);
            _bagisTuruBS.Insert(b);

            List<BagisTuru> bagisTuru = _bagisTuruBS.GetAll();
            
            return Json(new { result = true, mesaj = "Bağış Türü Başarıyla Eklendi", model = bagisTuru });
        }


        public IActionResult AktifPasif(int id, bool aktif)
        {
            BagisTuru bt = _bagisTuruBS.Get(x => x.Id == id);
            bt.Aktif = aktif;
            _bagisTuruBS.Update(bt);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });
        }


        public IActionResult BagisTuruGetir(int id)
        {
            BagisTuru bt = _bagisTuruBS.Get(x => x.Id == id);
            BagisTuruIndexViewModel model = _mapper.Map<BagisTuruIndexViewModel>(bt);

            return Json(new { result = true, model = model });
        }


        [HttpPost]
        public IActionResult Guncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            BagisTuru bt = _bagisTuruBS.Get(x => x.Id == Id);
            bt.BagisTuruAdi = data["BagisTuruAdi"];
            bt.VarsayilanTutar = Convert.ToDecimal(data["VarsayilanTutar"]);
            _bagisTuruBS.Update(bt);

            List<BagisTuru> bagisTuru = _bagisTuruBS.GetAll();
            BagisTuruIndexViewModel model = new BagisTuruIndexViewModel();

            return Json(new { result = true, mesaj = "Bağış Türü Başarıyla Güncellendi" });

        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            BagisTuru bt = _bagisTuruBS.Get(x => x.Id == id);
            _bagisTuruBS.Delete(bt);

            return Json(new { result = true, mesaj = "Bağış Türü Başarıyla Silindi!" });
        }

       

    }
}

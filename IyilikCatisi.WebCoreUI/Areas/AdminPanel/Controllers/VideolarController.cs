using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class VideolarController : Controller
    {
        private readonly IVideolarBS _videolarBS;
        private readonly IMapper _mapper;
        public VideolarController(IVideolarBS videolarBS, IMapper mapper)
        {
            _videolarBS = videolarBS;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            VideolarIndexViewModel model = new VideolarIndexViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult VideoListele()
        {
            List<Videolar> Videolar = _videolarBS.GetAll();
            List<VideolarIndexViewModel> model = _mapper.Map<List<VideolarIndexViewModel>>(Videolar);

            return Json(new { data = model });
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Videolar Videolar = _videolarBS.Get(x => x.Id == id);
            Videolar.Aktif = aktif;
            _videolarBS.Update(Videolar);


            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }

        [HttpPost]
        public IActionResult VideoEkle(IFormCollection data)
        {

            Videolar v = new Videolar();
            v.SiraNo = Convert.ToInt32(data["SiraNo"]);
            v.VideoAdi = data["VideoAdi"];
            v.Video = data["Video"];
            v.Kaynak = "Youtube";
            v.VideoUrl = data["VideoUrl"];
         
            _videolarBS.Insert(v);

            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult VideolarGetir(int id)
        {


            Videolar v = _videolarBS.Get(x => x.Id == id);

            return Json(new { result = true, model = v });

        }



        [HttpPost]
        public IActionResult VideolarGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Videolar v = _videolarBS.Get(x => x.Id == Id);

            v.VideoAdi = data["VideoAdi"];
            v.Video = data["Video"];
            //v.Kaynak = data["Kaynak"];
            v.VideoUrl = data["VideoUrl"];

            _videolarBS.Update(v);

            return Json(new { result = true, mesaj = "Videolar Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult VideolarSil(int id)
        {
            Videolar f = _videolarBS.Get(x => x.Id == id);

            _videolarBS.Delete(f);

            return Json(new { result = true });
        }
    }
}

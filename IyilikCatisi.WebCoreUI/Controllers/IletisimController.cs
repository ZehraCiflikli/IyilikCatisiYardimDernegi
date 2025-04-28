using AutoMapper;
using Infrastructure.CrossCuttingConcern.Comunication;
using IyilikCatisi.Model.ViewModel.Front;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Controllers
{
    public class IletisimController : Controller
    {
        private readonly IMapper _mapper;
        public IletisimController(IMapper mapper)
        { 
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IletisimViewModel model = new IletisimViewModel();
            return View(model);
        }
        //[HttpPost]
        //public JsonResult Mail(IletisimViewModel model)
        //{
        //    MailIslemleri mailIslemleri = new MailIslemleri();
        //    bool sonuc = mailIslemleri.Send("zehraciflikli@gmail.com", model.Konu, model.Icerik);
        //    return Json(new { result = sonuc, mesaj = sonuc ? "Başarılı" : "Başarısız" });
        //}
    }
}

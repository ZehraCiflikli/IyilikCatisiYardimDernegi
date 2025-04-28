using AutoMapper;
using iyilikCatisi.Models;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace iyilikCatisi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITarihceBs _tarihceBS;
        private readonly ITuzukBS _tuzukBS;
        private readonly IYonetimKuruluBS _yonetimKuruluBS;
        private readonly IMapper _mapper;
        private readonly IDenetimKuruluBS _denetimKuruluBS;
        private readonly IDernekBS _dernekBS;

        public HomeController(ILogger<HomeController> logger, ITarihceBs tarihceBS, ITuzukBS tuzukBS, IYonetimKuruluBS yonetimKuruluBS, IMapper mapper, IDenetimKuruluBS denetimKuruluBS, IDernekBS dernekBS)
        {
            _logger = logger;
            _tarihceBS = tarihceBS;
            _tuzukBS = tuzukBS;
            _yonetimKuruluBS = yonetimKuruluBS;
            _mapper = mapper;
            _denetimKuruluBS= denetimKuruluBS;
            _dernekBS = dernekBS;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Tarihcemiz()
        {
            
            Tarihce tarihce = _tarihceBS.GetAll().FirstOrDefault();

			return View(tarihce);
        }

        public IActionResult Tuzuk()
        {
            Tuzuk tuzuk = _tuzukBS.GetAll().FirstOrDefault();
            return View(tuzuk);
		}
		public IActionResult YonetimKurulu() 
        {
			List<YonetimKurulu> yonetimKurulu = _yonetimKuruluBS.GetAll();
			List<YonetimKuruluIndexViewModel> model = _mapper.Map<List<YonetimKuruluIndexViewModel>>(yonetimKurulu);
			return View(model);


		}

		public IActionResult DenetimKurulu()
		{
			List<DenetimKurulu> denetimKurulu = _denetimKuruluBS.GetAll();
			List<DenetimKuruluIndexViewModel> model = _mapper.Map<List<DenetimKuruluIndexViewModel>>(denetimKurulu);
			return View(model);


		}

        public IActionResult DernekSayfasi(int id)
        {
			DernekSayfaEklemeViewModel sayfa = _mapper.Map<DernekSayfaEklemeViewModel>(_dernekBS.GetById(id));
           
			return View(sayfa);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

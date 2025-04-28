using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Controllers
{
	public class GaleriController : Controller
	{
		private readonly IFotograflarBS _fotograflarBS;
		private readonly IVideolarBS _videolarBS;
		private readonly IMapper _mapper;

		public GaleriController(IFotograflarBS fotograflarBS, IVideolarBS videolarBS, IMapper mapper)
		{
			_fotograflarBS = fotograflarBS;
			_videolarBS = videolarBS;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Fotograflar()
		{
			List<Fotograflar> foto = _fotograflarBS.GetAll();
			List<FotograflarIndexViewModel> model = _mapper.Map<List<FotograflarIndexViewModel>>(foto);
			return View(model);
		}

		public IActionResult Videolar()
		{
			List<Videolar> video = _videolarBS.GetAll();
			List<VideolarIndexViewModel> model = _mapper.Map<List<VideolarIndexViewModel>>(video);
			return View(model);
		}
	}
}

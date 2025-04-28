using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Controllers
{
	public class EtkinlikController : Controller
	{
		private readonly IEtkinlikBS _etkinlikBS;
		private readonly IMapper _mapper;


		public EtkinlikController(IEtkinlikBS etkinlikBS, IMapper mapper)
		{
			_etkinlikBS = etkinlikBS;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			List<Etkinlik> etkinlikler = _etkinlikBS.GetAll(includelist: ["EtkinlikFotograflaris"]);
			List<EtkinlikIndexViewModel> model = _mapper.Map<List<EtkinlikIndexViewModel>>(etkinlikler);
			return View(model);
		}

		public IActionResult Detay(int id)
		{
			Etkinlik etkinlik = _etkinlikBS.GetById(id,includelist: ["EtkinlikFotograflaris"]);
			EtkinlikIndexViewModel model = _mapper.Map<EtkinlikIndexViewModel>(etkinlik);
			return View(model);
		}

	}
}

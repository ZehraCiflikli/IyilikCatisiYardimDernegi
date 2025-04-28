using AutoMapper;
using Infrastructure.Enum;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using IyilikCatisi.WebCoreUI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.ViewComponents
{
	public class dernekMenuViewComponent:ViewComponent
	{
		IDernekBS _dernekBs;
		ISessionManager _session;
		IMapper _mapper;
		public dernekMenuViewComponent(IDernekBS dernekBs, ISessionManager session, IMapper mapper)
		{
			_dernekBs = dernekBs;
			_session = session;
			_mapper = mapper;
		}
		public IViewComponentResult Invoke()
		{
			List<DernekSayfaEklemeViewModel> data = _mapper.Map<List<DernekSayfaEklemeViewModel>>(_dernekBs.GetAll(filter: x => x.Aktif == true, orderby: x => x.SiraNo, sorted: Sorted.ASC, Tracking: false));
			
			return View(data);
		}
	}

}

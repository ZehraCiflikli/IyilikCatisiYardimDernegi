using System.Text.Json.Serialization;
using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	public class BagisController : Controller
	{
		private readonly IBagislarBS _bagisBS;
		private readonly IMapper _mapper;
		private readonly IBagisTuruBS _bagisTuruBS;

		public BagisController(IBagislarBS bagisBS, IMapper mapper, IBagisTuruBS bagisTuruBS)
		{
			_bagisBS = bagisBS;
			_mapper = mapper;
			_bagisTuruBS = bagisTuruBS;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult BagisBasvuru()
		{

			List<SelectListItem> bagis = _bagisTuruBS.GetAll().Select(x => new SelectListItem { Text = x.BagisTuruAdi + " " + x.VarsayilanTutar, Value = x.Id.ToString() }).ToList();

			BagisBasvuruIndexViewModel model = new BagisBasvuruIndexViewModel();

			model.BagisTuruListe = bagis;

			//return View(new { BagisTuruListe = bagis });

			return View(model);

		}

		[HttpPost]
		public JsonResult BagisBasvuruListele()
		{
			List<Bagislar> bagis = _bagisBS.GetAll(x=>x.Aktif==false,includelist: ["BagisTuru"]);


			return Json(new { data = bagis });


		}

		public IActionResult AktifPasif(int id, bool aktif)
		{
			Bagislar bagis = _bagisBS.Get(x => x.Id == id);
			bagis.Aktif = aktif;
			_bagisBS.Update(bagis);

			//  Thread.Sleep(2000);
			return Json(new { result = true, mesaj = "Ödeme Onaylandı" });

		}


		[HttpPost]
		public IActionResult BagisBasvuruEkle(IFormCollection data)
		{
			Bagislar b = new Bagislar();
			b.Adi = data["Adi"];
			b.Soyadi = data["Soyadi"];
			b.TcKimlikNo = Convert.ToInt32(data["TcKimlikNo"]);
			b.BagisTarihi = DateOnly.Parse(data["BagisTarihi"].ToString());
			b.Email = data["Email"];
			b.BagisTuruId = Convert.ToInt32(data["BagisTuruId"]);
			b.Sehir = data["Sehir"];
			b.TelNo = data["TelNo"];
			b.OdemeNo = Convert.ToInt32(data["OdemeNo"]);
			b.BagislaIlgiliMesaj = data["BagislaIlgiliMesaj"];
			b.OdemeSekli = Convert.ToByte(data["OdemeSekli"]);
			b.BagisMiktari = _bagisTuruBS.GetById((int)b.BagisTuruId).VarsayilanTutar.Value;

			b.Aktif = false;

			_bagisBS.Insert(b);

			List<Bagislar> bagis = _bagisBS.GetAll();

			return Json(new { result = true, mesaj = "Bağış Türü Başarıyla Eklendi", model = bagis });
		}

		[HttpPost]
		public IActionResult BagisBasvuruGetir(int id)
		{


			Bagislar b = _bagisBS.Get(x => x.Id == id, includelist: ["BagisTuru"]);
			
			//b.BagisTurus.FirstOrDefault().VarsayilanTutar
			return Json(new { result = true, model = b });

		}

		[HttpPost]
		public IActionResult BagisBasvuruGuncelle(IFormCollection data)
		{
			int Id = Convert.ToInt32(data["Id"]);
			BagisBasvuruIndexViewModel model = new BagisBasvuruIndexViewModel();
			Bagislar b = _bagisBS.Get(x => x.Id == model.Id, includelist: ["BagisTuru"]);

			b.Adi = data["Adi"];
			b.Soyadi = data["Soyadi"];
			b.TcKimlikNo = Convert.ToInt32(data["TcKimlikNo"]);
			b.BagisTarihi = DateOnly.Parse(data["BagisTarihi"].ToString());
			b.Email = data["Email"];
			b.BagisTuruId = Convert.ToInt32(data["BagisTuruId"]);
			b.Sehir = data["Sehir"];
			b.TelNo = data["TelNo"];
			b.OdemeNo = Convert.ToInt32(data["OdemeNo"]);
			b.BagisMiktari = Convert.ToDecimal(data["BagisMiktarı"]);
			//b.OdemeSekli = (data["OdemeSekli"]);
			b.BagislaIlgiliMesaj = data["BagislaIlgiliMesaj"];
			b.BagisMiktari = b.BagisTuru.VarsayilanTutar.Value;




			_bagisBS.Update(b);



			return Json(new { result = true, mesaj = "Bağış Başvurusu Başarıyla Güncellendi" });
		}


		[HttpPost]
		public IActionResult BagisBasvuruSil(int id)
		{
			Bagislar b = _bagisBS.Get(x => x.Id == id);

			_bagisBS.Delete(b);

			return Json(new { result = true });
		}

		[HttpGet]
		public IActionResult BagisOnay()
		{
			return View();
		
		}

		[HttpPost]
		public IActionResult OnayliBagisBasvuru()
		{
			List<Bagislar> bagis= _bagisBS.GetAll(x => x.Aktif == true, includelist: ["BagisTuru"]);

			return Json(new { data = bagis });

		}

	}
}

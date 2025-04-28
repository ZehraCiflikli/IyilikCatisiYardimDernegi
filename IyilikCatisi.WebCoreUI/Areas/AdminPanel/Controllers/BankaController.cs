using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class BankaController : Controller
    {

        private readonly IBankaBS _BankaBs;
        private readonly IMapper _mapper;

        public BankaController(IBankaBS BankaBs, IMapper mapper)
        {
            _BankaBs = BankaBs;
            _mapper = mapper;

        }


        public IActionResult Index()
        {

            BankaIndexViewModel model = new BankaIndexViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult List()
        {
            List<Banka> bankalar = _BankaBs.GetAll();

            return Json(new { data = bankalar });
        }


        [HttpPost]
        public IActionResult BankaEkle(BankaIndexViewModel b)
        {
            Banka bk = _mapper.Map<Banka>(b);
            bk.BankaAdi = b.BankaAdi;
            bk.HesapSahibi=b.HesapSahibi;
            bk.IbanTR=b.IbanTR;
            bk.IbanEURO=b.IbanEURO;
            bk.IbanUSD=b.IbanUSD;
            bk.Aktif = true;
            if (b.BankaFoto != null)
            {
                IFormFile file = b.BankaFoto;
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/banka/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        bk.BankaLogo = "/images/banka/" + newFileName;
                    }
                }

            }

            _BankaBs.Insert(bk);

            return Json(new { result = true, mesaj = "Banka Başarıyla Eklendi" });

        }





        public IActionResult AktifPasif(int id, bool aktif)
        {
            Banka bk = _BankaBs.Get(x => x.Id == id);
            bk.Aktif = aktif;
            _BankaBs.Update(bk);

            //  Thread.Sleep(2000);
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }



        [HttpPost]
        public IActionResult BankaGetir(int id)
        {


            Banka bk = _BankaBs.Get(x => x.Id == id);

            return Json(new { result = true, model = bk });

        }


        [HttpPost]
        public IActionResult Guncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Banka bk = _BankaBs.Get(x => x.Id == Id);


            bk.BankaAdi = data["BankaAdi"];
            bk.HesapSahibi = data["HesapSahibi"];
            bk.IbanTR = data["IbanTR"];
            bk.IbanUSD = data["IbanUSD"];
            bk.IbanEURO = data["IbanEURO"];

            if (data.Files.Count != 0)
            {
                IFormFile file = data.Files[0];
                if (file != null)
                {
                    if (!file.ContentType.Contains("image/"))
                    {
                        return Json(new { result = false, mesaj = "Lütfen Resim Seçiniz" });
                    }
                    if (file.Length > 10485760) // 10MB dan büyük ise   Byte cinsinden 
                    {
                        return Json(new { result = false, mesaj = "10MB dan büyük olamaz" });
                    }
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = DateTime.Now.Ticks.ToString() + extension;

                    string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/banka/" + newFileName;
                    using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        bk.BankaLogo = "/images/banka/" + newFileName;
                    }
                }

            }

            _BankaBs.Update(bk);

            Banka ybk= _BankaBs.Get(x=>x.Id==bk.Id);
            BankaIndexViewModel model = _mapper.Map<BankaIndexViewModel>(ybk);



            return Json(new { result = true, mesaj = "Banka Başarıyla Güncellendi", model=model });
        }




        [HttpPost]
        public IActionResult BankaSil(int id)
        {
            Banka bk = _BankaBs.Get(x => x.Id == id);

            _BankaBs.Delete(bk);

            return Json(new { result = true });


        }
    }
}

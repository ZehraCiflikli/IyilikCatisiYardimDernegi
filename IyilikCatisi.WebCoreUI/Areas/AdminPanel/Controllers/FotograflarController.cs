using AutoMapper;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Model.Entity;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using Microsoft.AspNetCore.Mvc;

namespace IyilikCatisi.WebCoreUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FotograflarController : Controller
    {
        private readonly IFotograflarBS _fotograflarBS;
        private readonly IMapper _mapper;
        public FotograflarController(IFotograflarBS fotograflarBS, IMapper mapper)
        {
            _fotograflarBS = fotograflarBS;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            FotograflarIndexViewModel model = new FotograflarIndexViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult FotograflarListele()
        {
            List<Fotograflar> Fotograflar = _fotograflarBS.GetAll();
            List<FotograflarIndexViewModel> model = _mapper.Map<List<FotograflarIndexViewModel>>(Fotograflar);

            return Json(new { data = model });
        }

        public IActionResult AktifPasif(int id, bool aktif)
        {
            Fotograflar fotograflar = _fotograflarBS.Get(x => x.Id == id);
            fotograflar.Aktif = aktif;
            _fotograflarBS.Update(fotograflar);

           
            return Json(new { result = true, mesaj = "Aktiflik Başarıyla Güncellendi" });

        }

        [HttpPost]
        public IActionResult FotograflarEkle(IFormCollection data)
        {

            


            if (data.Files.Count != 0)
            {
                for (int i = 0; i < data.Files.Count; i++)
                {
                    Fotograflar f = new Fotograflar();
                    f.Aciklama = data["Aciklama"];

                    IFormFile file = data.Files[i];
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

                        string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/fotograflar/" + newFileName;
                        using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                        {
                            file.CopyTo(fs);
                            f.Resim = "/images/fotograflar/" + newFileName;
                            _fotograflarBS.Insert(f);
                        }
                    }
                }

            }
            

            return Json(new { result = true });

        }



        [HttpPost]
        public IActionResult FotograflarGetir(int id)
        {


            Fotograflar f = _fotograflarBS.Get(x => x.Id == id);

            return Json(new { result = true, model = f });

        }



        [HttpPost]
        public IActionResult FotograflarGuncelle(IFormCollection data)
        {
            int Id = Convert.ToInt32(data["Id"]);
            Fotograflar f = _fotograflarBS.Get(x => x.Id == Id);

            f.Aciklama = data["Aciklama"];


            if (data.Files.Count != 0)
            {
                for (int i = 0; i < data.Files.Count; i++)
                {
                    IFormFile file = data.Files[i];
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

                        string uploadpath = Directory.GetCurrentDirectory() + "/wwwroot/images/fotograflar/" + newFileName;
                        using (FileStream fs = new FileStream(uploadpath, FileMode.Create))
                        {
                            file.CopyTo(fs);
                            f.Resim = "/images/fotograflar/" + newFileName;
                        }
                    }
                }

            }


            _fotograflarBS.Update(f);



            return Json(new { result = true, mesaj = "Fotograflar Başarıyla Güncellendi" });
        }


        [HttpPost]
        public IActionResult FotograflarSil(int id)
        {
            Fotograflar f = _fotograflarBS.Get(x => x.Id == id);

            _fotograflarBS.Delete(f);

            return Json(new { result = true });
        }
    }
}

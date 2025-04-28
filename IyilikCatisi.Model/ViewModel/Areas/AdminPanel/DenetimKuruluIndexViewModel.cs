using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class DenetimKuruluIndexViewModel
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }

        public string Unvan { get; set; }

        public string Eposta { get; set; }

        public DateOnly? GoreveBaslangicTarihi { get; set; }

        public string Meslek { get; set; }

        public string İkamet { get; set; }
        public string Resim { get; set; }
        public IFormFile FUResim { get; set; }

    }
}

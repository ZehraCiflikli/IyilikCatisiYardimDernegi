using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class EtkinlikIndexViewModel
    {
        public int Id { get; set; }
        public string? Baslik { get; set; }

        public string? Aciklama { get; set; }

        public DateOnly? Tarih { get; set; }

        public TimeOnly? Saat { get; set; }

        public string? Konum { get; set; }

        public int? Telefon { get; set; }

        public bool? Aktif {  get; set; }
        public string KapakFoto { get; set; }

        public List<IFormFile> FotografListesi { get; set; }

        public List<IFormFile> GFotografListesi { get; set; }
    }
}

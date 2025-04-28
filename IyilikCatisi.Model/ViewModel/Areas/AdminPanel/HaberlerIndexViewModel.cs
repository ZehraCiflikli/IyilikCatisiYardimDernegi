using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class HaberlerIndexViewModel
    {
        public int? Id { get; set; }
        public string Baslik { get; set; } = null!;

        public string? Yazar { get; set; }

        public string Icerik { get; set; } = null!;

        public string? Etiketler { get; set; }

        public DateOnly? YayinTarihi { get; set; }

        public int? GoruntulenmeSayisi { get; set; }
        
        public bool? Aktif { get; set; }
    }
}


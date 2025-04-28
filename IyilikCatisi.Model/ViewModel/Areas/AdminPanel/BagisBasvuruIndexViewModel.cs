using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class BagisBasvuruIndexViewModel
    {
        public int Id {  get; set; }
        public string? Adi { get; set; }

        public string? Soyadi { get; set; }

        public int? TcKimlikNo { get; set; }

        public string Email { get; set; } = null!;

        public decimal BagisMiktari { get; set; }

        public int? BagisTuruId { get; set; }
        public string Sehir { get; set; }

        public string TelNo { get; set; }

        public int OdemeNo { get; set; }

        public byte OdemeSekli { get; set; }

        public DateOnly BagisTarihi { get; set; }

        public string? BagislaIlgiliMesaj { get; set; } = null!;

        public bool? Aktif {  get; set; }

        public List<SelectListItem> BagisTuruListe { get; set; }

    }
}

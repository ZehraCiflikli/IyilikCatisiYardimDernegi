using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IyilikCatisi.Model.Entity;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class BagisTuruIndexViewModel
    {
        public int Id { get; set; }
        public string? BagisTuruAdi { get; set; }

        public decimal? VarsayilanTutar { get; set; }

        public List<BagisTuru> BagisTuruListe { get; set; }
    }
}

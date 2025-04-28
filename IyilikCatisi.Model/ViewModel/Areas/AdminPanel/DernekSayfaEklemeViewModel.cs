using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class DernekSayfaEklemeViewModel
    {
        public int Id {  get; set; }
        public int? SiraNo { get; set; }
        public string SayfaAdi { get; set; }
        public string Icerik { get; set; }
    }
}

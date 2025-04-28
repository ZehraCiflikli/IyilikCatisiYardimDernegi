using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Model.ViewModel.Front
{
    public class IletisimViewModel
    {
        public int Id { get; set; }
        public string? AdSoyad {get; set;}
        public string? Konu { get; set;}
        public string? Email { get; set;}
        public string? Icerik { get; set;}

    }
}

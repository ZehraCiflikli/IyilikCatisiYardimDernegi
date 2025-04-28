using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IyilikCatisi.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class KullaniciIndexViewModel
    {
        public int Id { get; set; }
        public string Adi { get; set; } = null!;

        public string Soyadi { get; set; } = null!;

        public int TcKimlikNo { get; set; }

        public string Email { get; set; } = null!;

        public string CepTel { get; set; } = null!;

        public string Sifre { get; set; } = null!;
        public string Resim { get; set; }


        public DateTime DogumTarihi { get; set; }

        public string? Adres { get; set; }
        public bool? Aktif { get; set; }

        public DateTime? UyelikTarihi { get; set; }

        public List<string> Roller { get; set; }

        public List<SelectListItem> Rols { get; set; }

        public List<string> RolIds { get; set; }
        public List<string> GRolIds { get; set; }


        public IFormFile KullaniciFoto { get; set; }



    }
}

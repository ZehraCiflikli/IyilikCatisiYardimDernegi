using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IyilikCatisi.Model.ViewModel.Front
{
	public class KullaniciProfilVm
	{
        public int Id { get; set; }

        public string Adi { get; set; } = null!;

        public string Soyadi { get; set; } = null!;

        public int TcKimlikNo { get; set; }

        public string Email { get; set; } = null!;

        public bool? EpostaOnay { get; set; }

        public string CepTel { get; set; } = null!;

        public bool? CepTelOnay { get; set; }

        public string Sifre { get; set; } = null!;

        public string YeniSifre { get; set; }

        public string YeniSifreTekrar { get; set; }

        public DateTime DogumTarihi { get; set; }

        public string? Adres { get; set; }

        public DateTime? UyelikTarihi { get; set; }

        public Guid? UniqueId { get; set; }
        public string Resim { get; set; }

        public IFormFile? ResimDosyasi { get; set; }

    }
}

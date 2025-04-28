using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Model.ViewModel.Front
{
	public class KullaniciSignupVm
	{
		public string Adi { get; set; }

		public string Soyadi { get; set; }

		public DateTime DogumTarihi { get; set; }

		public string CepTel { get; set; } = null!;

		public string Email { get; set; }

		public string Sifre { get; set; }

		public string SifreTekrar { get; set; }


	}
}

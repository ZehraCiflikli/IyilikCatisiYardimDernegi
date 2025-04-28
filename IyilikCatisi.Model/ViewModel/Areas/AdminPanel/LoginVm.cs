using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class LoginVm
    {
        public string Sifre { get; set; }

        public string Email { get; set; }

        public bool BeniHatirla { get; set; }

        public string GuvenlikKodu { get; set; }
    }
}

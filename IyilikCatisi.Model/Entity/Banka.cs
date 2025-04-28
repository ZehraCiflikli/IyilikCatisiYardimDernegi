using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity
{
    public partial class Banka:BaseEntity
    {
        public string BankaAdi { get; set; }
        public string? BankaLogo {  get; set; }
        public string? HesapSahibi { get; set; }
        public string? IbanTR { get; set; }
        public string? IbanUSD { get; set; }
        public string? IbanEURO { get; set; }

        public string? SwiftKodu { get; set; }
        public string? Aciklama { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyilikCatisi.Model.Statics
{
    public static class SessionKeys
    {
        public static string AktifKullanici { get; } = "AKTIFKULLANICI";

        public static string AktifYonetici { get; } = "AKTIFYONETICI";

        public static string GuvenlikKodu { get; set; } = "GUVENLIKKODU";
    }
}

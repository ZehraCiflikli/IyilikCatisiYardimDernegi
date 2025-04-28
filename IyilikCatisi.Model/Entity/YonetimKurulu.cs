using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class YonetimKurulu:BaseEntity
{
    public string AdSoyadi { get; set; }

    public string Unvan { get; set; }

    public string Eposta { get; set; }

    public DateOnly? GoreveBaslangicTarihi { get; set; }

    public string Meslek { get; set; }

    public string İkamet { get; set; }

    public string Resim { get; set; }

    public string Aciklama { get; set; }
}

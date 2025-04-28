using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Makaleler:BaseEntity
{
    public string? Baslik { get; set; }

    public int? KullaniciId { get; set; }

    public string Icerik { get; set; } = null!;

    public string? AnahtarKelime { get; set; }

    public DateOnly? YayinTarihi { get; set; }

    public int? GoruntulenmeSayisi { get; set; }
   
}

using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Haberler : BaseEntity
{
    public string Baslik { get; set; } = null!;

    public string? Yazar { get; set; }

    public string Icerik { get; set; } = null!;

    public string? Etiketler { get; set; }

    public DateOnly? YayinTarihi { get; set; }

    public int? GoruntulenmeSayisi { get; set; }

}
using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class UyelikAidatlari:BaseEntity
{
    public decimal? AidatTutari { get; set; }

    public int? AidatOdemePeriyodu { get; set; }

    public DateOnly? OdemeSonTarihi { get; set; }

    public DateOnly? KayitTarihi { get; set; }

    public int? KullaniciId { get; set; }

    public virtual Kullanicilar? Kullanici { get; set; }
}

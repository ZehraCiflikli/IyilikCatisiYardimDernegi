using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Etkinlik:BaseEntity
{
  
    public string? Baslik { get; set; }

    public string? Aciklama { get; set; }

    public DateOnly? Tarih { get; set; }

    public TimeOnly? Saat { get; set; }

    public string? Konum { get; set; }

    public int? Telefon {  get; set; }

    public virtual ICollection<EtkinlikFotograflari>? EtkinlikFotograflaris { get; set; }

    public virtual Kullanicilar Olusturan { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Bildirimler:BaseEntity
{
  

    public DateTime BildirimTarihi { get; set; }

    public string BildirimBasligi { get; set; } = null!;

    public string BildirimIcerigi { get; set; } = null!;

    public bool Durum { get; set; }

    public virtual ICollection<BildirimKullanici> BildirimKullanicis { get; set; } = new List<BildirimKullanici>();

    public virtual Kullanicilar OlusturanKullanici { get; set; } = null!;
}

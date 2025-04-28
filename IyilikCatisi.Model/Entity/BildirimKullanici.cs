using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class BildirimKullanici:BaseEntity
{
    public int KullaniciId { get; set; }

    public int BildirimId { get; set; }

    public virtual Bildirimler Bildirim { get; set; } = null!;

    public virtual Kullanicilar Kullanici { get; set; } = null!;
}

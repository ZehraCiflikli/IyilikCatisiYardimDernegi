using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Mesajlar:BaseEntity
{
    public int KullaniciId { get; set; }

    public string MesajIcerigi { get; set; } = null!;

    public int MesajTipId { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual MesajTip MesajTip { get; set; } = null!;
}

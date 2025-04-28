using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Yorumlar:BaseEntity
{
    public int KullaniciId { get; set; }

    public string YorumMetni { get; set; } = null!;

    public int YorumTipId { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual YorumTip YorumTip { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class UyelikDurumu:BaseEntity
{
    public string? UyelikDurumu1 { get; set; }
    public virtual ICollection<Kullanicilar> Kullanicilars { get; set; } = new List<Kullanicilar>();
}

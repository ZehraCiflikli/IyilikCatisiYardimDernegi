using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class KullaniciRol:BaseEntity
{
    public int RolId { get; set; }

    public int KullaniciId { get; set; }

    public virtual Kullanicilar Kullanici { get; set; } = null!;

    public virtual Roller Rol { get; set; } = null!;
}

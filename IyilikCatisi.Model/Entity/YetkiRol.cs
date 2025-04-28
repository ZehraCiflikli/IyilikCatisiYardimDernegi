using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class YetkiRol:BaseEntity
{
    public int RolId { get; set; }

    public int YetkiId { get; set; }

    public virtual Roller Rol { get; set; } = null!;

    public virtual Yetkiler Yetki { get; set; } = null!;
}

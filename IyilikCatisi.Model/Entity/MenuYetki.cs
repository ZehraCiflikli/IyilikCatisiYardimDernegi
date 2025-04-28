using System;
using System.Collections.Generic;
using Infrastructure.Model;
using IyilikCatisi.Model.Entity;

namespace IyilikCatisi.Model.Entity;

public partial class MenuYetki:BaseEntity
{
    public int? MenuId { get; set; }

    public int? RolId { get; set; }

    public bool? InsertYetki { get; set; }

    public bool? UpdateYetki { get; set; }

    public bool? DeleteYetki { get; set; }

    public bool? SelectYetki { get; set; }

    public virtual Menu? Menu { get; set; } = null!;

    public virtual Roller? Rol { get; set; } =null!;

}

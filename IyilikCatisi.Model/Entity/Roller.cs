using System;
using System.Collections.Generic;
using Infrastructure.Model;
using IyilikCatisi.Model.Entity;

namespace IyilikCatisi.Model.Entity;

public partial class Roller:BaseEntity
{   
    public string RolAdi { get; set; } = null!;
    public virtual ICollection<KullaniciRol> KullaniciRols { get; set; } = new List<KullaniciRol>();

    public virtual ICollection<YetkiRol> YetkiRols { get; set; } = new List<YetkiRol>();

    public virtual ICollection<MenuYetki> MenuYetkis { get; set; } = new List<MenuYetki>();
}

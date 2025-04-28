using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Yetkiler:BaseEntity
{
    public string YetkiAdi { get; set; } = null!;
    public virtual ICollection<YetkiRol> YetkiRols { get; set; } = new List<YetkiRol>();
}

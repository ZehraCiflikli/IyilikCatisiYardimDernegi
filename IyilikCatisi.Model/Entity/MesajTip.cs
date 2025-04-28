using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class MesajTip:BaseEntity
{
    public string MesajTipi { get; set; } = null!;
    public virtual ICollection<Mesajlar> Mesajlars { get; set; } = new List<Mesajlar>();
}

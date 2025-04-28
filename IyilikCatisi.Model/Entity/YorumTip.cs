using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class YorumTip:BaseEntity
{
    public string YorumTipi { get; set; } = null!;

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}

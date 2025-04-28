using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class EtkinlikFotograflari:BaseEntity
{
    public int EtkinlikId { get; set; }

    public string? Fotograf { get; set; }

    public string? FotografAciklama { get; set; }

    public virtual Etkinlik Etkinlik { get; set; } = null!;
}

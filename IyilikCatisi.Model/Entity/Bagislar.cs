using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Bagislar:BaseEntity
{
    
    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public int? TcKimlikNo { get; set; }

    public string Email { get; set; } = null!;

    public decimal BagisMiktari { get; set; }

    public int? BagisTuruId { get; set; }
    public string Sehir {  get; set; }

    public string TelNo { get; set; }

    public int OdemeNo { get; set; }

    public byte OdemeSekli { get; set; }

    public DateOnly BagisTarihi { get; set; }

    public string? BagislaIlgiliMesaj { get; set; } = null!;

    public int? KullaniciId { get; set; }

    public virtual Kullanicilar? Kullanici { get; set; }

    //public virtual ICollection<BagisTuru> BagisTurus { get; set; } = new List<BagisTuru>();

    public virtual BagisTuru? BagisTuru { get; set; } = null!;
}

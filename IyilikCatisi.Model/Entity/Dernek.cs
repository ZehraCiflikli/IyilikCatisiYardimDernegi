using System;
using System.Collections.Generic;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity;

public partial class Dernek:BaseEntity
{
    public int? SiraNo { get; set; }
    public string SayfaAdi { get; set; }
    public string Icerik {  get; set; }

}

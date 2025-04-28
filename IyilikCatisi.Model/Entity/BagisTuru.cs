using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity
{
    public partial class BagisTuru:BaseEntity
    {
        public string? BagisTuruAdi {  get; set; }

        public decimal? VarsayilanTutar {  get; set; }

        //public virtual Bagislar? Bagislar { get; set; } = null!;

        public virtual ICollection<Bagislar> Bagislars { get; set; } = new List<Bagislar>();
    }
}

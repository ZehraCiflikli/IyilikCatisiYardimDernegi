using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity
{
    public partial class Fotograflar:BaseEntity
    {
        public string Resim {  get; set; }
        public string Aciklama { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Model;

namespace IyilikCatisi.Model.Entity
{
    public partial class Videolar:BaseEntity
    {
        public string? VideoAdi{get; set;}
        public string? Video { get; set;}
        public string? Kaynak { get; set;}
        public string? VideoUrl { get; set;}
        public int? SiraNo { get; set;}
    }
}

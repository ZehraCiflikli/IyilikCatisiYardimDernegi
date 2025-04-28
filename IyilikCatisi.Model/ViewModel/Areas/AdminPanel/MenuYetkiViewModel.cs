using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IyilikCatisi.Model.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IyilikCatisi.Model.ViewModel.Areas.AdminPanel
{
    public class MenuYetkiViewModel
    {
        public List<SelectListItem> MenuList { get; set; }
        public List<SelectListItem> RolList { get; set; }

        public int? MenuId { get; set; }

        public int? RolId { get; set; }

        public bool InsertYetki { get; set; }

        public bool UpdateYetki { get; set; }

        public bool DeleteYetki { get; set; }

        public bool SelectYetki { get; set; }

        public List<MenuYetki> MenuYetkiler { get; set; }

    }
}

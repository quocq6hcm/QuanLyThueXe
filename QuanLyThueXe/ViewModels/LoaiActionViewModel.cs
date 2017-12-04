using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class LoaiActionViewModel
    {
        public int MaAction { get; set; }
        public String TenAction { get; set; }
        public String MoTa { get; set; }
        public String UrlAction { get; set; }
        public String MaController { get; set; }
        public List<LoaiControllerViewModel> LoaiControllers { get; set; }

    }
}
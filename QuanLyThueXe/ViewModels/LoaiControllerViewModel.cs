using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class LoaiControllerViewModel
    {
        public String MaController { get; set; }
        public String TenController { get; set; }
        public String Icon { get; set; }
        public int STT { get; set; }

        public List<LoaiActionViewModel> LoaiActions { get; set; }
    }
}
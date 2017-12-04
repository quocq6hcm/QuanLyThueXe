using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class PhanQuyenViewModel
    {
        public String MaQuyen { get; set; }
        public int MaAction { get; set; }
        public List<QuyenViewModel> Quyens { get; set; }
        public List<LoaiActionViewModel> LoaiActions { get; set; }

    }
}
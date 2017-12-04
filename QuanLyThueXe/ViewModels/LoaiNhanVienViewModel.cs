using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class LoaiNhanVienViewModel
    {
        public String MaLoaiNV { get; set; }
        public String TenLoaiNV { get; set; }
        public String MaLuong { get; set; }
        public Boolean? Dang { get; set; }
        public int STT { get; set; }
        public List<LuongViewModel> Luongs { get; set; }
    }
}
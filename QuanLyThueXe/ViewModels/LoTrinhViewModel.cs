using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class LoTrinhViewModel
    {
        public String MaLoTrinh { get; set; }
        public String TenLoTrinh { get; set; }
        public Boolean? Dang { get; set; }
        public String MaKH { get; set; }
        public int STT { get; set; }
        public KhachHangViewModel KhachHangs { get; set; }
    }
}
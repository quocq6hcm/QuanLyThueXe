using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class LoaiXeViewModel
    {
        public String MaLoaiXe { get; set; }
        public String TenLoaiXe { get; set; }
        public Boolean? Dang { get; set; }
        public int STT { get; set; }
    }
}
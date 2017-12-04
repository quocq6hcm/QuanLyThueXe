using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class ChiPhiPhatSinhViewModel
    {
        public String MaChiPhi { get; set; }
        public String TenChiPhi { get; set; }
        public Decimal? PhiPhatSinh { get; set; }
        public String MoTa { get; set; }
        public int? SoLuong { get; set; } 
        public int STT { get; set; }

    }
}
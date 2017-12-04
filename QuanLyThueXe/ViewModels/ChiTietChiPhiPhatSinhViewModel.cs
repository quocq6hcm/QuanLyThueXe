using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class ChiTietChiPhiPhatSinhViewModel
    {
        public int STT { get; set; }
        public String SoHopDong { get; set; }
        public String MaChiPhi { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        
        public ChiPhiPhatSinhViewModel ChiPhiPhatSinhs { get; set; }
    }
}
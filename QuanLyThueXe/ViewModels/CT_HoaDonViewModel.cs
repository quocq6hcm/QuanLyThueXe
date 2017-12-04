using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class CT_HoaDonViewModel
    {
        public String SoHopDong { get; set; }
        public String SoHoaDon { get; set; }
        public int TongSoXeThue { get; set; }
        public Decimal SoTienTraTruoc { get; set; }
        public Decimal SoTienConLai { get; set; }
        public Decimal TongThanhToan { get; set; }
        public int STT { get; set; }

        public List<HopDongViewModel> HopDongs { get; set; }
        public List<HoaDonViewModel> HoaDons { get; set; }

    }
}
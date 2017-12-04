using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class TuyenDuongMoiViewModel
    {
        public String TenLoTrinhMoi { get; set; }
        public String strLoaiXeMoi { get; set; }
        public String StrSoLuongXeMoi { get; set; }
        public String strGiaXeMoi { get; set; }
        public DateTime? NgayDiMoi { get; set; }
        public DateTime? NgayVeMoi { get; set; }
        public DateTime? GioDonMoi { get; set; }
        public String GioUocTinh { get; set; }
        public int? SoLuongNguoiMoi { get; set; }
        public String DiaDiemMoi { get; set; }
        public String GhiChuMoi { get; set; }
        public decimal? GiamGiaMoi { get; set; }
        public decimal? GiaNiemYetMoi { get; set; }
        public String strMaChiPhiMoi { get; set; }
        public String strSoLuongCPMoi { get; set; }
        public String ThoiGianMoi { get; set; }
        public decimal? TongTienMoi { get; set; }
    }
}
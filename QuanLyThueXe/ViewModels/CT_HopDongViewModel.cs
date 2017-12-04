using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class CT_HopDongViewModel
    {
        public int SoCTHopDong { get; set; }
        public String SoHopDong { get; set; }
        public String MaXe { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime NgayVe { get; set; }
        public int? QuaDem { get; set; }
        public int? SoLuongNguoi { get; set; }
        public DateTime? GioDon { get; set; }
        public int? SoLuong { get; set; }
        public String DiaDiemDon { get; set; }
        public Decimal? Gia { get; set; }
        public String MaChiPhi { get; set; }
        public String MaTaiXe { get; set; }
        public String BienSoXe { get; set; }
        public String MaCongTy { get; set; }
        public String GhiChu { get; set; }
        public String MaLoaiXe { get; set; }
        public String HuongDanVien { get; set; }
        public String PhuXe { get; set; }
        public String TaiXeNgoai { get; set; }
        public int STT { get; set; }

        public LoaiXeViewModel LoaiXes { get; set; }
        public HopDongViewModel HopDongs { get; set; }
        public XeViewModel Xes { get; set; }
        public NhanVienViewModel PhuXes { get; set; }
        public NhanVienViewModel TaiXes { get; set; }
        public CongTiesViewModel CongTies { get; set; }
        public LoTrinhViewModel LoTrinhs { get; set; }
        public KhachHangViewModel KhachHangs { get; set; }
    }
}
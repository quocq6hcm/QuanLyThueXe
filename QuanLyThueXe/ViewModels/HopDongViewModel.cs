using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class HopDongViewModel
    {
        public String SoHopDong { get; set; }
        public String MaLoTrinh { get; set; }
        public DateTime? NgayLapHD { get; set; }
        public String MaKH { get; set; }
        public String MaNV { get; set; }
        public String MaHinhThucThue { get; set; }
        public String MaHinhThucThanhToan { get; set; }
        public String MaTrangThai { get; set; }
        public Decimal? GiamGia { get; set; }
        public Decimal? SoTienTraTruoc { get; set; }
        public Decimal? SoTienConLai { get; set; }
        public String   GhiChu { get; set; }
        public int STT { get; set; }
        public String MaChiPhi { get; set; }
        public String SoLuongCP { get; set; }

        public List<CT_HopDongViewModel> CT_HopDongs { get; set; }
        public LoTrinhViewModel LoTrinhs { get; set; }
        public KhachHangViewModel KhachHangs { get; set; }
        public NhanVienViewModel NhanViens { get; set; }
        public HinhThucThueViewModel HinhThucThues { get; set; }
        public HinhThucThanhToanViewModel HinhThucThanhToans { get; set; }
        public TrangThaiHopDongViewModel TrangThaiHopDongs { get; set; }
    }
}
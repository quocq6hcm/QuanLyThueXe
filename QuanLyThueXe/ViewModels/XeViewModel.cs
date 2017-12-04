using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class XeViewModel
    {
        public String MaXe { get; set; }
        public String BienSo { get; set; }
        public String MoTa { get; set; }
        public String MaLoaiXe { get; set; }
        public String HinhAnh { get; set; }
        public String MaCongTy { get; set; }
        public String MaThuongHieu { get; set; }
        public DateTime? NgayDangKiem { get; set; }
        public String GhiChu { get; set; }
        public String Status { get; set; }
        public DateTime? NgayBaoTriXe { get; set; }
        public Decimal? SoKm { get; set; }
        public int? SoLan { get; set; }
        public DateTime? ThoiGianGanDay { get; set; }
        public Boolean? Dang { get; set; }
        public String MaNV { get; set; }
        public int STT { get; set; }
        public DateTime? BaoHiemTuNguyen { get; set; }
        public DateTime? BaoHiemBatBuoc { get; set; }
        public DateTime? DangKiem { get; set; }
        public DateTime? DangKi { get; set; }
        public String HopDong { get; set; }
        public String ChuXe { get; set; }
        public String DiaChi { get; set; }

        public LoaiXeViewModel LoaiXes { get; set; }
        public CongTiesViewModel CongTies { get; set; }
        public ThuongHieuViewModel ThuongHieus { get; set; }
        public NhanVienViewModel NhanViens { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class NhanVienViewModel
    {
        public String MaNV { get; set; }
        public String HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public String DiaChi { get; set; }
        public String CMND { get; set; }
        public String HinhAnh { get; set; }
        public Boolean? Dang { get; set; }
        public String MaLoaiNV { get; set; }
        public String SDT { get; set; }
        public Decimal? LuongThuong { get; set; }
        public String ThongTinKhac { get; set; }
        public String MaBang { get; set; }
        public String Status { get; set; }
        public String MaTinh { get; set; }
        public DateTime? NgayNghi { get; set; }
        public int? SoLan { get; set; }
        public DateTime? ThoiGianGanDay { get; set; }
        public Boolean? GioiTinh { get; set; }
        public String Email { get; set; }
        public String MaSoThue { get; set; }
        public int STT { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public String GPLX { get; set; }

        public LoaiNhanVienViewModel LoaiNhanViens{get; set;}
        public LoaiBangViewModel LoaiBangs { get; set; }
        public Tinh_TPViewModel Tinh_TPs { get; set; }
    }
}
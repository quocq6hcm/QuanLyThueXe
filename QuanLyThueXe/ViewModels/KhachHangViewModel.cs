using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class KhachHangViewModel
    {
        public String MaKH { get; set; }
        public String MaLoaiKH { get; set; }
        public String TenKH { get; set; }
        public String TenCongTy { get; set; }
        public String DiaChiKH { get; set; }
        public String CMND { get; set; }
        public String SDT { get; set; }
        public String SDTCongTy { get; set; }
        public String GhiChu { get; set; }
        public String DiaChiCongTy { get; set; }
        public String NguoiLienHe { get; set; }
        public Decimal? GiamGia { get; set; }
        public Boolean? GioiTinh { get; set; }
        public String Email { get; set; }
        public String MaSoThue { get; set; }
        public Boolean Dang { get; set; }
        public int STT { get; set; }
        public LoaiKhachHangViewModel LoaiKhachHangs { get; set; }
    }
}
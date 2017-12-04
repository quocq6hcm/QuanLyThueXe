using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class PhieuChiViewModel
    {
        public String SoPhieuChi { get; set; }
        public String MaNV { get; set; }
        public String LyDo { get; set; }
        public DateTime? NgayChi { get; set; }
        public Decimal? SoTienChi { get; set; }
        public int STT { get; set; }
        public String NguoiNhan { get; set; }
        public String DiaChi { get; set; }
        public NhanVienViewModel NhanViens { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class PhieuThuViewModel
    {
        public String SoPhieuThu { get; set; }
        public String MaNV { get; set; }
        public String LyDo { get; set; }
        public DateTime? NgayThu { get; set; }
        public Decimal? SoTienThu { get; set; }
        public String NguoiNop { get; set; }
        public String DiaChi { get; set; }
        public int STT { get; set; }
        public NhanVienViewModel NhanViens { get; set; }
    }
}
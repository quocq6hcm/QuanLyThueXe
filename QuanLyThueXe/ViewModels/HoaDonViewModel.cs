using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class HoaDonViewModel
    {
        public String SoHoaDon { get; set; }
        public String MaKH { get; set; }
        public String MaNV { get; set; }
        public DateTime NgayLap { get; set; }
        public int STT { get; set; }

        public List<KhachHangViewModel> KhachHangs { get; set; }
        public List<NhanVienViewModel> NhanViens { get; set; }
    }
}
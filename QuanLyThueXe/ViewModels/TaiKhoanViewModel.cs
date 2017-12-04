using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class TaiKhoanViewModel
    {
        public String TaiKhoanNV { get; set; }
        public String MatKhau { get; set; }
        public String MaNV { get; set; }
        public String MaQuyen { get; set; }
        public int STT { get; set; }
        public Boolean? Online { get; set; }
        public NhanVienViewModel NhanViens { get; set; }
        public QuyenViewModel Quyens { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class BangGiaViewModel
    {
        public String MaBangGia { get; set; }
        public String MaLoaiXe { get; set; }
        public String MaKH { get; set; }
        public String MaLoTrinh { get; set; }
        public Decimal? Gia { get; set; }
        public String ThoiGian { get; set; }    
        public Decimal? SoKM { get; set; }
        public int STT { get; set; }
        public Boolean? Dang { get; set; }

        public LoaiXeViewModel LoaiXes { get; set; }
        public KhachHangViewModel KhachHangs { get; set; }
        public LoTrinhViewModel LoTrinhs { get; set; }
        public List<LoaiXeViewModel> ListLoaiXes { get; set; }
    }
}
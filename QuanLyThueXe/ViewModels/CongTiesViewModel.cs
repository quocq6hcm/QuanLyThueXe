using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThueXe.ViewModels
{
    public class CongTiesViewModel
    {
        public String MaCongTy { get; set; }
        public String TenCongTy { get; set; }
        public String Email { get; set; }
        public String DiaChi { get; set; }
        public String SDT { get; set; }
        public String Fax { get; set; }
        public String NguoiLienHe { get; set; }
        public String GhiChu { get; set; }
        public Boolean? Dang { get; set; }
        public int? VAT { get; set; }   
        public String MaSoThue { get; set; }
        public int STT { get; set; }
    }
}
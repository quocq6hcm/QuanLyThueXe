//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyThueXe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuChi
    {
        public string SoPhieuChi { get; set; }
        public string MaNV { get; set; }
        public string LyDo { get; set; }
        public Nullable<System.DateTime> NgayChi { get; set; }
        public Nullable<decimal> SoTienChi { get; set; }
        public int STT { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}

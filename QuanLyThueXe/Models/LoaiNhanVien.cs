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
    
    public partial class LoaiNhanVien
    {
        public LoaiNhanVien()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }
    
        public string MaLoaiNV { get; set; }
        public Nullable<bool> Dang { get; set; }
        public string TenLoaiNV { get; set; }
        public string MaLuong { get; set; }
        public int STT { get; set; }
    
        public virtual Luong Luong { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
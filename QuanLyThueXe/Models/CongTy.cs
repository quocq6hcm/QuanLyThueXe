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
    
    public partial class CongTy
    {
        public CongTy()
        {
            this.CT_HopDong = new HashSet<CT_HopDong>();
            this.Xes = new HashSet<Xe>();
        }
    
        public string MaCongTy { get; set; }
        public string TenCongTy { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Fax { get; set; }
        public string NguoiLienHe { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> Dang { get; set; }
        public Nullable<int> VAT { get; set; }
        public string MaSoThue { get; set; }
        public int STT { get; set; }
    
        public virtual ICollection<CT_HopDong> CT_HopDong { get; set; }
        public virtual ICollection<Xe> Xes { get; set; }
    }
}

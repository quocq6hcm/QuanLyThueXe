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
    
    public partial class HinhThucThanhToan
    {
        public HinhThucThanhToan()
        {
            this.HopDongs = new HashSet<HopDong>();
        }
    
        public string MaHinhThucTT { get; set; }
        public string TenHinhThucTT { get; set; }
        public int STT { get; set; }
    
        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}
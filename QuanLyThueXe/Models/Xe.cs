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
    
    public partial class Xe
    {
        public Xe()
        {
            this.CT_HopDong = new HashSet<CT_HopDong>();
        }
    
        public string MaXe { get; set; }
        public string BienSo { get; set; }
        public string Mota { get; set; }
        public string MaLoaiXe { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<bool> Dang { get; set; }
        public string MaCongTy { get; set; }
        public string MaThuongHieu { get; set; }
        public Nullable<System.DateTime> NgayDangKiem { get; set; }
        public string GhiChu { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> NgayBaoTriXe { get; set; }
        public Nullable<decimal> SoKm { get; set; }
        public Nullable<int> SoLan { get; set; }
        public Nullable<System.DateTime> ThoiGianGanDay { get; set; }
        public string MaNV { get; set; }
        public int STT { get; set; }
        public Nullable<System.DateTime> BaoHiemTuNguyen { get; set; }
        public Nullable<System.DateTime> BaoHiemBatBuoc { get; set; }
        public Nullable<System.DateTime> NgayDangKi { get; set; }
        public Nullable<System.DateTime> DangKiem { get; set; }
        public string HopDong { get; set; }
        public string ChuXe { get; set; }
        public string DiaChi { get; set; }
    
        public virtual CongTy CongTy { get; set; }
        public virtual ICollection<CT_HopDong> CT_HopDong { get; set; }
        public virtual LoaiXe LoaiXe { get; set; }
        public virtual ThuongHieuXe ThuongHieuXe { get; set; }
    }
}

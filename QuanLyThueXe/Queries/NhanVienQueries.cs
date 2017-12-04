using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;


namespace QuanLyThueXe.Queries
{
    public class NhanVienQueries
    {
        #region tự tăng mã nhân viên
        public static String TuTangMaNV()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaNV = "";
                var Manv = entity.NhanViens.OrderByDescending(n => n.STT).FirstOrDefault();
                if (Manv == null)
                {
                    MaNV = "NV1";
                }
                else
                {
                    Manv.MaNV = Manv.MaNV.Substring(2, Manv.MaNV.Length - 2);
                    int iSo = int.Parse(Manv.MaNV);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaNV = "NV" + sSo;
                }
                return MaNV;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region danh sách nhân viên
        public static List<NhanVienViewModel> LayDanhSachNhanVien()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from nv in entity.NhanViens
                                where nv.Dang == true && nv.MaNV != "admin"
                                select new NhanVienViewModel()
                                {

                                    MaNV = nv.MaNV,
                                    HoTen = nv.HoTen,
                                    NgayNghi = nv.NgayNghi,
                                    NgaySinh = nv.NgaySinh,
                                    CMND = nv.CMND,
                                    DiaChi = nv.DiaChi,
                                    Email = nv.Email,
                                    GioiTinh = nv.GioiTinh,
                                    HinhAnh = nv.HinhAnh,
                                    MaBang = nv.LoaiBang.TenBang,
                                    SDT = nv.SDT,
                                    Dang = nv.Dang,
                                    SoLan = nv.SoLan,
                                    Status = nv.Status,
                                    ThoiGianGanDay = nv.ThoiGianGanDay,
                                    ThongTinKhac = nv.ThongTinKhac,
                                    LuongThuong = nv.LuongThuong,
                                    MaTinh = nv.Tinh_TP.TenTinh,
                                    MaLoaiNV = nv.LoaiNhanVien.TenLoaiNV,
                                    STT = nv.STT,
                                    LoaiNhanViens = (
                                                from Loainv in entity.LoaiNhanViens
                                                where Loainv.MaLoaiNV == nv.MaLoaiNV
                                                select new LoaiNhanVienViewModel()
                                                {
                                                    MaLoaiNV = Loainv.MaLoaiNV,
                                                    TenLoaiNV = Loainv.TenLoaiNV
                                                }).FirstOrDefault()
                                }).OrderBy(n => n.MaNV).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region chi tiết nhân viên
        public static NhanVienViewModel LayThongTinChiTiet(string MaNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from nv in entity.NhanViens
                                where nv.MaNV == MaNV
                                select new NhanVienViewModel()
                                {
                                    MaNV = nv.MaNV,
                                    HoTen = nv.HoTen,
                                    NgayNghi = nv.NgayNghi,
                                    NgaySinh = nv.NgaySinh,
                                    CMND = nv.CMND,
                                    DiaChi = nv.DiaChi,
                                    Email = nv.Email,
                                    GioiTinh = nv.GioiTinh,
                                    HinhAnh = nv.HinhAnh,
                                    MaBang = nv.MaBang,
                                    MaLoaiNV = nv.MaLoaiNV,
                                    SDT = nv.SDT,
                                    Dang = nv.Dang,
                                    SoLan = nv.SoLan,
                                    Status = nv.Status,
                                    ThoiGianGanDay = nv.ThoiGianGanDay,
                                    ThongTinKhac = nv.ThongTinKhac,
                                    LuongThuong = nv.LuongThuong,
                                    NgayHetHan = nv.NgayHethan,
                                    GPLX = nv.GPLX,
                                    MaTinh = nv.Tinh_TP.TenTinh,
                                    LoaiNhanViens = (
                                                        from Loainv in entity.LoaiNhanViens
                                                        where Loainv.MaLoaiNV == nv.MaLoaiNV
                                                        select new LoaiNhanVienViewModel()
                                                        {
                                                            MaLoaiNV = Loainv.MaLoaiNV,
                                                            TenLoaiNV = Loainv.TenLoaiNV
                                                        }).FirstOrDefault(),
                                    LoaiBangs = (
                                                    from LB in entity.LoaiBangs
                                                    where LB.MaBang == nv.MaBang
                                                    select new LoaiBangViewModel()
                                                    {
                                                        TenBang = LB.TenBang
                                                    }).FirstOrDefault(),
                                    Tinh_TPs = (
                                                    from tp in entity.Tinh_TPs
                                                    where tp.MaTinh == nv.MaTinh
                                                    select new Tinh_TPViewModel()
                                                    {
                                                        TenTinh = tp.TenTinh
                                                    }).FirstOrDefault()
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region chỉnh sửa nhân viên
        public static Boolean ChinhsuaNV(NhanVienViewModel nv)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var NV = entity.NhanViens.SingleOrDefault(n => n.MaNV == nv.MaNV);
                NV.HoTen = nv.HoTen;
                NV.NgaySinh = nv.NgaySinh;
                NV.DiaChi = nv.DiaChi;
                NV.CMND = nv.CMND;
                NV.HinhAnh = nv.HinhAnh;
                NV.Dang = true;
                NV.MaLoaiNV = nv.MaLoaiNV;
                NV.SDT = nv.SDT;
                NV.LuongThuong = nv.LuongThuong;
                NV.ThongTinKhac = nv.ThongTinKhac;
                NV.MaBang = nv.MaBang;
                NV.Status = nv.Status;
                NV.MaTinh = nv.MaTinh;
                NV.NgayNghi = nv.NgayNghi;
                NV.SoLan = nv.SoLan;
                NV.ThoiGianGanDay = nv.ThoiGianGanDay;
                NV.GioiTinh = nv.GioiTinh;
                NV.Email = nv.Email;
                NV.NgayHethan = nv.NgayHetHan;
                NV.GPLX = nv.GPLX;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        #endregion

        #region thêm nhân viên
        public static Boolean ThemNhanVien(NhanVienViewModel NV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var nv = new NhanVien();
                nv.MaNV = TuTangMaNV();
                nv.MaLoaiNV = NV.MaLoaiNV;
                nv.HoTen = NV.HoTen;
                nv.NgaySinh = NV.NgaySinh;
                nv.DiaChi = NV.DiaChi;
                nv.CMND = NV.CMND;
                nv.HinhAnh = NV.HinhAnh;
                nv.Dang = true;
                nv.SDT = NV.SDT;
                nv.LuongThuong = NV.LuongThuong;
                nv.ThongTinKhac = NV.ThongTinKhac;
                nv.MaBang = NV.MaBang;
                nv.Status = "0";
                nv.MaTinh = NV.MaTinh;
                nv.NgayNghi = NV.NgayNghi;
                nv.SoLan = 0;
                nv.ThoiGianGanDay = DateTime.Now;
                nv.GioiTinh = NV.GioiTinh;
                nv.Email = NV.Email;
                nv.NgayHethan = NV.NgayHetHan;
                nv.GPLX = NV.GPLX;
                entity.NhanViens.Add(nv);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        #endregion

        #region lấy danh sách nhân viên theo mã loại nhân viên
        /// <summary>
        /// LayDSNhanVienTheoMaLoai
        /// </summary>
        /// <param name="MaLoaiNV"></param>
        /// <returns></returns>
        public static List<NhanVienViewModel> LayDSNhanVienTheoMaLoaiNV(String MaLoaiNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from nv in entity.NhanViens
                                where nv.MaLoaiNV == MaLoaiNV
                                select new NhanVienViewModel()
                                {

                                    MaNV = nv.MaNV,
                                    HoTen = nv.HoTen,
                                    NgayNghi = nv.NgayNghi,
                                    NgaySinh = nv.NgaySinh,
                                    CMND = nv.CMND,
                                    DiaChi = nv.DiaChi,
                                    Email = nv.Email,
                                    GioiTinh = nv.GioiTinh,
                                    HinhAnh = nv.HinhAnh,
                                    MaBang = nv.LoaiBang.TenBang,
                                    SDT = nv.SDT,
                                    Dang = nv.Dang,
                                    SoLan = nv.SoLan,
                                    Status = nv.Status,
                                    ThoiGianGanDay = nv.ThoiGianGanDay,
                                    ThongTinKhac = nv.ThongTinKhac,
                                    LuongThuong = nv.LuongThuong,
                                    MaTinh = nv.Tinh_TP.TenTinh,
                                    MaLoaiNV = nv.LoaiNhanVien.TenLoaiNV,
                                    LoaiNhanViens = (
                                                from Loainv in entity.LoaiNhanViens
                                                where Loainv.MaLoaiNV == nv.MaLoaiNV
                                                select new LoaiNhanVienViewModel()
                                                {
                                                    MaLoaiNV = Loainv.MaLoaiNV,
                                                    TenLoaiNV = Loainv.TenLoaiNV
                                                }).FirstOrDefault()
                                }).OrderBy(n => n.MaNV).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region xóa nhân viên
        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="MaNV"></param>
        /// <returns></returns>
        public static Boolean XoaNV(String MaNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var NV = entity.NhanViens.SingleOrDefault(n => n.MaNV == MaNV);
                NV.Dang = false;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        #endregion

        #region lấy danh sách nhân viên đang chờ theo mã loại nhân viên
        /// <summary>
        /// LayDSNVDangChoTheoMaLoaiNV
        /// </summary>
        /// <param name="MaLoaiNV"></param>
        /// <returns></returns>
        public static List<NhanVienViewModel> LayDSNVDangChoTheoMaLoaiNV(String MaLoaiNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from nv in entity.NhanViens
                                where nv.MaLoaiNV == MaLoaiNV
                                select new NhanVienViewModel()
                                {

                                    MaNV = nv.MaNV,
                                    HoTen = nv.HoTen,
                                    NgayNghi = nv.NgayNghi,
                                    NgaySinh = nv.NgaySinh,
                                    CMND = nv.CMND,
                                    DiaChi = nv.DiaChi,
                                    Email = nv.Email,
                                    GioiTinh = nv.GioiTinh,
                                    HinhAnh = nv.HinhAnh,
                                    MaBang = nv.LoaiBang.TenBang,
                                    SDT = nv.SDT,
                                    Dang = nv.Dang,
                                    SoLan = nv.SoLan,
                                    Status = nv.Status,
                                    ThoiGianGanDay = nv.ThoiGianGanDay,
                                    ThongTinKhac = nv.ThongTinKhac,
                                    LuongThuong = nv.LuongThuong,
                                    MaTinh = nv.Tinh_TP.TenTinh,
                                    MaLoaiNV = nv.LoaiNhanVien.TenLoaiNV,
                                    LoaiNhanViens = (
                                                from Loainv in entity.LoaiNhanViens
                                                where Loainv.MaLoaiNV == nv.MaLoaiNV
                                                select new LoaiNhanVienViewModel()
                                                {
                                                    MaLoaiNV = Loainv.MaLoaiNV,
                                                    TenLoaiNV = Loainv.TenLoaiNV
                                                }).FirstOrDefault()
                                }).OrderBy(n => n.MaNV).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region testing
        public static int TestingSiteMethod()
        {
            var entity = new QuanLyThueXeEntities();
            var rs = entity.TaiKhoans.ToList().Count;
            return rs;
        }
        #endregion
    }
}
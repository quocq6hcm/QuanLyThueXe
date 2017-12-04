using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class TaiKhoanQueries
    {
        #region Đăng nhập
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="TaiKhoanNV"></param>
        /// <param name="MatKhau"></param>
        /// <returns></returns>
        public static TaiKhoanViewModel Login(String TaiKhoanNV, String MatKhau)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from t in entity.TaiKhoans
                                where t.TaiKhoanNV == TaiKhoanNV && t.MatKhau == MatKhau
                                select new TaiKhoanViewModel()
                                {
                                    TaiKhoanNV = t.TaiKhoanNV,
                                    MatKhau = t.MatKhau,
                                    MaNV = t.MaNV,
                                    MaQuyen = t.MaQuyen,
                                    Online = t.Online,
                                }).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region lấy thông tin tài khoản
        public static TaiKhoanViewModel LayThongTinTaiKhoan(String taiKhoan)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from tk in entity.TaiKhoans
                                where tk.TaiKhoanNV == taiKhoan
                                select new TaiKhoanViewModel()
                                {
                                    MaNV = tk.MaNV,
                                    MaQuyen = tk.MaQuyen,
                                    MatKhau = tk.MatKhau,
                                    STT = tk.STT,
                                    TaiKhoanNV = tk.TaiKhoanNV,
                                    NhanViens = (
                                    from nv in entity.NhanViens
                                    where nv.MaNV == tk.MaNV
                                    select new NhanVienViewModel()
                                    {
                                        HoTen = nv.HoTen
                                    }).FirstOrDefault(),
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

        #region Đổi mật khẩu
        public static Boolean DoiMatKhau(TaiKhoanViewModel taiKhoan)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.TaiKhoans.SingleOrDefault(n => n.TaiKhoanNV == taiKhoan.TaiKhoanNV);
                result.MatKhau = taiKhoan.MatKhau;
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

        #region Tạo tài khoản
        public static Boolean TaoTaiKhoan(TaiKhoanViewModel taiKhoan)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var check = entity.TaiKhoans.SingleOrDefault(n => n.TaiKhoanNV == taiKhoan.TaiKhoanNV);
                if (check != null)
                {
                    return false;
                }
                TaiKhoan tk = new TaiKhoan();
                tk.MaNV = taiKhoan.MaNV;
                tk.MaQuyen = taiKhoan.MaQuyen;
                tk.TaiKhoanNV = taiKhoan.TaiKhoanNV;
                tk.MatKhau = taiKhoan.MatKhau;
                tk.Online = false;
                entity.TaiKhoans.Add(tk);
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

        #region Danh sách tài khoản
        public static List<TaiKhoanViewModel> LayDanhSachTaiKhoan()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from tk in entity.TaiKhoans
                                where tk.TaiKhoanNV != "admin"
                                select new TaiKhoanViewModel()
                                {
                                    MaNV = tk.MaNV,
                                    MaQuyen = tk.MaQuyen,
                                    MatKhau = tk.MatKhau,
                                    STT = tk.STT,
                                    TaiKhoanNV = tk.TaiKhoanNV,
                                    Online = tk.Online,
                                    NhanViens = (
                                        from nv in entity.NhanViens
                                        where nv.MaNV == tk.MaNV
                                        select new NhanVienViewModel()
                                        {
                                            HoTen = nv.HoTen
                                        }).FirstOrDefault(),
                                    Quyens = (
                                                from q in entity.Quyens
                                                where q.MaQuyen == tk.MaQuyen
                                                select new QuyenViewModel()
                                                {
                                                    TenQuyen = q.TenQuyen,
                                                }).FirstOrDefault(),
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Reset mật khẩu
        public static Boolean ResetPass(String taiKhoan)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                TaiKhoan tk = entity.TaiKhoans.SingleOrDefault(n => n.TaiKhoanNV == taiKhoan);
                tk.MatKhau = "123456";
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

        #region Thông tin chi tiết tài khoản
        /// <summary>
        /// Chi tiet tai khoan
        /// </summary>
        /// <param name=""></param>
        /// <returns>TaiKhoanViewModel</returns>
        //chi tiết tài khoản
        public static TaiKhoanViewModel LayChiTietTaiKhoan(string Taikhoan)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from tk in entity.TaiKhoans
                                where tk.TaiKhoanNV == Taikhoan
                                select new TaiKhoanViewModel()
                                {
                                    MaNV = tk.MaNV,
                                    MaQuyen = tk.MaQuyen,
                                    MatKhau = tk.MatKhau,
                                    STT = tk.STT,
                                    TaiKhoanNV = tk.TaiKhoanNV,
                                    NhanViens = (
                                        from nv in entity.NhanViens
                                        where nv.MaNV == tk.MaNV
                                        select new NhanVienViewModel()
                                        {
                                            HoTen = nv.HoTen
                                        }).FirstOrDefault(),
                                    Quyens = (
                                                from q in entity.Quyens
                                                where q.MaQuyen == tk.MaQuyen
                                                select new QuyenViewModel()
                                                {
                                                    TenQuyen = q.TenQuyen,
                                                }).FirstOrDefault(),
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

        #region chỉnh sửa tài khoản
        /// <summary>
        /// chỉnh sửa tài khoản
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        public static Boolean ChinhsuaTaiKhoan(TaiKhoanViewModel tk)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var TK = entity.TaiKhoans.SingleOrDefault(n => n.TaiKhoanNV == tk.TaiKhoanNV);
                TK.MaNV = TK.MaNV;
                TK.MaQuyen = tk.MaQuyen;
                TK.MatKhau = TK.MatKhau;
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

        #region Cập nhật online
        public static Boolean CapNhatOnline(String TaiKhoanNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                TaiKhoan tk = entity.TaiKhoans.SingleOrDefault(n => n.TaiKhoanNV == TaiKhoanNV);
                tk.Online = true;
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

        #region Cập nhật offline
        public static Boolean CapNhatOffline(String TaiKhoanNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                TaiKhoan tk = entity.TaiKhoans.SingleOrDefault(n => n.TaiKhoanNV == TaiKhoanNV);
                tk.Online = false;
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

        #region lấy danh sách nhân viên onloff
        public static List<TaiKhoanViewModel> LayDanhSachNhanVienOnl()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from tk in entity.TaiKhoans
                                where tk.MaNV != "admin"
                                select new TaiKhoanViewModel()
                                {
                                    Online = tk.Online,
                                    NhanViens = (
                                                    from nv in entity.NhanViens
                                                    where nv.MaNV == tk.MaNV
                                                    select new NhanVienViewModel()
                                                    {
                                                        HoTen = nv.HoTen,
                                                        HinhAnh = nv.HinhAnh,
                                                        LoaiNhanViens = (
                                                                            from lnv in entity.LoaiNhanViens
                                                                            where lnv.MaLoaiNV == nv.MaLoaiNV
                                                                            select new LoaiNhanVienViewModel()
                                                                            {
                                                                                TenLoaiNV = lnv.TenLoaiNV,
                                                                            }).FirstOrDefault(),
                                                    }).FirstOrDefault(),
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion
    }
}
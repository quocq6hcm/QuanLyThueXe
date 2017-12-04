using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
using System.Diagnostics;

namespace QuanLyThueXe.Queries
{
    public class KhachHangQueries
    {
        #region Tự động tăng mã khách hàng
        /// <summary>
        /// Ma tu dong tang cua khach hang
        /// </summary>
        /// <returns>MaKH</returns>
        public static String TuTangMaKH()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaKH = "";
                var MaKh = entity.KhachHangs.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaKh == null)
                {
                    MaKH = "KH1";
                }
                else
                {
                    MaKh.MaKH = MaKh.MaKH.Substring(2, MaKh.MaKH.Length-2);
                    int iSo = int.Parse(MaKh.MaKH);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaKH = "KH" + sSo;
                }
                return MaKH;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Danh sách khách hàng
        /// <summary>
        /// Danh sach khach hang
        /// </summary>
        public static List<KhachHangViewModel> DanhSachKhachHang()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from kh in entity.KhachHangs
                                where kh.Dang == true
                                select new KhachHangViewModel()
                                {
                                    MaKH = kh.MaKH,
                                    TenKH = kh.TenKH,
                                    DiaChiKH = kh.DiaChiKH,
                                    SDT = kh.SDT,
                                    CMND = kh.CMND,
                                    Email = kh.Email,
                                    GioiTinh = kh.GioiTinh,
                                    NguoiLienHe = kh.NguoiLienHe,
                                    TenCongTy = kh.TenCongTy,
                                    SDTCongTy = kh.SDTCongTy,
                                    DiaChiCongTy = kh.DiaChiCongTy,
                                    GiamGia = kh.GiamGia,
                                    GhiChu = kh.GhiChu,
                                    MaLoaiKH = kh.MaLoaiKH,
                                    MaSoThue = kh.MaSoThue,
                                    STT = kh.STT,
                                    LoaiKhachHangs = (from l in entity.LoaiKhachHangs
                                                      where kh.MaLoaiKH == l.MaLoaiKH
                                                      select new LoaiKhachHangViewModel()
                                                      {
                                                          MaLoaiKH = l.MaLoaiKH,
                                                          TenLoaiKH = l.TenLoaiKH
                                                      }).FirstOrDefault()
                                }).OrderBy(n => n.MaKH).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Thêm khách hàng
        /// <summary>
        /// Thêm khach hang
        /// </summary>
        /// <param KhachHangViewModel="KH"></param>
        /// <returns>Boolean</returns>
        public static Boolean ThemKhachHang(KhachHangViewModel KH)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var KhHang = new KhachHang();
                KhHang.MaKH = TuTangMaKH();
                KhHang.TenKH = KH.TenKH;
                KhHang.GioiTinh = KH.GioiTinh;
                KhHang.Email = KH.Email;
                KhHang.CMND = KH.CMND;
                KhHang.DiaChiKH = KH.DiaChiKH;
                KhHang.SDT = KH.SDT;
                KhHang.MaLoaiKH = "LKH1";
                KhHang.TenCongTy = KH.TenCongTy;
                KhHang.SDTCongTy = KH.SDTCongTy;
                KhHang.GhiChu = KH.GhiChu;
                KhHang.DiaChiCongTy = KH.DiaChiCongTy;
                KhHang.NguoiLienHe = KH.NguoiLienHe;
                KhHang.GiamGia = 0;
                KhHang.MaSoThue = KH.MaSoThue;
                KhHang.Dang = true;
                entity.KhachHangs.Add(KhHang);
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

        #region Thêm khách hàng
        /// <summary>
        /// Thêm khach hang
        /// </summary>
        /// <param KhachHangViewModel="KH"></param>
        /// <returns>Boolean</returns>
        public static Boolean ThemKhachHangThanThiet(KhachHangViewModel KH)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                
                var KhHang = new KhachHang();
                KhHang.MaKH = TuTangMaKH();
                if (String.IsNullOrEmpty(KH.TenCongTy))
                {
                    KhHang.TenKH = KH.NguoiLienHe;
                }
                else
                {
                    KhHang.TenKH = KH.TenCongTy;
                }
                KhHang.GioiTinh = KH.GioiTinh;
                KhHang.Email = KH.Email;
                KhHang.CMND = KH.CMND;
                KhHang.DiaChiKH = KH.DiaChiKH;
                KhHang.SDT = KH.SDT;
                KhHang.MaLoaiKH = "LKH2";
                KhHang.TenCongTy = KH.TenCongTy;
                KhHang.SDTCongTy = KH.SDTCongTy;
                KhHang.GhiChu = KH.GhiChu;
                KhHang.DiaChiCongTy = KH.DiaChiCongTy;
                KhHang.NguoiLienHe = KH.NguoiLienHe;
                KhHang.GiamGia = 0;
                KhHang.MaSoThue = KH.MaSoThue;
                KhHang.Dang = true;
                entity.KhachHangs.Add(KhHang);
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

        #region Thông tin chi tiết của 1 khách hàng
        /// <summary>
        /// Chi tiet khach hang
        /// </summary>
        /// <param name="MaKH"></param>
        /// <returns>KhachHangViewModel</returns>
        public static KhachHangViewModel LayThongTinChiTiet(String MaKH)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (from kh in entity.KhachHangs
                              where kh.MaKH == MaKH
                              select new KhachHangViewModel()
                              {
                                  MaKH = kh.MaKH,
                                  TenKH = kh.TenKH,
                                  DiaChiKH = kh.DiaChiKH,
                                  SDT = kh.SDT,
                                  CMND = kh.CMND,
                                  Email = kh.Email,
                                  GioiTinh = kh.GioiTinh,
                                  NguoiLienHe = kh.NguoiLienHe,
                                  TenCongTy = kh.TenCongTy,
                                  SDTCongTy = kh.SDTCongTy,
                                  DiaChiCongTy = kh.DiaChiCongTy,
                                  GiamGia = kh.GiamGia,
                                  GhiChu = kh.GhiChu,
                                  MaLoaiKH = kh.MaLoaiKH,
                                  MaSoThue = kh.MaSoThue,
                                  LoaiKhachHangs = (from l in entity.LoaiKhachHangs
                                                    where kh.MaLoaiKH == l.MaLoaiKH
                                                    select new LoaiKhachHangViewModel()
                                                    {
                                                        MaLoaiKH = l.MaLoaiKH,
                                                        TenLoaiKH = l.TenLoaiKH
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

        #region cập nhật lại thông tin của 1 khách hàng lẻ
        public static Boolean CapNhatThongTinKhachHang(KhachHangViewModel khachHang)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var kh = entity.KhachHangs.SingleOrDefault(n=>n.MaKH == khachHang.MaKH);
                kh.TenKH = khachHang.TenKH;
                kh.GioiTinh = khachHang.GioiTinh;
                kh.CMND = khachHang.CMND;
                kh.SDT = khachHang.SDT;
                kh.Email = khachHang.Email;
                kh.DiaChiKH = khachHang.DiaChiKH;
                kh.GiamGia = khachHang.GiamGia;
                kh.TenCongTy = khachHang.TenCongTy;
                kh.NguoiLienHe = khachHang.NguoiLienHe;
                kh.SDTCongTy = khachHang.SDTCongTy;
                kh.DiaChiCongTy = khachHang.DiaChiCongTy;
                kh.MaLoaiKH = khachHang.MaLoaiKH;
                kh.GhiChu = khachHang.GhiChu;
                kh.MaSoThue = khachHang.MaSoThue;
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

        #region cập nhật lại thông tin của 1 khách hàng thân thiết
        public static Boolean CapNhatThongTinKhachHangThanThiet(KhachHangViewModel khachHang)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var kh = entity.KhachHangs.SingleOrDefault(n => n.MaKH == khachHang.MaKH);
                if (String.IsNullOrEmpty(khachHang.TenCongTy))
                {
                    kh.TenKH = khachHang.NguoiLienHe;
                }
                else
                {
                    kh.TenKH = khachHang.TenCongTy;
                }
                kh.GioiTinh = khachHang.GioiTinh;
                kh.CMND = khachHang.CMND;
                kh.SDT = khachHang.SDT;
                kh.Email = khachHang.Email;
                kh.DiaChiKH = khachHang.DiaChiKH;
                kh.GiamGia = khachHang.GiamGia;
                kh.TenCongTy = khachHang.TenCongTy;
                kh.NguoiLienHe = khachHang.NguoiLienHe;
                kh.SDTCongTy = khachHang.SDTCongTy;
                kh.DiaChiCongTy = khachHang.DiaChiCongTy;
                kh.MaLoaiKH = khachHang.MaLoaiKH;
                kh.GhiChu = khachHang.GhiChu;
                kh.MaSoThue = khachHang.MaSoThue;
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

        #region Lấy danh sách khách hàng thân thiết
        /// <summary>
        /// Lấy danh sách khách hàng thân thiết
        /// </summary>
        /// <returns></returns>
        public static List<KhachHangViewModel> LayDanhSachKhachHangThanThiet()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from kh in entity.KhachHangs
                                where kh.MaLoaiKH == "LKH2" && kh.Dang == true
                                select new KhachHangViewModel()
                                {
                                    MaKH = kh.MaKH,
                                    TenKH = kh.TenKH,
                                    DiaChiKH = kh.DiaChiKH,
                                    SDT = kh.SDT,
                                    CMND = kh.CMND,
                                    Email = kh.Email,
                                    GioiTinh = kh.GioiTinh,
                                    NguoiLienHe = kh.NguoiLienHe,
                                    TenCongTy = kh.TenCongTy,
                                    SDTCongTy = kh.SDTCongTy,
                                    DiaChiCongTy = kh.DiaChiCongTy,
                                    GiamGia = kh.GiamGia,
                                    GhiChu = kh.GhiChu,
                                    MaLoaiKH = kh.MaLoaiKH,
                                    MaSoThue = kh.MaSoThue,
                                    STT = kh.STT,
                                    LoaiKhachHangs = (from l in entity.LoaiKhachHangs
                                                      where kh.MaLoaiKH == l.MaLoaiKH
                                                      select new LoaiKhachHangViewModel()
                                                      {
                                                          MaLoaiKH = l.MaLoaiKH,
                                                          TenLoaiKH = l.TenLoaiKH
                                                      }).FirstOrDefault()
                                }).ToList();
                return result;
            }
            catch (Exception ex )
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Lấy danh sách khách hàng lẻ
        /// <summary>
        /// Lấy danh sách khách hàng lẻ
        /// </summary>
        /// <returns></returns>
        public static List<KhachHangViewModel> LayDanhSachKhachHangLe()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from kh in entity.KhachHangs
                                where kh.MaLoaiKH == "LKH1" && kh.Dang == true
                                select new KhachHangViewModel()
                                {
                                    MaKH = kh.MaKH,
                                    TenKH = kh.TenKH,
                                    DiaChiKH = kh.DiaChiKH,
                                    SDT = kh.SDT,
                                    CMND = kh.CMND,
                                    Email = kh.Email,
                                    GioiTinh = kh.GioiTinh,
                                    NguoiLienHe = kh.NguoiLienHe,
                                    TenCongTy = kh.TenCongTy,
                                    SDTCongTy = kh.SDTCongTy,
                                    DiaChiCongTy = kh.DiaChiCongTy,
                                    GiamGia = kh.GiamGia,
                                    GhiChu = kh.GhiChu,
                                    MaLoaiKH = kh.MaLoaiKH,
                                    MaSoThue = kh.MaSoThue,
                                    STT = kh.STT,
                                    LoaiKhachHangs = (from l in entity.LoaiKhachHangs
                                                      where kh.MaLoaiKH == l.MaLoaiKH
                                                      select new LoaiKhachHangViewModel()
                                                      {
                                                          MaLoaiKH = l.MaLoaiKH,
                                                          TenLoaiKH = l.TenLoaiKH
                                                      }).FirstOrDefault()
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

        /// Xóa khách hàng
        /// </summary>
        /// <param name="MaKH"></param>
        /// <returns></returns>
        #region xóa khách hàng
        public static Boolean XoaKH(String MaKH)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var KH = entity.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
                KH.Dang = false;
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
    }
}
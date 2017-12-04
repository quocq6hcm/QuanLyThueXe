using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
using System.Globalization;

namespace QuanLyThueXe.Queries
{
    public class CT_HopDongQueries
    {

        #region Danh sách chi tiết hợp đồng bằng tham số là SoHopDong
        /// <summary>
        /// Thông tin chi tiết hợp đồng
        /// </summary>
        /// <param name="SoHopDong"></param>
        /// <returns></returns>
        public static List<CT_HopDongViewModel> LayDanhSachChiTietHopDong(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cthd in entity.CT_HopDongs
                                where cthd.SoHopDong == SoHopDong
                                select new CT_HopDongViewModel()
                                {
                                    SoCTHopDong = cthd.SoCTHopDong,
                                    SoHopDong = cthd.SoHopDong,
                                    NgayDi = cthd.NgayDi,
                                    NgayVe = cthd.NgayVe,
                                    BienSoXe = cthd.BienSoXe,
                                    DiaDiemDon = cthd.DiaDiemDon,
                                    GhiChu = cthd.GhiChu,
                                    Gia = cthd.Gia,
                                    GioDon = cthd.GioDon,
                                    HuongDanVien = cthd.HuongDanVien,
                                    MaChiPhi = cthd.MaChiPhi,
                                    MaCongTy = cthd.MaCongTy,
                                    MaLoaiXe = cthd.MaLoaiXe,
                                    MaTaiXe = cthd.MaTaiXe,
                                    MaXe = cthd.MaXe,
                                    QuaDem = cthd.QuaDem,
                                    SoLuong = cthd.SoLuong,
                                    SoLuongNguoi = cthd.SoLuongNguoi,
                                    TaiXeNgoai = cthd.TaiXeNgoai,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == cthd.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                }).OrderBy(n => n.MaLoaiXe).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Groupby danh sách chi tiết hợp đồng
        public static List<Groupby_CT_HopDongViewModel> GroupbyCTHopDong(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                List<CT_HopDongViewModel> cthd = LayDanhSachChiTietHopDong(SoHopDong);
                var result = cthd
                    .GroupBy(l => l.MaLoaiXe)
                    .Select(cl => new Groupby_CT_HopDongViewModel
                    {
                        MaLoaiXe = cl.First().MaLoaiXe,
                        SoLuong = cl.Sum(c => c.SoLuong),
                        NgayDi = cl.First().NgayDi,
                        NgayVe = cl.First().NgayVe,
                        BienSoXe = cl.First().BienSoXe,
                        DiaDiemDon = cl.First().DiaDiemDon,
                        GhiChu = cl.First().GhiChu,
                        Gia = cl.First().Gia,
                        GioDon = cl.First().GioDon,
                        HuongDanVien = cl.First().HuongDanVien,
                        MaChiPhi = cl.First().MaChiPhi,
                        MaCongTy = cl.First().MaCongTy,
                        MaTaiXe = cl.First().MaTaiXe,
                        MaXe = cl.First().MaXe,
                        QuaDem = cl.First().QuaDem,
                        SoLuongNguoi = cl.First().SoLuongNguoi,
                        TaiXeNgoai = cl.First().TaiXeNgoai,
                        //LoaiXes = (
                        //                        from lx in entity.LoaiXes
                        //                        where lx.MaLoaiXe == cl.First().MaLoaiXe
                        //                        select new LoaiXeViewModel()
                        //                        {
                        //                            TenLoaiXe = lx.TenLoaiXe
                        //                        }).FirstOrDefault(),

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

        #region Thông tin chi tiết hợp đồng theo trạng thai
        /// <summary>
        /// Thông tin chi tiết hợp đồng theo trạng thai
        /// </summary>
        /// <param name="SoHopDong"></param>
        /// <returns></returns>
        public static List<CT_HopDongViewModel> LayDanhSachChiTietHopDongTheoTrangThai(String MaTrangThai)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cthd in entity.CT_HopDongs
                                join hd in entity.HopDongs on cthd.SoHopDong equals hd.SoHopDong
                                where hd.MaTrangThai == MaTrangThai
                                select new CT_HopDongViewModel()
                                {
                                    SoCTHopDong = cthd.SoCTHopDong,
                                    SoHopDong = cthd.SoHopDong,
                                    NgayDi = cthd.NgayDi,
                                    NgayVe = cthd.NgayVe,
                                    BienSoXe = cthd.BienSoXe,
                                    DiaDiemDon = cthd.DiaDiemDon,
                                    GhiChu = cthd.GhiChu,
                                    Gia = cthd.Gia,
                                    GioDon = cthd.GioDon,
                                    HuongDanVien = cthd.HuongDanVien,
                                    MaChiPhi = cthd.MaChiPhi,
                                    MaCongTy = cthd.MaCongTy,
                                    MaLoaiXe = cthd.MaLoaiXe,
                                    MaTaiXe = cthd.MaTaiXe,
                                    MaXe = cthd.MaXe,
                                    QuaDem = cthd.QuaDem,
                                    SoLuong = cthd.SoLuong,
                                    SoLuongNguoi = cthd.SoLuongNguoi,
                                    PhuXe = cthd.PhuXe,
                                    TaiXeNgoai = cthd.TaiXeNgoai,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == cthd.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    Xes = (
                                                from x in entity.Xes
                                                where x.MaXe == cthd.MaXe
                                                select new XeViewModel()
                                                {
                                                    BienSo = x.BienSo,
                                                    GhiChu = x.GhiChu
                                                }).FirstOrDefault(),
                                    TaiXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.MaTaiXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    PhuXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.PhuXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
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

        #region Lấy thông tin chi tiết của 1 chi tiết hợp đồng
        /// <summary>
        /// Lấy thông tin chi tiết của 1 chi tiết hợp đồng
        /// </summary>
        /// <param name="SoCTHopDong"></param>
        /// <returns></returns>
        // Begin
        public static CT_HopDongViewModel LayThongTinChiTietCTHD(int SoCTHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cthd in entity.CT_HopDongs
                                join hd in entity.HopDongs on cthd.SoHopDong equals hd.SoHopDong
                                where cthd.SoCTHopDong == SoCTHopDong
                                select new CT_HopDongViewModel()
                                {
                                    SoCTHopDong = cthd.SoCTHopDong,
                                    SoHopDong = cthd.SoHopDong,
                                    NgayDi = cthd.NgayDi,
                                    NgayVe = cthd.NgayVe,
                                    BienSoXe = cthd.BienSoXe,
                                    DiaDiemDon = cthd.DiaDiemDon,
                                    GhiChu = cthd.GhiChu,
                                    Gia = cthd.Gia,
                                    GioDon = cthd.GioDon,
                                    HuongDanVien = cthd.HuongDanVien,
                                    MaChiPhi = cthd.MaChiPhi,
                                    MaCongTy = cthd.MaCongTy,
                                    MaLoaiXe = cthd.MaLoaiXe,
                                    MaTaiXe = cthd.MaTaiXe,
                                    MaXe = cthd.MaXe,
                                    QuaDem = cthd.QuaDem,
                                    SoLuong = cthd.SoLuong,
                                    SoLuongNguoi = cthd.SoLuongNguoi,
                                    PhuXe = cthd.PhuXe,
                                    TaiXeNgoai = cthd.TaiXeNgoai,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == cthd.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    Xes = (
                                                from x in entity.Xes
                                                where x.MaXe == cthd.MaXe
                                                select new XeViewModel()
                                                {
                                                    BienSo = x.BienSo,
                                                    GhiChu = x.GhiChu
                                                }).FirstOrDefault(),
                                    TaiXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.MaTaiXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    PhuXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.PhuXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    CongTies = (
                                                from ct in entity.CongTies
                                                where ct.MaCongTy == cthd.MaCongTy
                                                select new CongTiesViewModel()
                                                {
                                                    MaCongTy = ct.MaCongTy,
                                                    TenCongTy = ct.TenCongTy
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
        // END
        #endregion

        #region Cập nhật điều phối xe
        /// <summary>
        /// Cập nhật điều phối xe
        /// </summary>
        /// <param name="CTHD"></param>
        /// <returns></returns>
        //Begin
        public static Boolean CapNhatDieuPhoiXe(CT_HopDongViewModel CTHD)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.CT_HopDongs.SingleOrDefault(n => n.SoCTHopDong == CTHD.SoCTHopDong);
                result.MaLoaiXe = CTHD.MaLoaiXe;
                result.MaXe = CTHD.MaXe;
                result.BienSoXe = CTHD.BienSoXe;
                result.MaCongTy = CTHD.MaCongTy;
                result.SoLuongNguoi = CTHD.SoLuongNguoi;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        //End
        #endregion

        #region Cập nhật điều phối tài xế
        /// <summary>
        /// Cập nhật điều phối tài xế
        /// </summary>
        /// <param name="CTHD"></param>
        /// <returns></returns>
        //Begin
        public static Boolean CapNhatDieuPhoiTaiXe(CT_HopDongViewModel CTHD)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.CT_HopDongs.SingleOrDefault(n => n.SoCTHopDong == CTHD.SoCTHopDong);
                result.TaiXeNgoai = CTHD.TaiXeNgoai;
                result.MaTaiXe = CTHD.MaTaiXe;
                result.PhuXe = CTHD.PhuXe;
                result.HuongDanVien = CTHD.HuongDanVien;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        //End
        #endregion

        #region Lấy danh sách chi tiết hợp đồng
        /// <summary>
        /// Lấy danh sách chi tiết hợp đồng
        /// </summary>
        /// <returns></returns>
        public static List<CT_HopDongViewModel> LayDanhSachCTDH()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cthd in entity.CT_HopDongs
                                join hd in entity.HopDongs on cthd.SoHopDong equals hd.SoHopDong
                                select new CT_HopDongViewModel()
                                {
                                    SoCTHopDong = cthd.SoCTHopDong,
                                    SoHopDong = cthd.SoHopDong,
                                    NgayDi = cthd.NgayDi,
                                    NgayVe = cthd.NgayVe,
                                    BienSoXe = cthd.BienSoXe,
                                    DiaDiemDon = cthd.DiaDiemDon,
                                    GhiChu = cthd.GhiChu,
                                    Gia = cthd.Gia,
                                    GioDon = cthd.GioDon,
                                    HuongDanVien = cthd.HuongDanVien,
                                    MaChiPhi = cthd.MaChiPhi,
                                    MaCongTy = cthd.MaCongTy,
                                    MaLoaiXe = cthd.MaLoaiXe,
                                    MaTaiXe = cthd.MaTaiXe,
                                    MaXe = cthd.MaXe,
                                    QuaDem = cthd.QuaDem,
                                    SoLuong = cthd.SoLuong,
                                    SoLuongNguoi = cthd.SoLuongNguoi,
                                    PhuXe = cthd.PhuXe,
                                    TaiXeNgoai = cthd.TaiXeNgoai,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == cthd.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    Xes = (
                                                from x in entity.Xes
                                                where x.MaXe == cthd.MaXe
                                                select new XeViewModel()
                                                {
                                                    BienSo = x.BienSo,
                                                    GhiChu = x.GhiChu
                                                }).FirstOrDefault(),
                                    TaiXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.MaTaiXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    PhuXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.PhuXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                }).OrderByDescending(n => n.SoHopDong).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        #endregion

        #region lấy danh sách chi tiết hợp đồng theo tháng
        public static List<CT_HopDongViewModel> layDanhSachCTHDTheoThang()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cthd in entity.CT_HopDongs
                                select new CT_HopDongViewModel()
                                {
                                    SoCTHopDong = cthd.SoCTHopDong,
                                    SoHopDong = cthd.SoHopDong,
                                    NgayDi = cthd.NgayDi,
                                    NgayVe = cthd.NgayVe,
                                    BienSoXe = cthd.BienSoXe,
                                    DiaDiemDon = cthd.DiaDiemDon,
                                    GhiChu = cthd.GhiChu,
                                    Gia = cthd.Gia,
                                    GioDon = cthd.GioDon,
                                    HuongDanVien = cthd.HuongDanVien,
                                    MaChiPhi = cthd.MaChiPhi,
                                    MaCongTy = cthd.MaCongTy,
                                    MaLoaiXe = cthd.MaLoaiXe,
                                    MaTaiXe = cthd.MaTaiXe,
                                    MaXe = cthd.MaXe,
                                    QuaDem = cthd.QuaDem,
                                    SoLuong = cthd.SoLuong,
                                    SoLuongNguoi = cthd.SoLuongNguoi,
                                    PhuXe = cthd.PhuXe,
                                    TaiXeNgoai = cthd.TaiXeNgoai,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == cthd.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    Xes = (
                                                from x in entity.Xes
                                                where x.MaXe == cthd.MaXe
                                                select new XeViewModel()
                                                {
                                                    BienSo = x.BienSo,
                                                    GhiChu = x.GhiChu
                                                }).FirstOrDefault(),
                                    TaiXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.MaTaiXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    PhuXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.PhuXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    HopDongs = (
                                                from hd in entity.HopDongs
                                                where hd.SoHopDong == cthd.SoHopDong
                                                select new HopDongViewModel()
                                                {
                                                    MaTrangThai = hd.MaTrangThai
                                                }).FirstOrDefault()
                                }).OrderByDescending(n => n.SoHopDong).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region lấy danh sách chi tiết hợp đồng theo ngày
        /// <summary>
        /// lấy danh sách chi tiết hợp đồng theo ngày
        /// </summary>
        /// <returns></returns>
        public static List<CT_HopDongViewModel> LayDanhSachChiTietHopDongTheoNgay(DateTime date)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cthd in entity.CT_HopDongs
                                join hd in entity.HopDongs on cthd.SoHopDong equals hd.SoHopDong
                                where cthd.NgayDi.Day <= date.Day && cthd.NgayDi.Month <= date.Month && cthd.NgayDi.Year <= date.Year
                                && cthd.NgayVe.Day >= date.Day && cthd.NgayVe.Month >= date.Month && cthd.NgayVe.Year >= date.Year
                                select new CT_HopDongViewModel()
                                {
                                    SoCTHopDong = cthd.SoCTHopDong,
                                    SoHopDong = cthd.SoHopDong,
                                    NgayDi = cthd.NgayDi,
                                    NgayVe = cthd.NgayVe,
                                    BienSoXe = cthd.BienSoXe,
                                    DiaDiemDon = cthd.DiaDiemDon,
                                    GhiChu = cthd.GhiChu,
                                    Gia = cthd.Gia,
                                    GioDon = cthd.GioDon,
                                    HuongDanVien = cthd.HuongDanVien,
                                    MaChiPhi = cthd.MaChiPhi,
                                    MaCongTy = cthd.MaCongTy,
                                    MaLoaiXe = cthd.MaLoaiXe,
                                    MaTaiXe = cthd.MaTaiXe,
                                    MaXe = cthd.MaXe,
                                    QuaDem = cthd.QuaDem,
                                    SoLuong = cthd.SoLuong,
                                    SoLuongNguoi = cthd.SoLuongNguoi,
                                    PhuXe = cthd.PhuXe,
                                    TaiXeNgoai = cthd.TaiXeNgoai,
                                    CongTies = (
                                                from ct in entity.CongTies
                                                where ct.MaCongTy == cthd.MaCongTy
                                                select new CongTiesViewModel()
                                                {
                                                    TenCongTy = ct.TenCongTy
                                                }
                                    ).FirstOrDefault(),
                                    KhachHangs = (
                                                from kh in entity.KhachHangs
                                                where kh.MaKH == hd.MaKH
                                                select new KhachHangViewModel()
                                                {
                                                    TenKH = kh.TenKH
                                                }
                                    ).FirstOrDefault(),
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == cthd.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    Xes = (
                                                from x in entity.Xes
                                                where x.MaXe == cthd.MaXe
                                                select new XeViewModel()
                                                {
                                                    BienSo = x.BienSo,
                                                    GhiChu = x.GhiChu
                                                }).FirstOrDefault(),
                                    TaiXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.MaTaiXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen,
                                                    SDT = nv.SDT,
                                                }).FirstOrDefault(),
                                    PhuXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.PhuXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen,
                                                    SDT = nv.SDT,
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

        #region Lấy danh sách lịch chạy theo mã nhân viên
        public static List<CT_HopDongViewModel> LayDSCTHDTheoMaNV(String MaNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cthd in entity.CT_HopDongs
                                join hd in entity.HopDongs on cthd.SoHopDong equals hd.SoHopDong
                                where cthd.MaTaiXe == MaNV || cthd.PhuXe == MaNV
                                select new CT_HopDongViewModel()
                                {
                                    SoCTHopDong = cthd.SoCTHopDong,
                                    SoHopDong = cthd.SoHopDong,
                                    NgayDi = cthd.NgayDi,
                                    NgayVe = cthd.NgayVe,
                                    BienSoXe = cthd.BienSoXe,
                                    DiaDiemDon = cthd.DiaDiemDon,
                                    GhiChu = cthd.GhiChu,
                                    Gia = cthd.Gia,
                                    GioDon = cthd.GioDon,
                                    HuongDanVien = cthd.HuongDanVien,
                                    MaChiPhi = cthd.MaChiPhi,
                                    MaCongTy = cthd.MaCongTy,
                                    MaLoaiXe = cthd.MaLoaiXe,
                                    MaTaiXe = cthd.MaTaiXe,
                                    MaXe = cthd.MaXe,
                                    QuaDem = cthd.QuaDem,
                                    SoLuong = cthd.SoLuong,
                                    SoLuongNguoi = cthd.SoLuongNguoi,
                                    PhuXe = cthd.PhuXe,
                                    TaiXeNgoai = cthd.TaiXeNgoai,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == cthd.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    Xes = (
                                                from x in entity.Xes
                                                where x.MaXe == cthd.MaXe
                                                select new XeViewModel()
                                                {
                                                    BienSo = x.BienSo,
                                                    GhiChu = x.GhiChu
                                                }).FirstOrDefault(),
                                    TaiXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.MaTaiXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    PhuXes = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == cthd.PhuXe
                                                select new NhanVienViewModel()
                                                {
                                                    MaNV = nv.MaNV,
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    HopDongs =(
                                                    from hd1 in entity.HopDongs
                                                    where hd1.SoHopDong == cthd.SoHopDong
                                                    select new HopDongViewModel()
                                                    {
                                                        MaTrangThai = hd.MaTrangThai
                                                    }
                                              ).FirstOrDefault(),
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

        #region Cập nhật mã công ty khi bỏ chọn xe
        public static Boolean CapNhatMaCTy(int SoCTHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                CT_HopDong result = entity.CT_HopDongs.SingleOrDefault(n => n.SoCTHopDong == SoCTHopDong);
                result.MaCongTy = null;
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
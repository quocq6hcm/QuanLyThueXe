using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Models;

namespace QuanLyThueXe.Queries
{
    public class XeQueries
    {

        #region  Mã xe tự động tăng
        /// <summary>
        /// Tự động tăng mã xe
        /// </summary>
        /// <returns>String </returns>
        /// Begin
        public static String TangMaXe()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaXe = "";
                var Maxe = entity.Xes.OrderByDescending(n => n.STT).FirstOrDefault();
                if (Maxe == null)
                {
                    MaXe = "Xe1";
                }
                else
                {
                    Maxe.MaXe = Maxe.MaXe.Substring(2, Maxe.MaXe.Length - 2);
                    int iSo = int.Parse(Maxe.MaXe);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaXe = "Xe" + sSo;
                }
                return MaXe;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        ///End
        #endregion
            
        #region Lấy danh sách xe
        /// <summary>
        /// Lấy danh sách se
        /// </summary>
        /// <returns>list</returns>
        /// Begin 
        public static List<XeViewModel> LayDanhSachXe()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from x in entity.Xes
                                where x.Dang == true
                                select new XeViewModel()
                                {
                                    MaXe = x.MaXe,
                                    BienSo = x.BienSo,
                                    MoTa = x.Mota,
                                    HinhAnh = x.HinhAnh,
                                    Dang = x.Dang,
                                    MaCongTy = x.MaCongTy,
                                    MaThuongHieu = x.MaThuongHieu,
                                    NgayDangKiem = x.NgayDangKiem,
                                    GhiChu = x.GhiChu,
                                    Status = x.Status,
                                    NgayBaoTriXe = x.NgayBaoTriXe,
                                    SoKm = x.SoKm,
                                    SoLan = x.SoLan,
                                    ThoiGianGanDay = x.ThoiGianGanDay,
                                    MaLoaiXe = x.MaLoaiXe,
                                    STT = x.STT,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == x.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    STT = lx.STT,
                                                    MaLoaiXe = lx.MaLoaiXe,
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    ThuongHieus = (
                                    from th in entity.ThuongHieuXes
                                    where th.MaThuongHieu == x.MaThuongHieu
                                    select new ThuongHieuViewModel()
                                    {
                                        STT = th.STT,
                                        MaThuongHieu = th.MaThuongHieu,
                                        TenThuongHieu = th.TenThuongHieu
                                    }).FirstOrDefault(),
                                }).OrderBy(n => n.LoaiXes.STT).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        ///End
        #endregion
            
        #region Lấy thông tin chi tiết của 1 xe

        /// <summary>
        /// LayThongTinChiTietXe
        /// </summary>
        /// <param name="MaXe"></param>
        /// <returns>single</returns>
        /// Begin
        public static XeViewModel LayThongTinChiTietXe(string MaXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from x in entity.Xes
                                where x.MaXe == MaXe
                                select new XeViewModel()
                                {
                                    MaXe = x.MaXe,
                                    BienSo = x.BienSo,
                                    MoTa = x.Mota,
                                    HinhAnh = x.HinhAnh,
                                    Dang = x.Dang,
                                    MaCongTy = x.MaCongTy,
                                    MaThuongHieu = x.MaThuongHieu,
                                    NgayDangKiem = x.NgayDangKiem,
                                    GhiChu = x.GhiChu,
                                    Status = x.Status,
                                    NgayBaoTriXe = x.NgayBaoTriXe,
                                    SoKm = x.SoKm,
                                    SoLan = x.SoLan,
                                    ThoiGianGanDay = x.ThoiGianGanDay,
                                    BaoHiemTuNguyen = x.BaoHiemTuNguyen,
                                    BaoHiemBatBuoc = x.BaoHiemBatBuoc,
                                    DangKi = x.NgayDangKi,
                                    DangKiem = x.DangKiem,
                                    HopDong = x.HopDong,
                                    ChuXe = x.ChuXe,
                                    DiaChi = x.DiaChi,
                                    MaLoaiXe = x.MaLoaiXe,
                                    MaNV = x.MaNV,
                                    LoaiXes = (
                                                from lx in entity.LoaiXes
                                                where lx.MaLoaiXe == x.MaLoaiXe
                                                select new LoaiXeViewModel()
                                                {
                                                    TenLoaiXe = lx.TenLoaiXe
                                                }).FirstOrDefault(),
                                    CongTies = (
                                                from ct in entity.CongTies
                                                where ct.MaCongTy == x.MaCongTy
                                                select new CongTiesViewModel()
                                                {
                                                    TenCongTy = ct.TenCongTy
                                                }).FirstOrDefault(),
                                    ThuongHieus = (
                                                    from th in entity.ThuongHieuXes
                                                    where th.MaThuongHieu == x.MaThuongHieu
                                                    select new ThuongHieuViewModel()
                                                    {
                                                        TenThuongHieu = th.TenThuongHieu
                                                    }).FirstOrDefault(),
                                    NhanViens = (
                                                    from nv in entity.NhanViens
                                                    where nv.MaNV == x.MaNV
                                                    select new NhanVienViewModel()
                                                    {
                                                        HoTen = nv.HoTen
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
        /// End
        #endregion
            
        #region Thêm xe 

        /// <summary>
        /// Thêm xe
        /// </summary>
        /// <param name="xe"></param>
        /// <returns>Boolean</returns>
        /// Begin
        public static Boolean ThemXe(XeViewModel xe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var x = new Xe();
                x.MaXe = TangMaXe();
                x.BienSo = xe.BienSo;
                x.Mota = xe.MoTa;
                x.MaLoaiXe = xe.MaLoaiXe;
                x.HinhAnh = xe.HinhAnh;
                x.Dang = true;
                x.MaCongTy = xe.MaCongTy;
                x.MaThuongHieu = xe.MaThuongHieu;
                x.NgayDangKiem = xe.NgayDangKiem;
                x.GhiChu = xe.GhiChu;
                x.Status = "0";
                x.NgayBaoTriXe = xe.NgayBaoTriXe;
                x.SoKm = xe.SoKm;
                x.SoLan = 0;
                x.ThoiGianGanDay = DateTime.Now;
                x.MaNV = xe.MaNV;
                x.BaoHiemTuNguyen = xe.BaoHiemTuNguyen;
                x.BaoHiemBatBuoc = xe.BaoHiemBatBuoc;
                x.NgayDangKi = xe.DangKi;
                x.DangKiem = xe.DangKiem;
                x.HopDong = xe.HopDong;
                x.ChuXe = xe.ChuXe;
                x.DiaChi = xe.DiaChi;
                entity.Xes.Add(x);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        ///End
        #endregion
            
        #region Chỉnh sửa xe

        /// <summary>
        /// Chỉnh sửa xe
        /// </summary>
        /// <param name="MaXe"></param>
        /// <returns>single</returns>
        // Begin
        public static Boolean ChinhSuaXe(XeViewModel xe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.Xes.SingleOrDefault(n => n.MaXe == xe.MaXe);
                result.BienSo = xe.BienSo;
                result.Mota = xe.MoTa;
                result.MaLoaiXe = xe.MaLoaiXe;
                result.HinhAnh = xe.HinhAnh;
                result.MaCongTy = xe.MaCongTy;
                result.MaThuongHieu = xe.MaThuongHieu;
                result.NgayDangKiem = xe.NgayDangKiem;
                result.GhiChu = xe.GhiChu;
                result.NgayBaoTriXe = xe.NgayBaoTriXe;
                result.SoKm = xe.SoKm;
                result.SoLan = xe.SoLan;
                result.MaNV = xe.MaNV;
                result.BaoHiemTuNguyen = xe.BaoHiemTuNguyen;
                result.BaoHiemBatBuoc = xe.BaoHiemBatBuoc;
                result.NgayDangKi= xe.DangKi;
                result.DangKiem = xe.DangKiem;
                result.HopDong = xe.HopDong;
                result.ChuXe = xe.ChuXe;
                result.DiaChi = xe.DiaChi;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        //END
        #endregion

        #region Lấy danh sách xe theo loại xe
        public static List<XeViewModel> LayDanhSachXeTheoLoaiXe(string MaLoaiXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from x in entity.Xes
                                where (x.MaLoaiXe == MaLoaiXe) && (x.Status == "0" || x.Status == "1") && x.Dang == true
                                select new XeViewModel()
                                {
                                    BienSo = x.BienSo,
                                    MaXe = x.MaXe,
                                    Status = x.Status
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

        #region xóa xe
        /// Xóa xe
        /// </summary>
        /// <param name="MaXe"></param>
        /// <returns></returns>
        public static Boolean XoaXe(String MaXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var Xe = entity.Xes.SingleOrDefault(n => n.MaXe == MaXe);
                Xe.Dang = false;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        //END
        #endregion

        #region Cập nhật ngày đăng kiểm với bảo hiểm xe

        public static Boolean CapNhatDangKiemVaBaoHiemXe()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                DateTime dateNow = (DateTime.Now).AddMonths(2);
                var lstXe = entity.Xes.ToList();
                foreach(var x in lstXe)
                {
                    if(x.NgayBaoTriXe <= dateNow && x.NgayDangKiem <= dateNow)
                    {
                        x.GhiChu = "Ngày đăng kiểm hết hạn vào " + x.NgayDangKiem.Value.ToString("dd/MM/yyyy") + " Ngày bảo hiểm xe hết hạn vào "+ x.NgayBaoTriXe.Value.ToString("dd/MM/yyyy");
                    }
                    else if(x.NgayBaoTriXe <= dateNow)
                    {
                        x.GhiChu = "Ngày bảo hiểm xe hết hạn vào " + x.NgayBaoTriXe.Value.ToString("dd/MM/yyyy");
                    }
                    else if (x.NgayDangKiem <= dateNow)
                    {
                        x.GhiChu = "Ngày đăng kiểm hết hạn vào " + x.NgayDangKiem.Value.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        x.GhiChu = "";
                    }
                }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Models;
namespace QuanLyThueXe.Queries
{
    public class TrangThaiQueries
    {
        #region Danh sách trạng thái
        public static List<TrangThaiHopDongViewModel> LayDanhSachTrangThai()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from tt in entity.TrangThaiHopDongs
                                select new TrangThaiHopDongViewModel()
                                {
                                    MaTrangThai = tt.MaTrangThai,
                                    TenTrangThai = tt.TenTrangThai
                                }
                            ).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Cap Nhat trang thai dang chay của hợp đồng
        /// <summary>
        /// Cap Nhat trang thai dang chay của hợp đồng
        /// </summary>
        /// <param name="SoHopDong"></param>
        /// <returns></returns>
        public static Boolean CapNhatTrangThaiDangChay(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == SoHopDong);
                foreach (var c in cthd)
                {
                    if (c.NgayDi < DateTime.Now)
                    {
                        HopDong result = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == SoHopDong);
                        result.MaTrangThai = "1";
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

        #region Cap Nhat trang thai hoành thành của hợp đồng
        /// <summary>
        /// Cap Nhat trang thai hoành thành của hợp đồng
        /// </summary>
        /// <param name="SoHopDong"></param>
        /// <returns></returns>
        public static Boolean CapNhatTrangThaiHoanThanh(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == SoHopDong);
                result.MaTrangThai = "2";
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

        #region Cập nhật trạng thái đang chờ thanh toán
        public static Boolean CapNhatTrangThaiChoThanhToan()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var hd = entity.HopDongs.Where(n => n.MaTrangThai == "1");
                foreach (var item in hd)
                {
                    var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == item.SoHopDong);
                    foreach (var c in cthd)
                        if (c.NgayVe < DateTime.Now)
                        {
                            HopDong result = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == c.SoHopDong);
                            result.MaTrangThai = "3";
                            TrangThaiQueries.CapNhatTrangThaiPhuXeRanh(c.SoHopDong);
                            TrangThaiQueries.CapNhatTrangThaiTaiXeRanh(c.SoHopDong);
                            TrangThaiQueries.CapNhatTrangThaiXeRanh(c.SoHopDong);
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

        #region Cap Nhat trang thai Hủy của hợp đồng
        /// <summary>
        /// Cap Nhat trang thai Hủy của hợp đồng
        /// </summary>
        /// <param name="SoHopDong"></param>
        /// <returns></returns>
        public static Boolean CapNhatTrangThaiHuy(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == SoHopDong);
                result.MaTrangThai = "-1";
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

        #region Cập nhật trạng thái tài xế rãnh
        public static Boolean CapNhatTrangThaiTaiXeRanh(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var hd = entity.HopDongs.Where(n => n.SoHopDong == SoHopDong);
                foreach (var item in hd)
                {
                    var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == item.SoHopDong);
                    foreach (var c in cthd)
                    {
                        NhanVien result = entity.NhanViens.SingleOrDefault(n => n.MaNV == c.MaTaiXe);
                        result.Status = "0";
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

        #region Cập nhật trạng thái tài xế đang chờ
        public static Boolean CapNhatTrangThaiTaiXeDangCho(String MaTaiXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.NhanViens.SingleOrDefault(n => n.MaNV == MaTaiXe);
                result.Status = "1";
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

        #region Cập nhật trạng thái tài xế đang chạy
        public static Boolean CapNhatTrangThaiTaiXeDangChay()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var hd = entity.HopDongs.Where(n => n.MaTrangThai == "1");
                foreach (var item in hd)
                {
                    var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == item.SoHopDong);
                    foreach (var c in cthd)
                        if (c.NgayDi < DateTime.Now)
                        {
                            NhanVien result = entity.NhanViens.SingleOrDefault(n => n.MaNV == c.MaTaiXe);
                            result.Status = "2";
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

        #region Cập nhật trạng thái phụ xe rãnh
        public static Boolean CapNhatTrangThaiPhuXeRanh(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var hd = entity.HopDongs.Where(n => n.SoHopDong == SoHopDong);
                foreach (var item in hd)
                {
                    var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == item.SoHopDong);
                    foreach (var c in cthd)
                    {
                        NhanVien result = entity.NhanViens.SingleOrDefault(n => n.MaNV == c.PhuXe);
                        result.Status = "0";
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

        #region Cập nhật trạng thái phụ xe đang chờ
        public static Boolean CapNhatTrangThaiPhuXeDangCho(String PhuXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.NhanViens.SingleOrDefault(n => n.MaNV == PhuXe);
                result.Status = "1";
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

        #region Cập nhật trạng thái phụ xe đang chạy
        public static Boolean CapNhatTrangThaiPhuXeDangChay()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var hd = entity.HopDongs.Where(n => n.MaTrangThai == "1");
                foreach (var item in hd)
                {
                    var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == item.SoHopDong);
                    foreach (var c in cthd)
                        if (c.NgayDi < DateTime.Now)
                        {
                            NhanVien result = entity.NhanViens.SingleOrDefault(n => n.MaNV == c.PhuXe);
                            result.Status = "2";
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

        #region Cập nhật trạng thái xe rãnh
        public static Boolean CapNhatTrangThaiXeRanh(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var hd = entity.HopDongs.Where(n => n.SoHopDong == SoHopDong);
                foreach (var item in hd)
                {
                    var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == item.SoHopDong);
                    foreach (var c in cthd)
                    {
                        Xe result = entity.Xes.SingleOrDefault(n => n.MaXe == c.MaXe);
                        result.Status = "0";
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

        #region Cập nhật trạng thái xe đang chạy 
        public static Boolean CapNhatTrangThaiXeDangChay()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var hd = entity.HopDongs.Where(n => n.MaTrangThai == "1");
                foreach (var item in hd)
                {
                    var cthd = entity.CT_HopDongs.Where(n => n.SoHopDong == item.SoHopDong);
                    foreach (var c in cthd)
                        if (c.NgayDi < DateTime.Now)
                        {
                            Xe result = entity.Xes.SingleOrDefault(n => n.MaXe == c.MaXe);
                            result.Status = "2";
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

        #region Cập nhật trạng thái xe đang chờ
        public static Boolean CapNhatTrangThaiXeDangCho(String MaXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.Xes.SingleOrDefault(n => n.MaXe == MaXe);
                result.Status = "1";
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
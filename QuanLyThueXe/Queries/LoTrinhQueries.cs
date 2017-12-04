using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{   

    public class LoTrinhQueries
    {
        #region tự tăng mã lộ trình
        /// <summary>
        /// tự tăng mã lộ trình
        /// </summary>
        /// <returns></returns>
        public static String TuTangMaLT()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaLoTrinh = "";
                var MaLt = entity.LoTrinhs.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaLt == null)
                {
                    MaLoTrinh = "LT1";
                }
                else
                {
                    MaLt.MaLoTrinh = MaLt.MaLoTrinh.Substring(2, MaLt.MaLoTrinh.Length - 2);
                    int iSo = int.Parse(MaLt.MaLoTrinh);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaLoTrinh = "LT" + sSo;
                }
                return MaLoTrinh;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Lấy danh sách lộ trình đi
        /// <summary>
        /// Lấy danh sách lộ trình đi
        /// </summary>
        /// <returns></returns>
        public static List<LoTrinhViewModel> LayDanhSachLoTrinh()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from lt in entity.LoTrinhs
                                where lt.Dang == true
                                select new LoTrinhViewModel()
                                {
                                    MaLoTrinh = lt.MaLoTrinh,
                                    TenLoTrinh = lt.TenLoTrinh,
                                    MaKH = lt.MaKH,
                                    STT = lt.STT,
                                    KhachHangs = (from kh in entity.KhachHangs
                                                      where lt.MaKH == kh.MaKH
                                                      select new KhachHangViewModel()
                                                      {
                                                          MaKH = kh.MaKH,
                                                          TenKH = kh.TenKH
                                                      }).FirstOrDefault() 
                                }).OrderByDescending(n=>n.MaLoTrinh).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Thêm lộ trình
        /// <summary>
        /// Thêm lộ trình
        /// </summary>
        /// <param name="lotrinh"></param>
        /// <returns></returns>
        public static Boolean ThemLoTrinh(LoTrinhViewModel lotrinh)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var lt = new LoTrinh();
                lt.MaLoTrinh = TuTangMaLT();
                lt.TenLoTrinh = lotrinh.TenLoTrinh;
                lt.Dang = true;
                lt.MaKH = lotrinh.MaKH;
                entity.LoTrinhs.Add(lt);
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

        #region thông tin chi tiết lộ trình
        /// <summary>
        /// thông tin chi tiết lộ trình
        /// </summary>
        /// <param name="MaLT"></param>
        /// <returns></returns>
        public static LoTrinhViewModel ChiTiet_LoTrinh(String MaLT)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from lt in entity.LoTrinhs
                                where lt.MaLoTrinh == MaLT
                                select new LoTrinhViewModel()
                                {
                                    MaLoTrinh = lt.MaLoTrinh,
                                    TenLoTrinh = lt.TenLoTrinh,
                                    MaKH = lt.MaKH,
                                    KhachHangs = (from kh in entity.KhachHangs
                                                      where lt.MaKH == kh.MaKH
                                                      select new KhachHangViewModel()
                                                      {
                                                          MaKH = kh.MaKH,
                                                          TenKH = kh.TenKH
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

        #region cập nhật lộ trình
        /// <summary>
        /// cập nhật lộ trình
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public static Boolean ChinhSua_LT(LoTrinhViewModel lt)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var LT = entity.LoTrinhs.SingleOrDefault(n => n.MaLoTrinh == lt.MaLoTrinh);
                LT.TenLoTrinh = lt.TenLoTrinh;
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

        #region Lấy danh sách lộ trình theo mã khách hàng
        /// <summary>
        /// Lấy danh sách lộ trình theo mã khách hàng
        /// </summary>
        /// <param name="MaKH"></param>
        /// <returns></returns>
        public static List<LoTrinhViewModel> LayDanhSachLoTrinhTheoMaKH(String MaKH)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from lt in entity.LoTrinhs
                                where MaKH == lt.MaKH
                                select new LoTrinhViewModel()
                                {
                                    MaKH = lt.MaKH,
                                    TenLoTrinh = lt.TenLoTrinh,
                                    MaLoTrinh = lt.MaLoTrinh
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

        #region xóa lộ trình
        /// <summary>
        /// Xóa lộ trình
        /// </summary>
        /// <param name="MaLoTrinh"></param>
        /// <returns></returns>
        public static Boolean XoaLT(String MaLT)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var LT = entity.LoTrinhs.SingleOrDefault(n => n.MaLoTrinh == MaLT);
                LT.Dang = false;
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
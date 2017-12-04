using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class LoaiXeQueries
    {
        #region Tự tăng mã loại xe
        /// <summary>
        /// Tự tăng mã loại xe
        /// </summary>
        /// <returns></returns>
        public static String TuTangMaLX()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaLoaiXe = "";
                var MaLx = entity.LoaiXes.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaLx == null)
                {
                    MaLoaiXe = "LX1";
                }
                else
                {
                    MaLx.MaLoaiXe = MaLx.MaLoaiXe.Substring(2, MaLx.MaLoaiXe.Length -2);
                    int iSo = int.Parse(MaLx.MaLoaiXe);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaLoaiXe = "LX" + sSo;
                }
                return MaLoaiXe;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Lấy danh sách loại xe
        /// <summary>
        /// Lấy danh sách loại xe
        /// </summary>
        /// <returns></returns>
        public static List<LoaiXeViewModel> LayDanhSachLoaiXe()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from lx in entity.LoaiXes
                                select new LoaiXeViewModel()
                                {
                                    MaLoaiXe = lx.MaLoaiXe,
                                    TenLoaiXe = lx.TenLoaiXe,
                                    Dang = lx.Dang,
                                    STT = lx.STT,
                                }).OrderBy(n => n.STT).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region thông tin chi tiết 1 loại xe
        /// <summary>
        /// thông tin chi tiết 1 loại xe
        /// </summary>
        /// <param name="MaLoaiXe"></param>
        /// <returns></returns>
        public static LoaiXeViewModel ChiTiet_LoaiXe(String MaLoaiXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from loaixe in entity.LoaiXes
                                where loaixe.MaLoaiXe == MaLoaiXe
                                select new LoaiXeViewModel()
                                {
                                    MaLoaiXe = loaixe.MaLoaiXe,
                                    TenLoaiXe = loaixe.TenLoaiXe,
                                    Dang = loaixe.Dang
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

        #region cập nhật loại xe
        /// <summary>
        /// cập nhật loại xe
        /// </summary>
        /// <param name="loaixe"></param>
        /// <returns></returns>
        public static Boolean ChinhSuaLoaiXe(LoaiXeViewModel loaixe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var loaiXe = entity.LoaiXes.SingleOrDefault(n => n.MaLoaiXe == loaixe.MaLoaiXe);
                loaiXe.TenLoaiXe = loaixe.TenLoaiXe;
                loaiXe.Dang = loaixe.Dang;
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

        #region thêm loại xe mới
        /// <summary>
        /// thêm loại xe mới
        /// </summary>
        /// <param name="loaixe"></param>
        /// <returns></returns>
        public static Boolean ThemLoaiXe(LoaiXeViewModel loaixe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var lx = new LoaiXe();
                lx.MaLoaiXe = TuTangMaLX();
                lx.TenLoaiXe = loaixe.TenLoaiXe;
                lx.Dang = true;
                entity.LoaiXes.Add(lx);
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
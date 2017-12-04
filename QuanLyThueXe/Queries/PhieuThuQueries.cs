using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class PhieuThuQueries
    {

        #region tự tăng mã phiếu thu
        public static String TuTangMaPhieuThu()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String SoPhieuThu = "";
                var soPT = entity.PhieuThus.OrderByDescending(n => n.STT).FirstOrDefault();
                if (soPT == null)
                {
                    SoPhieuThu = "PT1";
                }
                else
                {
                    soPT.SoPhieuThu = soPT.SoPhieuThu.Substring(2, soPT.SoPhieuThu.Length - 2);
                    int iSo = int.Parse(soPT.SoPhieuThu);
                    iSo++;
                    string sSo = iSo.ToString();
                    SoPhieuThu = "PT" + sSo;
                }
                return SoPhieuThu;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Danh sách phiếu thu
        /// <summary>
        /// Danh sach phieu thu
        /// </summary>
        public static List<PhieuThuViewModel> DanhSachPhieuThu()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from pt in entity.PhieuThus
                                select new PhieuThuViewModel()
                                {
                                    SoPhieuThu = pt.SoPhieuThu,
                                    LyDo = pt.LyDo,
                                    NgayThu = pt.NgayThu,
                                    SoTienThu = pt.SoTienThu,
                                    MaNV = pt.NhanVien.HoTen,
                                    NguoiNop = pt.NguoiNop,
                                    DiaChi= pt.DiaChi,
                                    NhanViens = (from nv in entity.NhanViens
                                                 where pt.MaNV == nv.MaNV
                                                 select new NhanVienViewModel()
                                                 {
                                                     MaNV = nv.MaNV,
                                                     HoTen = nv.HoTen
                                                 }).FirstOrDefault()
                                }).OrderBy(n => n.SoPhieuThu).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Thêm Phiếu Thu
        /// <summary>
        /// Thêm phieu thu
        /// </summary>
        /// <param PhieuThuViewModel="SoPhieuThu"></param>
        /// <returns>Boolean</returns>
        public static Boolean ThemPhieuThu(PhieuThuViewModel PT)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var pt = new PhieuThu();
                pt.SoPhieuThu = TuTangMaPhieuThu();
                pt.LyDo = PT.LyDo;
                pt.NgayThu = DateTime.Now;
                pt.SoTienThu = PT.SoTienThu;
                pt.MaNV = PT.MaNV;
                pt.NguoiNop = PT.NguoiNop;
                pt.DiaChi = PT.DiaChi;
                entity.PhieuThus.Add(pt);
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

        #region Thông tin chi tiết phiếu thu
        //thông tin chi tiết phiếu thu
        public static PhieuThuViewModel ChiTiet_PT(string SoPT)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from pt in entity.PhieuThus
                                where pt.SoPhieuThu == SoPT
                                select new PhieuThuViewModel()
                                {
                                    SoPhieuThu = pt.SoPhieuThu,
                                    MaNV = pt.MaNV,
                                    LyDo = pt.LyDo,
                                    NgayThu = pt.NgayThu,
                                    SoTienThu = pt.SoTienThu,
                                    NguoiNop = pt.NguoiNop,
                                    DiaChi = pt.DiaChi,
                                    NhanViens = (from nv in entity.NhanViens
                                                 where pt.MaNV == nv.MaNV
                                                 select new NhanVienViewModel()
                                                 {
                                                     MaNV = nv.MaNV,
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
        #endregion

        #region chỉnh sửa phiếu thu
        // chỉnh sửa phiếu thu
        public static Boolean ChinhSuaPT(PhieuThuViewModel pt)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var Pt = entity.PhieuThus.SingleOrDefault(n => n.SoPhieuThu == pt.SoPhieuThu);
                Pt.MaNV = pt.MaNV;
                Pt.LyDo = pt.LyDo;
                Pt.NgayThu = pt.NgayThu;
                Pt.SoTienThu = pt.SoTienThu;
                Pt.DiaChi = pt.DiaChi;
                Pt.NguoiNop = pt.NguoiNop;
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
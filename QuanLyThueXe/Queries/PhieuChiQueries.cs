using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class PhieuChiQueries
    {

        #region tự tăng mã phiếu chi
        public static String TuTangMaPhieuChi()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String SoPhieuChi = "";
                var soPC = entity.PhieuChis.OrderByDescending(n => n.STT).FirstOrDefault();
                if (soPC == null)
                {
                    SoPhieuChi = "PC1";
                }
                else
                {
                    soPC.SoPhieuChi = soPC.SoPhieuChi.Substring(2, soPC.SoPhieuChi.Length - 2);
                    int iSo = int.Parse(soPC.SoPhieuChi);
                    iSo++;
                    string sSo = iSo.ToString();
                    SoPhieuChi = "PC" + sSo;
                }
                return SoPhieuChi;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        /// <summary>
        /// Danh sach phieu chi
        /// </summary>
        public static List<PhieuChiViewModel> DanhSachPhieuChi()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from pc in entity.PhieuChis
                                select new PhieuChiViewModel()
                                {
                                    SoPhieuChi = pc.SoPhieuChi,
                                    LyDo = pc.LyDo,
                                    NgayChi = pc.NgayChi,
                                    SoTienChi = pc.SoTienChi,
                                    MaNV = pc.MaNV,
                                    NguoiNhan = pc.NguoiNhan,
                                    DiaChi = pc.DiaChi,
                                    NhanViens = (from nv in entity.NhanViens
                                                 where pc.MaNV == nv.MaNV
                                                 select new NhanVienViewModel()
                                                 {
                                                     MaNV = nv.MaNV,
                                                     HoTen = nv.HoTen
                                                 }).FirstOrDefault()
                                }).OrderBy(n => n.SoPhieuChi).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        /// <summary>
        /// Thêm phieu chi
        /// </summary>
        /// <param PhieuChiViewModel="SoPhieuChi"></param>
        /// <returns>Boolean</returns>
        public static Boolean ThemPhieuChi(PhieuChiViewModel PC)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var pc = new PhieuChi();
                pc.SoPhieuChi = TuTangMaPhieuChi();
                pc.LyDo = PC.LyDo;
                pc.NgayChi = DateTime.Now;
                pc.SoTienChi = PC.SoTienChi;
                pc.MaNV = PC.MaNV;
                pc.NguoiNhan = PC.NguoiNhan;
                pc.DiaChi = PC.DiaChi;
                entity.PhieuChis.Add(pc);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        //thông tin chi tiết phiếu chi
        public static PhieuChiViewModel ChiTiet_PC(String SoPC)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from pc in entity.PhieuChis
                                where pc.SoPhieuChi == SoPC
                                select new PhieuChiViewModel()
                                {
                                    SoPhieuChi = pc.SoPhieuChi,
                                    MaNV = pc.MaNV,
                                    LyDo = pc.LyDo,
                                    NgayChi = pc.NgayChi,
                                    SoTienChi = pc.SoTienChi,
                                    NguoiNhan = pc.NguoiNhan,
                                    DiaChi = pc.DiaChi,
                                    NhanViens = (from nv in entity.NhanViens
                                                 where pc.MaNV == nv.MaNV
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

        // chỉnh sửa phiếu chi
        public static Boolean ChinhSuaPC(PhieuChiViewModel pc)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var Pc = entity.PhieuChis.SingleOrDefault(n => n.SoPhieuChi == pc.SoPhieuChi);
                Pc.MaNV = pc.MaNV;
                Pc.LyDo = pc.LyDo;
                Pc.NgayChi = pc.NgayChi;
                Pc.SoTienChi = pc.SoTienChi;
                Pc.NguoiNhan = pc.NguoiNhan;
                Pc.DiaChi = pc.DiaChi;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
    }
}
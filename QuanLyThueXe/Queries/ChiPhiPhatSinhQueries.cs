using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Models;
namespace QuanLyThueXe.Queries
{
    public class ChiPhiPhatSinhQueries
    {
        #region tự tăng mã phiếu thu
        public static String TuTangMaCPPS()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaChiPhi = "";
                var maCP = entity.ChiPhiPhatSinhs.OrderByDescending(n => n.STT).FirstOrDefault();
                if (maCP == null)
                {
                    MaChiPhi = "CP1";
                }
                else
                {
                    maCP.MaChiPhi = maCP.MaChiPhi.Substring(2, maCP.MaChiPhi.Length - 2);
                    int iSo = int.Parse(maCP.MaChiPhi);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaChiPhi = "CP" + sSo;
                }
                return MaChiPhi;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Danh sách chi phí phát sinh
        public static List<ChiPhiPhatSinhViewModel> DanhSachChiPhiPhatSinh()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cpps in entity.ChiPhiPhatSinhs
                                select new ChiPhiPhatSinhViewModel()
                                {
                                    MaChiPhi = cpps.MaChiPhi,
                                    TenChiPhi = cpps.TenChiPhi,
                                    MoTa = cpps.Mota,
                                    PhiPhatSinh = cpps.PhiPhatSinh,
                                    SoLuong = cpps.SoLuong
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

        #region Thêm Chi phí phát sinh
        public static Boolean ThemCPPS(ChiPhiPhatSinhViewModel CP)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var cp = new ChiPhiPhatSinh();
                cp.MaChiPhi = TuTangMaCPPS();
                cp.TenChiPhi = CP.TenChiPhi;
                cp.PhiPhatSinh = CP.PhiPhatSinh;
                cp.Mota = CP.MoTa;
                cp.SoLuong = 1;
                entity.ChiPhiPhatSinhs.Add(cp);
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

        #region Chi Tiết CPPS
        public static ChiPhiPhatSinhViewModel ChiTiet_CPPS(string MaCP)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from cp in entity.ChiPhiPhatSinhs
                                where cp.MaChiPhi == MaCP
                                select new ChiPhiPhatSinhViewModel()
                                {
                                    MaChiPhi = cp.MaChiPhi,
                                    TenChiPhi = cp.TenChiPhi,
                                    PhiPhatSinh = cp.PhiPhatSinh,
                                    MoTa = cp.Mota,
                                    SoLuong = cp.SoLuong,
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

        #region Chỉnh sửa CPPS
        public static Boolean ChinhSuaCPPS(ChiPhiPhatSinhViewModel cp)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var Cp = entity.ChiPhiPhatSinhs.SingleOrDefault(n => n.MaChiPhi == cp.MaChiPhi);
                Cp.TenChiPhi = cp.TenChiPhi;
                Cp.PhiPhatSinh = cp.PhiPhatSinh;
                Cp.Mota = cp.MoTa;
                Cp.SoLuong = 1;
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
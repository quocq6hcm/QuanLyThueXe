using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Models;

namespace QuanLyThueXe.Queries
{
    public class DieuPhoiQueries
    {
        public static Boolean CapNhatXeBiTrung(String MaXe, CT_HopDongViewModel CTHDMoi)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.CT_HopDongs.Where(n => n.MaXe == MaXe);
                foreach (var CTHDCu in result)
                {
                    var kq = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == CTHDCu.SoHopDong && n.MaTrangThai == "0");
                    if (kq != null)
                        if (
                            (CTHDMoi.NgayDi > CTHDCu.NgayDi && CTHDMoi.NgayDi < CTHDCu.NgayVe) ||
                            (CTHDMoi.NgayVe > CTHDCu.NgayDi && CTHDMoi.NgayVe < CTHDCu.NgayVe) ||
                            (CTHDCu.NgayDi > CTHDMoi.NgayDi && CTHDCu.NgayDi < CTHDMoi.NgayVe) ||
                            (CTHDCu.NgayVe > CTHDMoi.NgayDi && CTHDCu.NgayVe < CTHDMoi.NgayVe)
                            )
                        {
                            CTHDCu.MaXe = null;
                            break;
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


        public static Boolean CapNhatXeBoChon(String MaXe)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.Xes.SingleOrDefault(n => n.MaXe == MaXe);
                result.Status = "0";
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        public static Boolean CapNhatTaiXeBiTrung(String MaTaiXe, CT_HopDongViewModel CTHDMoi)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.CT_HopDongs.Where(n => n.MaTaiXe == MaTaiXe);
                foreach (var CTHDCu in result)
                {
                    var kq = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == CTHDCu.SoHopDong && n.MaTrangThai == "0");
                    if (kq != null)
                        if (
                            (CTHDMoi.NgayDi > CTHDCu.NgayDi && CTHDMoi.NgayDi < CTHDCu.NgayVe) ||
                            (CTHDMoi.NgayVe > CTHDCu.NgayDi && CTHDMoi.NgayVe < CTHDCu.NgayVe) ||
                            (CTHDCu.NgayDi > CTHDMoi.NgayDi && CTHDCu.NgayDi < CTHDMoi.NgayVe) ||
                            (CTHDCu.NgayVe > CTHDMoi.NgayDi && CTHDCu.NgayVe < CTHDMoi.NgayVe)
                            )
                        {
                            CTHDCu.MaTaiXe = null;
                            break;
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

        public static Boolean CapNhatPhuXeBiTrung(String PhuXe, CT_HopDongViewModel CTHDMoi)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.CT_HopDongs.Where(n => n.PhuXe == PhuXe);
                foreach (var CTHDCu in result)
                {
                    var kq = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == CTHDCu.SoHopDong && n.MaTrangThai == "0");
                    if (kq != null)
                        if (
                            (CTHDMoi.NgayDi > CTHDCu.NgayDi && CTHDMoi.NgayDi < CTHDCu.NgayVe) ||
                            (CTHDMoi.NgayVe > CTHDCu.NgayDi && CTHDMoi.NgayVe < CTHDCu.NgayVe) ||
                            (CTHDCu.NgayDi > CTHDMoi.NgayDi && CTHDCu.NgayDi < CTHDMoi.NgayVe) ||
                            (CTHDCu.NgayVe > CTHDMoi.NgayDi && CTHDCu.NgayVe < CTHDMoi.NgayVe)
                            )
                        {
                            CTHDCu.PhuXe = null;
                            break;
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

        public static Boolean CapNhatNhanVienBoChon(String MaNV)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.NhanViens.SingleOrDefault(n => n.MaNV == MaNV);
                result.Status = "0";
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
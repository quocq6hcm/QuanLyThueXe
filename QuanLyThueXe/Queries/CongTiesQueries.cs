using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
namespace QuanLyThueXe.Queries
{
    public class CongTiesQueries
    {
        //tự tăng mã công ty
        public static String TuTangMaCT()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaCongTy = "";
                var MaCt = entity.CongTies.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaCt == null)
                {
                    MaCongTy = "CT1";
                }
                else
                {
                    MaCt.MaCongTy = MaCt.MaCongTy.Substring(2, MaCt.MaCongTy.Length - 2);
                    int iSo = int.Parse(MaCt.MaCongTy);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaCongTy = "CT" + sSo;
                }
                return MaCongTy;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //danh sách công ty
        public static List<CongTiesViewModel> LayDanhSachCongTy()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from c in entity.CongTies
                                where c.Dang == true
                                select new CongTiesViewModel()
                                {
                                    MaCongTy = c.MaCongTy,
                                    TenCongTy = c.TenCongTy,
                                    SDT = c.SDT,
                                    DiaChi = c.DiaChi,
                                    Email = c.Email,
                                    Fax = c.Fax,
                                    GhiChu = c.GhiChu,
                                    NguoiLienHe = c.NguoiLienHe,
                                    MaSoThue = c.MaSoThue,
                                    VAT = c.VAT,
                                    STT = c.STT,
                                }).OrderBy(n => n.STT).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //chi tiết công ty
        public static CongTiesViewModel LayThongTinChiTietCty(String MaCT)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (from ct in entity.CongTies
                              where ct.MaCongTy == MaCT
                              select new CongTiesViewModel()
                              {
                                  MaCongTy = ct.MaCongTy,
                                  TenCongTy = ct.TenCongTy,
                                  DiaChi = ct.DiaChi,
                                  SDT = ct.SDT,
                                  Fax = ct.Fax,
                                  Email = ct.Email,
                                  NguoiLienHe = ct.NguoiLienHe,
                                  GhiChu = ct.GhiChu,
                                  Dang = ct.Dang,
                                  VAT = ct.VAT,
                                  MaSoThue = ct.MaSoThue,
                                  STT = ct.STT,
                              }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //thêm công ty
        public static Boolean ThemCongTy(CongTiesViewModel CT)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var Ct = new CongTy();
                Ct.MaCongTy = TuTangMaCT();
                Ct.TenCongTy = CT.TenCongTy;
                Ct.Email = CT.Email;
                Ct.DiaChi = CT.DiaChi;
                Ct.SDT = CT.SDT;
                Ct.Fax = CT.Fax;
                Ct.NguoiLienHe = CT.NguoiLienHe;
                Ct.GhiChu = CT.GhiChu;
                Ct.Dang = true;
                entity.CongTies.Add(Ct);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        //chỉnh sửa thông tin công ty
        public static Boolean Chinhsua_CongTy(CongTiesViewModel Congty)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var ct = entity.CongTies.SingleOrDefault(n => n.MaCongTy == Congty.MaCongTy);
                ct.TenCongTy = Congty.TenCongTy;
                ct.Email = Congty.Email;
                ct.DiaChi = Congty.DiaChi;
                ct.SDT = Congty.SDT;
                ct.Fax = Congty.Fax;
                ct.NguoiLienHe = Congty.NguoiLienHe;
                ct.GhiChu = Congty.GhiChu;
                ct.Dang = true;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        /// <summary>
        /// Xóa công ty
        /// </summary>
        /// <param name="MaCongTy"></param>
        /// <returns></returns>
        public static Boolean XoaCty(String MaCongTy)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var CT = entity.CongTies.SingleOrDefault(n => n.MaCongTy == MaCongTy);
                CT.Dang = false;
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
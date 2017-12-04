using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class LoaiNhanVienQueries
    {
        //tự tăng mã loại nhân viên
        public static String TuTangMaLNV()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaLoaiNV = "";
                var MaLnv = entity.LoaiNhanViens.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaLnv == null)
                {
                    MaLoaiNV = "LNV1";
                }
                else
                {
                    MaLnv.MaLoaiNV = MaLnv.MaLoaiNV.Substring(3, MaLnv.MaLoaiNV.Length -3);
                    int iSo = int.Parse(MaLnv.MaLoaiNV);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaLoaiNV = "LNV" + sSo;
                }
                return MaLoaiNV;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        public static List<LoaiNhanVienViewModel> DanhSachLoaiNhanVien()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from Loainv in entity.LoaiNhanViens
                                select new LoaiNhanVienViewModel()
                                {
                                    MaLoaiNV = Loainv.MaLoaiNV,
                                    TenLoaiNV = Loainv.TenLoaiNV,
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //thông tin chi tiết 1 loại nhân viên
        public static LoaiNhanVienViewModel ChiTiet_LoaiNV(String MaLoaiNV)
        {
            var entity = new QuanLyThueXeEntities();
            try 
            {
                var result = (
                                from loainv in entity.LoaiNhanViens
                                where loainv.MaLoaiNV == MaLoaiNV
                                select new LoaiNhanVienViewModel()
                                {
                                    MaLoaiNV = loainv.MaLoaiNV,
                                    TenLoaiNV = loainv.TenLoaiNV,
                                    Dang = loainv.Dang,
                                    MaLuong = loainv.MaLuong
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //cập nhật loại nhân viên
        public static Boolean ChinhSuaLoaiNV(LoaiNhanVienViewModel loainv)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var loaiNV = entity.LoaiNhanViens.SingleOrDefault(n => n.MaLoaiNV == loainv.MaLoaiNV);
                loaiNV.TenLoaiNV = loainv.TenLoaiNV;
                loaiNV.Dang = loainv.Dang;
                loaiNV.MaLuong = loainv.MaLuong;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        //thêm loại nhân viên
        public static Boolean ThemLoaiNV(LoaiNhanVienViewModel loainv)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var lnv = new LoaiNhanVien();
                lnv.MaLoaiNV = TuTangMaLNV();
                lnv.TenLoaiNV = loainv.TenLoaiNV;
                lnv.Dang = true;
                lnv.MaLuong = loainv.MaLuong;
                entity.LoaiNhanViens.Add(lnv);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
namespace QuanLyThueXe.Queries
{
    public class LoaiKhachHangQueries
    {
        //tự tăng mã loại khách hàng
        public static String TuTangMaLKH()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaLoaiKH = "";
                var MaLkh = entity.LoaiKhachHangs.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaLkh == null)
                {
                    MaLoaiKH = "LKH1";
                }
                else
                {
                    MaLkh.MaLoaiKH = MaLkh.MaLoaiKH.Substring(3, MaLkh.MaLoaiKH.Length - 3);
                    int iSo = int.Parse(MaLkh.MaLoaiKH);
                    iSo++;
                    MaLoaiKH = "LKH" + iSo;
                }
                return MaLoaiKH;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //danh sách loại khách hàng
        public static List<LoaiKhachHangViewModel> LayDanhSachLoaiKhachHang()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from l in entity.LoaiKhachHangs
                                select new LoaiKhachHangViewModel()
                                {
                                    MaLoaiKH = l.MaLoaiKH,
                                    TenLoaiKH = l.TenLoaiKH
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //thông tin chi tiết loại khách hàng
        public static LoaiKhachHangViewModel ChiTiet_LoaiKH(String MaLoaiKH)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from loaikh in entity.LoaiKhachHangs
                                where loaikh.MaLoaiKH == MaLoaiKH
                                select new LoaiKhachHangViewModel()
                                {
                                    MaLoaiKH = loaikh.MaLoaiKH,
                                    TenLoaiKH = loaikh.TenLoaiKH,
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //cập nhật loại khách hàng
        public static Boolean ChinhSuaLoaiKH(LoaiKhachHangViewModel loaikh)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var loaiKH = entity.LoaiKhachHangs.SingleOrDefault(n => n.MaLoaiKH == loaikh.MaLoaiKH);
                loaiKH.TenLoaiKH = loaikh.TenLoaiKH;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        //thêm mới loại khách hàng
        public static Boolean ThemLoaiKH(LoaiKhachHangViewModel loaikh)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var lkh = new LoaiKhachHang();
                lkh.MaLoaiKH = TuTangMaLKH();
                lkh.TenLoaiKH = loaikh.TenLoaiKH;
                entity.LoaiKhachHangs.Add(lkh);
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
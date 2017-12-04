using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class ThuongHieuQueries
    {
        //tự tăng mã thương hiệu xe
        public static String TuTangMaTHX()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaThuongHieu = "";
                var MaThx = entity.ThuongHieuXes.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaThx == null)
                {
                    MaThuongHieu = "THX1";
                }
                else
                {
                    MaThx.MaThuongHieu = MaThx.MaThuongHieu.Substring(3, MaThx.MaThuongHieu.Length - 3);
                    int iSo = int.Parse(MaThx.MaThuongHieu);
                    iSo++;
                    MaThuongHieu = "THX" + iSo;
                }
                return MaThuongHieu;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //lấy danh sách thương hiệu
        public static List<ThuongHieuViewModel> LayDanhSachThuongHieu()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from th in entity.ThuongHieuXes
                                select new ThuongHieuViewModel()
                                {
                                    MaThuongHieu = th.MaThuongHieu,
                                    TenThuongHieu = th.TenThuongHieu
                                }).OrderByDescending(n=>n.MaThuongHieu).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //thông tin chi tiết thương hiệu xe
        public static ThuongHieuViewModel ChiTiet_TH(String MaThuongHieu)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from th in entity.ThuongHieuXes
                                where th.MaThuongHieu == MaThuongHieu
                                select new ThuongHieuViewModel()
                                {
                                    MaThuongHieu = th.MaThuongHieu,
                                    TenThuongHieu = th.TenThuongHieu,
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        // chỉnh sửa thương hiệu xe
        public static Boolean ChinhSuaTH(ThuongHieuViewModel th)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var Th = entity.ThuongHieuXes.SingleOrDefault(n => n.MaThuongHieu == th.MaThuongHieu);
                Th.TenThuongHieu = th.TenThuongHieu;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        //thêm mới thương hiệu
        public static Boolean ThemTH(ThuongHieuViewModel th)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var TH = new ThuongHieuXe();
                TH.MaThuongHieu = TuTangMaTHX();
                TH.TenThuongHieu = th.TenThuongHieu;
                entity.ThuongHieuXes.Add(TH);
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
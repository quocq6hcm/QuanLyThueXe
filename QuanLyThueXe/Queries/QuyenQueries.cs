using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
namespace QuanLyThueXe.Queries
{
    public class QuyenQueries
    {

        public static Boolean ThemQuyen(QuyenViewModel quyen)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var q = new Quyen();
                q.MaQuyen = quyen.MaQuyen;
                q.TenQuyen = quyen.TenQuyen;
                entity.Quyens.Add(q);
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
        /// Lay Danh sach quyen
        /// </summary>
        /// <returns></returns>
        public static List<QuyenViewModel> LayDanhSachQuyen()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from q in entity.Quyens
                                select new QuyenViewModel
                                {
                                    MaQuyen = q.MaQuyen,
                                    TenQuyen = q.TenQuyen
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null; 
            }
        }
        /// <summary>
        /// Lay thong tin chi tiet  quyen
        /// </summary>
        /// <param name="MaQuyen"></param>
        /// <returns></returns>
        public static QuyenViewModel LayThongTinChiTiet(string MaQuyen)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from q in entity.Quyens
                                where q.MaQuyen == MaQuyen
                                select new QuyenViewModel()
                                {
                                    MaQuyen = q.MaQuyen,
                                    TenQuyen = q.TenQuyen
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        public static Boolean ChinhSuaQuyen(QuyenViewModel quyen)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.Quyens.SingleOrDefault(n => n.MaQuyen == quyen.MaQuyen);
                result.TenQuyen = quyen.TenQuyen;
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
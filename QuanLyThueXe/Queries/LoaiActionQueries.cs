using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
namespace QuanLyThueXe.Queries
{
    public class LoaiActionQueries
    {
        public static List<LoaiActionViewModel> LayDanhSachTinhNang()
        {
            // Danh sach action
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from a in entity.LoaiActions
                                where a.TenAction.Contains("Menu")
                                select new LoaiActionViewModel()
                                {
                                    MaAction = a.MaAction,
                                    TenAction = a.TenAction,
                                    MoTa = a.Mota,
                                    MaController = a.MaController,
                                    UrlAction = a.UrlAction
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        //thong tin 1 action
        public static LoaiActionViewModel ThongTinChiTiet(int MaAction)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from a in entity.LoaiActions
                                where a.MaAction == MaAction
                                select new LoaiActionViewModel()
                                {
                                    MaAction = a.MaAction,
                                    TenAction = a.TenAction,
                                    MoTa = a.Mota,
                                    MaController = a.MaController,
                                    UrlAction = a.UrlAction
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        //cap nhat chinh sua 1 action
        public static Boolean ChinhSuaTinhNang(LoaiActionViewModel action)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.LoaiActions.SingleOrDefault(n => n.MaAction == action.MaAction);
                result.Mota = action.MoTa;
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
        /// Lấy action theo ma quyền
        /// </summary>
        public static List<LoaiActionViewModel> LayDanhSachActionTheoQuyen(string MaQuyen)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from action in entity.LoaiActions
                                join pq in entity.PhanQuyens on action.MaAction equals pq.MaAction
                                where pq.MaQuyen == MaQuyen
                                select new LoaiActionViewModel()
                                {
                                    MaAction = action.MaAction,
                                    MaController = action.MaController,
                                    MoTa = action.Mota,
                                    TenAction = action.TenAction,
                                    UrlAction = action.UrlAction
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
                entity.Dispose();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
namespace QuanLyThueXe.Queries
{
    public class PhanQuyenQueries
    {
        public static List<PhanQuyenViewModel> LayDanhSachPhanQuyen(String MaQuyen)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from pq in entity.PhanQuyens
                                where pq.MaQuyen == MaQuyen
                                select new PhanQuyenViewModel()
                                {
                                    MaQuyen = pq.MaQuyen,
                                    MaAction = pq.MaAction
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        public static Boolean CapNhatLaiQuyen(String MaQuyen, String strMaAction)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var lstQuyen = entity.PhanQuyens.Where(n => n.MaQuyen == MaQuyen);
                foreach (var q in lstQuyen)
                {
                    entity.PhanQuyens.Remove(q);
                }
                entity.SaveChanges();
                if (!string.IsNullOrEmpty(strMaAction))
                {
                    var arrMaAction = strMaAction.Split('#');
                    foreach (var action in arrMaAction)
                    {
                        var phanQuyen = new PhanQuyen();
                        phanQuyen.MaQuyen = MaQuyen;
                        phanQuyen.MaAction = int.Parse(action);
                        entity.PhanQuyens.Add(phanQuyen);
                    }
                    entity.SaveChanges();
                }
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
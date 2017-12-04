using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class Tinh_TPQueries
    {
        public static List<Tinh_TPViewModel> LayDanhSachTinh_TP()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from Tinh in entity.Tinh_TPs
                                select new Tinh_TPViewModel()
                                {
                                    MaTinh = Tinh.MaTinh,
                                    TenTinh = Tinh.TenTinh
                                }).OrderBy(n =>n.MaTinh).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }

        }
    }
}
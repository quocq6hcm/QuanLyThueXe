using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class ChiTietChiPhiPhatSinhQueries
    {

        #region lấy danh sách chi phí phát sinh theo số hợp đồng
        public static List<ChiTietChiPhiPhatSinhViewModel> DanhSachCPPSTheoSoHopDong(string SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                               from ct in entity.ChiTietChiPhiPhatSinhs
                               where ct.SoHopDong == SoHopDong
                               select new ChiTietChiPhiPhatSinhViewModel()
                               {
                                   SoHopDong = ct.SoHopDong,
                                   DonGia = ct.DonGia,
                                   MaChiPhi = ct.MaChiPhi,
                                   SoLuong = ct.SoLuong,
                               }).OrderBy(n => n.MaChiPhi).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Group by danh sách chi phí phát sinh theo số hợp đồng
        public static List<ChiTietChiPhiPhatSinhViewModel> LayDanhSachCTCPPhatSinhTheoSoHopDong(string SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                List<ChiTietChiPhiPhatSinhViewModel> chiTiet = DanhSachCPPSTheoSoHopDong(SoHopDong);
                var result = chiTiet
                    .GroupBy(n => n.MaChiPhi)
                    .Select(sl => new ChiTietChiPhiPhatSinhViewModel
                    {
                        SoHopDong = sl.First().SoHopDong,
                        DonGia = sl.First().DonGia,
                        MaChiPhi = sl.First().MaChiPhi,
                        SoLuong = sl.Sum(n => n.SoLuong),
                        //    ChiPhiPhatSinhs = (
                        //                        from cp in entity.ChiPhiPhatSinhs
                        //                        where cp.MaChiPhi == sl.First().MaChiPhi
                        //                        select new ChiPhiPhatSinhViewModel()
                        //                        {
                        //                            MaChiPhi = cp.MaChiPhi,
                        //                            PhiPhatSinh = cp.PhiPhatSinh,
                        //                            TenChiPhi = cp.TenChiPhi,
                        //                            MoTa = cp.Mota,
                        //                        }).FirstOrDefault(),
                    }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion
    }
}
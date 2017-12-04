using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Queries
{
    public class LoaiBangQueries
    {
        //tự tăng mã loại bằng
        public static String TuTangMaBang()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaBang = "";
                var MaB = entity.LoaiBangs.OrderByDescending(n => n.MaBang).FirstOrDefault();
                if (MaB == null)
                {
                    MaBang = "LB1";
                }
                else
                {
                    MaB.MaBang = MaB.MaBang.Substring(2, MaB.MaBang.Length - 2);
                    int iSo = int.Parse(MaB.MaBang);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaBang = "LB" + sSo;
                }
                return MaBang;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //lấy danh sách bằng
        public static List<LoaiBangViewModel> LayDanhSachLoaiBang()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from BL in entity.LoaiBangs
                                select new LoaiBangViewModel
                                {
                                    MaBang = BL.MaBang,
                                    TenBang = BL.TenBang,
                                    MoTa = BL.MoTa
                                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //thông tin chi tiết bằng
        public static LoaiBangViewModel ChiTiet_LoaiBang(String MaBang)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from lb in entity.LoaiBangs
                                where lb.MaBang == MaBang
                                select new LoaiBangViewModel()
                                {
                                    MaBang = lb.MaBang,
                                    TenBang = lb.TenBang,
                                    MoTa = lb.MoTa,
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //cập nhật loại bằng
        public static Boolean ChinhSuaBang(LoaiBangViewModel lb)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var lB = entity.LoaiBangs.SingleOrDefault(n => n.MaBang == lb.MaBang);
                lB.TenBang = lb.TenBang;
                lB.MoTa = lb.MoTa;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }

        //thêm mới loại bằng mới
        public static Boolean ThemBang(LoaiBangViewModel lb)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var LB = new LoaiBang();
                LB.MaBang = TuTangMaBang();
                LB.TenBang = lb.TenBang;
                LB.MoTa = lb.MoTa;
                entity.LoaiBangs.Add(LB);
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
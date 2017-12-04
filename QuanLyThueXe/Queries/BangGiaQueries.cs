using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Helpers;
using System.Text.RegularExpressions;

namespace QuanLyThueXe.Queries
{
    public class BangGiaQueries
    {
        #region tự động tăng mã bảng giá
        /// <summary>
        /// Tự động tăng mã bảng giá
        /// </summary>
        /// <returns></returns>
        public static String TuTangMaBG()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String MaBangGia = "";
                var MaBg = entity.BangGias.OrderByDescending(n => n.STT).FirstOrDefault();
                if (MaBg == null)
                {
                    MaBangGia = "BG1";
                }
                else
                {
                    MaBg.MaBangGia = MaBg.MaBangGia.Substring(2, MaBg.MaBangGia.Length - 2);
                    int iSo = int.Parse(MaBg.MaBangGia);
                    iSo++;
                    string sSo = iSo.ToString();
                    MaBangGia = "BG" + sSo;
                }
                return MaBangGia;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Tính giá ước tính
        /// <summary>
        /// Tính giá ước tính
        /// </summary>
        /// <param name="MaLoaiXe"></param>
        /// <param name="MaLoTrinh"></param>
        /// <returns></returns>
        public static BangGia TinhGiaUocTinh(String MaLoaiXe, String MaLoTrinh)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = entity.BangGias.SingleOrDefault(n => n.MaLoTrinh == MaLoTrinh && n.MaLoaiXe == MaLoaiXe);
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Tính bảng giá của tuyến đường mới
        public static TuyenDuongMoiViewModel TinhBangGiaTuyenDuongMoi(TuyenDuongMoiViewModel tuyenDuongMoi)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                //lue danh sach loại xe vào lstMaLoaiXe
                var lstGiaXeMoi = tuyenDuongMoi.strGiaXeMoi.Split(',');

                //Luu mang so luong vao lstSoLuong
                var lstSoLuong = tuyenDuongMoi.StrSoLuongXeMoi.Split(',');
                int[] arrSoluong = new int[10];
                int i = 0;
                foreach (var sl in lstSoLuong)
                {
                    arrSoluong[i] = int.Parse(sl);
                    i++;
                }

                int j = 0;

                //Tong gia thue xe
                decimal? tongTien = 0;
                decimal? chiPhi = 0;
                decimal? giaNiemYet = 0;

                foreach (var gx in lstGiaXeMoi)
                {
                    var gia = decimal.Parse(gx.Replace(".", ""));
                    tongTien = tongTien + gia * arrSoluong[j];
                    giaNiemYet = giaNiemYet + gia * arrSoluong[j];
                    j++;
                }

                if (!string.IsNullOrEmpty(tuyenDuongMoi.strMaChiPhiMoi))
                {
                    //lue danh sach loại xe vào lstMaLoaiXe
                    var lstMaCP = tuyenDuongMoi.strMaChiPhiMoi.Split(',');

                    //Luu mang so luong vao lstSoLuong
                    if (string.IsNullOrEmpty(tuyenDuongMoi.strSoLuongCPMoi))
                    {
                        tuyenDuongMoi.strSoLuongCPMoi = ",";
                    }
                    var lstSoLuongCP = tuyenDuongMoi.strSoLuongCPMoi.Split(',');
                    decimal[] arrSoluongCP = new decimal[10];
                    int iCP = 0;
                    foreach (var sl in lstSoLuongCP)
                    {
                        if (!string.IsNullOrEmpty(sl))
                        {
                            arrSoluongCP[iCP] = decimal.Parse(sl.ToString().Replace(".", ""));
                        }
                        iCP++;
                    }

                    int jCP = 0;

                    foreach (var mcp in lstMaCP)
                    {
                        //if (string.IsNullOrEmpty(arrSoluongCP[jCP].ToString()) || arrSoluongCP[jCP] == 0)
                        //{
                        //    ChiPhiPhatSinh cp = entity.ChiPhiPhatSinhs.SingleOrDefault(n => n.MaChiPhi == mcp);
                        //    chiPhi = chiPhi + decimal.Parse(arrSoluongCP[jCP].ToString().Replace(".", ""));
                        //}
                        //else
                        //{
                            chiPhi = chiPhi + arrSoluongCP[jCP];
                        //}
                        jCP++;
                        //decimal.Parse(arrSoluongCP[jCP].ToString().Replace(".", ""))
                    }
                }
                var result = new TuyenDuongMoiViewModel()
                {
                    GiaNiemYetMoi = giaNiemYet,
                    TongTienMoi = tongTien - decimal.Parse(tuyenDuongMoi.GiamGiaMoi.ToString().Replace(".", "")) + chiPhi,
                };
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Chi tiết bảng giá hiển thị thông tin bảng giá
        /// <summary>
        /// Chi tiết bảng giá
        /// </summary>
        /// <param name="maLoTrinh"></param>
        /// <param name="maLoaiXe"></param>
        /// <param name="soluong"></param>
        /// <param name="maKhachHang"></param>
        /// <param name="giamGia"></param>
        /// <returns></returns>
        public static BangGiaViewModel chiTietBangGia(string maLoTrinh, string maLoaiXe, string soluong, string maKhachHang, string giamGia, string strMaChiPhi, string strSoLuongCP, string iNgayLech)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                //lue danh sach loại xe vào lstMaLoaiXe
                var lstMaLoaiXe = maLoaiXe.Split(',');

                //Luu mang so luong vao lstSoLuong
                var lstSoLuong = soluong.Split(',');
                int[] arrSoluong = new int[10];
                int i = 0;
                foreach (var sl in lstSoLuong)
                {
                    arrSoluong[i] = int.Parse(sl);
                    i++;
                }

                int j = 0;

                //Tong gia thue xe
                decimal? tongTien = 0;
                decimal? sokm = 0;
                decimal? giamgia = decimal.Parse(giamGia.Replace(".", ""));
                decimal? chiPhi = 0;
                string tg = "";

                /*int ngay = Int16.Parse(iNgayLech);*/ // số ngày giữa ngày đi và ngày về
                foreach (var mlx in lstMaLoaiXe)
                {
                    BangGia bg = entity.BangGias.SingleOrDefault(n => n.MaLoaiXe == mlx && n.MaLoTrinh == maLoTrinh && n.MaKH == maKhachHang);
                    tongTien = tongTien + bg.Gia * arrSoluong[j];
                    tg = bg.ThoiGian;
                    sokm = bg.SoKM;
                    j++;
                }

                if (!String.IsNullOrEmpty(strMaChiPhi))
                {
                    //lue danh sach loại xe vào lstMaLoaiXe
                    var lstMaCP = strMaChiPhi.Split(',');

                    //Luu mang so luong vao lstSoLuong
                    var lstSoLuongCP = strSoLuongCP.Split(',');
                    decimal[] arrSoluongCP = new decimal[10];
                    int iCP = 0;
                    foreach (var sl in lstSoLuongCP)
                    {
                        if (!string.IsNullOrEmpty(sl))
                        {
                            arrSoluongCP[iCP] = decimal.Parse(sl.ToString().Replace(".", ""));
                        }
                        iCP++;
                    }

                    int jCP = 0;

                    foreach (var mcp in lstMaCP)
                    {
                        //if (string.IsNullOrEmpty(arrSoluongCP[jCP].ToString()) || arrSoluongCP[jCP] == 0)
                        //{
                        //    ChiPhiPhatSinh cp = entity.ChiPhiPhatSinhs.SingleOrDefault(n => n.MaChiPhi == mcp);
                        //    chiPhi = chiPhi + decimal.Parse(cp.PhiPhatSinh.ToString().Replace(".", ""));
                        //}
                        //else
                        //{
                        chiPhi = chiPhi + arrSoluongCP[jCP];
                        //}
                        jCP++;
                    }
                }
                var result = (
                            from bg in entity.BangGias
                            where bg.MaLoTrinh == maLoTrinh
                            select new BangGiaViewModel()
                            {
                                Gia = tongTien - giamgia + chiPhi,
                                SoKM = sokm,
                                ThoiGian = tg
                            }).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Chi tiết bảng giá hiển thị thông tin bảng giá niêm yết
        /// <summary>
        /// Chi tiết bảng giá
        /// </summary>
        /// <param name="maLoTrinh"></param>
        /// <param name="maLoaiXe"></param>
        /// <param name="soluong"></param>
        /// <param name="maKhachHang"></param>
        /// <param name="giamGia"></param>
        /// <returns></returns>
        public static BangGiaViewModel chiTietBangGiaNiemYet(String maLoTrinh, String maLoaiXe, String soluong, String maKhachHang)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                //lue danh sach loại xe vào lstMaLoaiXe
                var lstMaLoaiXe = maLoaiXe.Split(',');

                //Luu mang so luong vao lstSoLuong
                var lstSoLuong = soluong.Split(',');
                int[] arrSoluong = new int[10];
                int i = 0;
                foreach (var sl in lstSoLuong)
                {
                    arrSoluong[i] = int.Parse(sl);
                    i++;
                }

                int j = 0;

                //Tong gia thue xe
                decimal? tongTien = 0;
                decimal? sokm = 0;
                string tg = "";

                foreach (var mlx in lstMaLoaiXe)
                {
                    BangGia bg = entity.BangGias.SingleOrDefault(n => n.MaLoaiXe == mlx && n.MaLoTrinh == maLoTrinh && n.MaKH == maKhachHang);
                    tongTien = tongTien + bg.Gia * arrSoluong[j];
                    tg = bg.ThoiGian;
                    sokm = bg.SoKM;
                    j++;
                }
                var result = (
                                from bg in entity.BangGias
                                where bg.MaLoTrinh == maLoTrinh
                                select new BangGiaViewModel()
                                {
                                    Gia = tongTien,
                                    SoKM = sokm,
                                    ThoiGian = tg
                                }).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Lấy danh sách bảng giá
        /// <summary>
        /// lấy danh sách bảng giá
        /// </summary>
        /// <returns></returns>
        public static List<BangGiaViewModel> LayDanhSachBangGia()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from bg in entity.BangGias
                                where bg.Dang == true
                                select new BangGiaViewModel()
                                {
                                    MaBangGia = bg.MaBangGia,
                                    MaLoaiXe = bg.MaLoaiXe,
                                    MaKH = bg.MaKH,
                                    MaLoTrinh = bg.MaLoTrinh,
                                    Gia = bg.Gia,
                                    ThoiGian = bg.ThoiGian,
                                    SoKM = bg.SoKM,
                                    STT = bg.STT,
                                    Dang = bg.Dang,
                                    LoaiXes = (
                                                    from Lx in entity.LoaiXes
                                                    where Lx.MaLoaiXe == bg.MaLoaiXe
                                                    select new LoaiXeViewModel()
                                                    {
                                                        MaLoaiXe = Lx.MaLoaiXe,
                                                        TenLoaiXe = Lx.TenLoaiXe,
                                                        STT = Lx.STT
                                                    }).FirstOrDefault(),
                                    KhachHangs = (
                                                    from kh in entity.KhachHangs
                                                    where kh.MaKH == bg.MaKH
                                                    select new KhachHangViewModel()
                                                    {
                                                        MaKH = kh.MaKH,
                                                        TenKH = kh.TenKH
                                                    }).FirstOrDefault(),
                                    LoTrinhs = (
                                                    from lt in entity.LoTrinhs
                                                    where lt.MaLoTrinh == bg.MaLoTrinh
                                                    select new LoTrinhViewModel()
                                                    {
                                                        MaLoTrinh = lt.MaLoTrinh,
                                                        TenLoTrinh = lt.TenLoTrinh
                                                    }).FirstOrDefault(),
                                }).OrderByDescending(n => n.MaBangGia).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Chi tiết thông tin mỗi bảng giá    
        /// <summary>
        /// Chi tiet gia
        /// </summary>
        /// <param name=""></param>
        /// <returns>BangGiaViewModel</returns>
        //chi tiết nhân viên
        public static BangGiaViewModel LayChiTietGia(string MaBangGia)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from bg in entity.BangGias
                                where bg.MaBangGia == MaBangGia
                                select new BangGiaViewModel()
                                {
                                    MaBangGia = bg.MaBangGia,
                                    MaLoaiXe = bg.MaLoaiXe,
                                    MaKH = bg.MaKH,
                                    MaLoTrinh = bg.MaLoTrinh,
                                    Gia = bg.Gia,
                                    ThoiGian = bg.ThoiGian,
                                    SoKM = bg.SoKM,
                                    STT = bg.STT,
                                    LoaiXes = (
                                                        from Lx in entity.LoaiXes
                                                        where bg.MaLoaiXe == Lx.MaLoaiXe
                                                        select new LoaiXeViewModel()
                                                        {
                                                            MaLoaiXe = Lx.MaLoaiXe,
                                                            TenLoaiXe = Lx.TenLoaiXe
                                                        }).FirstOrDefault(),
                                    KhachHangs = (
                                                    from kh in entity.KhachHangs
                                                    where kh.MaKH == bg.MaKH
                                                    select new KhachHangViewModel()
                                                    {
                                                        TenKH = kh.TenKH
                                                    }).FirstOrDefault(),
                                    LoTrinhs = (
                                                    from Lt in entity.LoTrinhs
                                                    where Lt.MaLoTrinh == bg.MaLoTrinh
                                                    select new LoTrinhViewModel()
                                                    {
                                                        TenLoTrinh = Lt.TenLoTrinh
                                                    }).FirstOrDefault()
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region chỉnh sửa bảng giá
        /// <summary>
        /// chỉnh sửa bảng giá
        /// </summary>
        /// <param name="bg"></param>
        /// <returns></returns>
        public static Boolean ChinhsuaGia(BangGiaViewModel bg)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var BG = entity.BangGias.SingleOrDefault(n => n.MaBangGia == bg.MaBangGia);
                BG.MaLoaiXe = bg.MaLoaiXe;
                BG.MaKH = bg.MaKH;
                BG.MaLoTrinh = bg.MaLoTrinh;
                BG.Gia = bg.Gia;
                BG.ThoiGian = bg.ThoiGian;
                BG.SoKM = bg.SoKM;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        #endregion

        #region Thêm bảng giá
        /// <summary>
        /// Thêm bảng giá
        /// </summary>
        /// <param BangGiaViewModel="MaBangGia"></param>
        /// <returns>Boolean</returns>
        public static Boolean ThemBangGia(BangGiaViewModel BG)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var bg = new BangGia();
                bg.MaBangGia = TuTangMaBG();
                bg.MaLoaiXe = BG.MaLoaiXe;
                bg.MaKH = BG.MaKH;
                bg.MaLoTrinh = BG.MaLoTrinh;
                bg.ThoiGian = BG.ThoiGian;
                bg.SoKM = BG.SoKM;
                bg.Gia = BG.Gia;
                bg.Dang = true;
                entity.BangGias.Add(bg);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        #endregion

        #region Lấy danh sách loại xe theo mã khách hàng và mã lộ trình
        public static List<BangGiaViewModel> LayDanhSachLoaiXeMaKHVaMaLT(String MaKH, String MaLoTrinh)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from bg in entity.BangGias
                                where MaKH == bg.MaKH && MaLoTrinh == bg.MaLoTrinh && bg.Dang == true
                                select new BangGiaViewModel()
                                {
                                    LoaiXes = (
                                                    from lx in entity.LoaiXes
                                                    where lx.MaLoaiXe == bg.MaLoaiXe
                                                    select new LoaiXeViewModel()
                                                    {
                                                        MaLoaiXe = lx.MaLoaiXe,
                                                        TenLoaiXe = lx.TenLoaiXe,
                                                        STT = lx.STT,
                                                        Dang = lx.Dang
                                                    }
                                                ).FirstOrDefault()
                                }).OrderBy(n => n.LoaiXes.MaLoaiXe).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Kiểm tra tồn tại bảng giá
        public static Boolean Kiemtra(BangGiaViewModel bg)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                BangGia check = entity.BangGias.SingleOrDefault(n => n.MaKH == bg.MaKH && n.MaLoaiXe == bg.MaLoaiXe && n.MaLoTrinh == bg.MaLoTrinh && n.Gia == bg.Gia && n.ThoiGian == bg.ThoiGian);
                if (check != null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        #endregion

        #region lấy danh sách bảng giá theo mã khách hàng
        public static List<BangGiaViewModel> LayDanhSachBangGiaTheoMaKhachHang(string maKhangHang)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from bg in entity.BangGias
                                where bg.MaKH == maKhangHang && bg.Dang == true
                                select new BangGiaViewModel()
                                {
                                    MaBangGia = bg.MaBangGia,
                                    MaLoaiXe = bg.MaLoaiXe,
                                    MaKH = bg.MaKH,
                                    MaLoTrinh = bg.MaLoTrinh,
                                    Gia = bg.Gia,
                                    ThoiGian = bg.ThoiGian,
                                    SoKM = bg.SoKM,
                                    STT = bg.STT,
                                    Dang = bg.Dang,
                                    LoaiXes = (
                                                    from Lx in entity.LoaiXes
                                                    where Lx.MaLoaiXe == bg.MaLoaiXe
                                                    select new LoaiXeViewModel()
                                                    {
                                                        MaLoaiXe = Lx.MaLoaiXe,
                                                        TenLoaiXe = Lx.TenLoaiXe,
                                                        STT = Lx.STT,
                                                    }).FirstOrDefault(),
                                    KhachHangs = (
                                                    from kh in entity.KhachHangs
                                                    where kh.MaKH == bg.MaKH
                                                    select new KhachHangViewModel()
                                                    {
                                                        MaKH = kh.MaKH,
                                                        TenKH = kh.TenKH
                                                    }).FirstOrDefault(),
                                    LoTrinhs = (
                                                    from lt in entity.LoTrinhs
                                                    where lt.MaLoTrinh == bg.MaLoTrinh
                                                    select new LoTrinhViewModel()
                                                    {
                                                        MaLoTrinh = lt.MaLoTrinh,
                                                        TenLoTrinh = lt.TenLoTrinh
                                                    }).FirstOrDefault(),
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

        #region Lấy danh sách lộ trình theo mã khách hàng trong bảng giá
        /// <summary>
        /// Lấy danh sách lộ trình theo mã khách hàng
        /// </summary>
        /// <param name="MaKH"></param>
        /// <returns></returns>
        public static List<BangGiaViewModel> LayDanhSachLoTrinhTheoMaKhachHangTrongBangGia(String MaKH)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from bg in entity.BangGias
                                where MaKH == bg.MaKH && bg.Dang == true
                                group bg by new
                                {
                                    bg.MaLoTrinh,
                                    bg.ThoiGian
                                } into g
                                select new BangGiaViewModel()
                                {
                                    MaKH = g.FirstOrDefault().MaKH,
                                    ThoiGian = g.FirstOrDefault().ThoiGian,
                                    Gia = g.FirstOrDefault().Gia,
                                    MaLoTrinh = g.FirstOrDefault().MaLoTrinh,
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where g.FirstOrDefault().MaLoTrinh == lt.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    MaLoTrinh = lt.MaLoTrinh,
                                                    TenLoTrinh = lt.TenLoTrinh,
                                                    MaKH = lt.MaKH,
                                                }).FirstOrDefault(),
                                }).OrderBy(n => n.LoTrinhs.TenLoTrinh).ToList();
                //var group = result.GroupBy(n => n.MaLoTrinh).Select(bg => new BangGiaViewModel()
                //{
                //    MaKH = bg.First().MaKH,
                //    ThoiGian = bg.First().ThoiGian,
                //    Gia = bg.First().Gia,
                //    MaLoTrinh = bg.First().MaLoTrinh,
                //    LoTrinhs = (
                //                 from lt in entity.LoTrinhs
                //                 where bg.First().MaLoTrinh == lt.MaLoTrinh
                //                 select new LoTrinhViewModel()
                //                 {
                //                     MaLoTrinh = lt.MaLoTrinh,
                //                     TenLoTrinh = lt.TenLoTrinh,
                //                     MaKH = lt.MaKH,
                //                 }).FirstOrDefault(),
                //}).ToList();
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
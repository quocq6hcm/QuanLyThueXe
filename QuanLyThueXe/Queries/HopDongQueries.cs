using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
using System.Diagnostics;

namespace QuanLyThueXe.Queries
{
    public class HopDongQueries
    {
        #region Tự động tăng mã hợp đồng
        /// <summary>
        /// Tự động tăng mã hợp đồng
        /// </summary>
        /// <returns></returns>
        public static String TuDongTangSoHD()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                String SoHopDong = "";
                var soHD = entity.HopDongs.OrderByDescending(n => n.STT).FirstOrDefault();
                if (soHD == null || !(soHD.SoHopDong.Contains(DateTime.Now.ToString("yyyy"))))
                {
                    SoHopDong = "1/" + DateTime.Now.ToString("yyyy") + "/HD-DETRA";
                }
                else
                {
                    soHD.SoHopDong = soHD.SoHopDong.Substring(0, soHD.SoHopDong.Length - 14);
                    int iSo = int.Parse(soHD.SoHopDong);
                    iSo++;
                    string sSo = iSo.ToString();
                    SoHopDong = sSo + "/" + DateTime.Now.ToString("yyyy") + "/HD-DETRA";
                }
                return SoHopDong;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Thêm hợp đồng
        /// <summary>
        /// Tạo hợp đồng
        /// </summary>
        /// <param name="HD"></param>
        /// <param name="CTHD"></param>
        /// <param name="KH"></param>
        /// <param name="lstLoaiXe"></param>
        /// <returns>Boolean</returns>
        public static Boolean ThemHopDong(HopDongViewModel HD, CT_HopDongViewModel CTHD, KhachHangViewModel KH, String lstLoaiXe, String strSoLuong, String strMaChiPhi, String strSoLuongCP, string iNgayLech)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                // Them moi hop dong
                var hopDong = new HopDong();
                if (KH.MaKH == "Detra")
                {
                    KhachHangQueries.ThemKhachHang(KH);
                    var kh = entity.KhachHangs.OrderByDescending(n => n.STT).Take(1).SingleOrDefault();
                    hopDong.MaKH = kh.MaKH;
                }
                else if (!String.IsNullOrEmpty(KH.MaKH))
                {
                    hopDong.MaKH = KH.MaKH;
                    var kh = entity.KhachHangs.SingleOrDefault(n => n.MaKH == KH.MaKH);
                }
                hopDong.GiamGia = decimal.Parse(HD.GiamGia.ToString().Replace(".", ""));
                hopDong.SoHopDong = TuDongTangSoHD();
                hopDong.NgayLapHD = DateTime.Now;
                hopDong.MaLoTrinh = HD.MaLoTrinh;
                hopDong.MaNV = HD.MaNV;
                hopDong.MaTrangThai = "0";
                hopDong.SoTienTraTruoc = 0;
                hopDong.SoTienConLai = HD.SoTienConLai;
                hopDong.GhiChu = HD.GhiChu;

                entity.HopDongs.Add(hopDong);


                if (!String.IsNullOrEmpty(strMaChiPhi))
                {
                    //lấy list mã chi phí phát sinh
                    var lstCPPS = strMaChiPhi.Split(',');
                    // Cắt chuỗi lấy list số lượng
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
                    foreach (var cp in lstCPPS)
                    {
                        ChiTietChiPhiPhatSinh ct = new ChiTietChiPhiPhatSinh();
                        ct.MaChiPhi = cp;
                        ct.SoHopDong = hopDong.SoHopDong;
                        ct.SoLuong = 1;
                        if (String.IsNullOrEmpty(arrSoluongCP[jCP].ToString()) || arrSoluongCP[jCP] ==0)
                        {
                            ChiPhiPhatSinh x = entity.ChiPhiPhatSinhs.Where(n => n.MaChiPhi == cp).SingleOrDefault();
                            ct.DonGia = x.PhiPhatSinh;
                        }
                        else
                        {
                            ct.DonGia = arrSoluongCP[jCP];
                        }
                        entity.ChiTietChiPhiPhatSinhs.Add(ct);
                        jCP++;
                    }
                }
                var lstMaLoaiXe = lstLoaiXe.Split('#'); //Cắt chuỗi loại xe
                var lstSoLuong = strSoLuong.Split(','); // Cắt chuỗi số lượng


                int[] arrSoluong = new int[10];
                int i = 0;
                foreach (var sl in lstSoLuong)
                {
                    arrSoluong[i] = int.Parse(sl);
                    i++;
                }

                //Them moi Chi tiet hop dong
                int j = 0;

                //int ngay = Int16.Parse(iNgayLech);
                foreach (var mlx in lstMaLoaiXe)
                {
                    for (int sl = 0; sl < arrSoluong[j]; sl++)
                    {
                        var chiTietHD = new CT_HopDong();
                        chiTietHD.SoHopDong = hopDong.SoHopDong;
                        chiTietHD.MaLoaiXe = mlx;
                        chiTietHD.SoLuongNguoi = CTHD.SoLuongNguoi;
                        chiTietHD.NgayDi = DateTime.Parse(CTHD.NgayDi.ToString("dd/MM/yyyy") + " " + CTHD.GioDon.Value.ToString("HH:mm"));
                        chiTietHD.NgayVe = DateTime.Parse(CTHD.NgayVe.ToString("dd/MM/yyyy HH:mm"));
                        chiTietHD.GioDon = DateTime.Parse(CTHD.NgayDi.ToString("dd/MM/yyyy") + " " + CTHD.GioDon.Value.ToString("HH:mm"));
                        chiTietHD.DiaDiemDon = CTHD.DiaDiemDon;
                        chiTietHD.Gia = (BangGiaQueries.TinhGiaUocTinh(mlx, hopDong.MaLoTrinh).Gia);
                        chiTietHD.MaCongTy = CTHD.MaCongTy;
                        chiTietHD.GhiChu = CTHD.GhiChu;
                        chiTietHD.SoLuong = 1;
                        entity.CT_HopDongs.Add(chiTietHD);
                    }
                    j++;
                }

                ////Them moi hoa don
                //var hoaDon = new HoaDon();
                //hoaDon.SoHoaDon = "HD" + hopDong.SoHopDong;
                //hoaDon.NgayLap = hopDong.NgayLapHD;
                //hoaDon.MaKH = hopDong.MaKH;
                //hoaDon.MaNV = hopDong.MaNV;
                //entity.HoaDons.Add(hoaDon);

                ////Them chi tiet hoa don
                //var chiTietHoaDon = new CT_HoaDon();
                //chiTietHoaDon.SoHoaDon = hoaDon.SoHoaDon;
                //chiTietHoaDon.SoHopDong = hopDong.SoHopDong;
                //chiTietHoaDon.TongSoXeThue = chiTietHoaDon.TongSoXeThue;
                //chiTietHoaDon.SoTienTraTruoc = hopDong.SoTienTraTruoc;
                //chiTietHoaDon.SoTienConLai = hopDong.SoTienConLai;
                //chiTietHoaDon.TongThanhToan = hopDong.SoTienTraTruoc + hopDong.SoTienConLai;
                //entity.CT_HoaDons.Add(chiTietHoaDon);
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

        #region Thêm hợp đồng tuyến đường mới
        /// <summary>
        /// Tạo hợp đồng
        /// </summary>
        /// <param name="HD"></param>
        /// <param name="CTHD"></param>
        /// <param name="KH"></param>
        /// <param name="lstLoaiXe"></param>
        /// <returns>Boolean</returns>
        public static Boolean ThemHopDongTuyenDuongMoi(HopDongViewModel HD, CT_HopDongViewModel CTHD, KhachHangViewModel KH, TuyenDuongMoiViewModel tuyenDuongMoi)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {

                //Tạo mới 1 obj lộ trình
                LoTrinhViewModel loTrinhMoi = new LoTrinhViewModel();

                // Them moi hop dong
                var hopDong = new HopDong();

                //Tạo mới 1 obj bảng giá
                var bangGia = new BangGiaViewModel();

                //Cắt chuỗi loại xe
                var lstMaLoaiXe = tuyenDuongMoi.strLoaiXeMoi.Split(',');

                // Cắt chuỗi số lượng
                var lstSoLuong = tuyenDuongMoi.StrSoLuongXeMoi.Split(',');

                // Gán giá trị số lượng xe vào mảng
                int[] arrSoluong = new int[10];
                int i = 0;
                foreach (var sl in lstSoLuong)
                {
                    if (!string.IsNullOrEmpty(sl))
                    {
                        arrSoluong[i] = int.Parse(sl);
                    }
                    i++;
                }

                // Cắt chuỗi giá loại xe
                var listGiaXe = tuyenDuongMoi.strGiaXeMoi.Split(',');

                // Gán giá trị xe vào chuỗi
                decimal[] arrGiaXe = new decimal[10];
                int g = 0;
                foreach (var gx in listGiaXe)
                {
                    arrGiaXe[g] = decimal.Parse(gx.ToString().Replace(".", ""));
                    g++;
                }

                if (KH.MaKH == "Detra")
                {
                    KhachHangQueries.ThemKhachHang(KH);
                    var kh = entity.KhachHangs.OrderByDescending(n => n.STT).Take(1).SingleOrDefault();
                    hopDong.MaKH = kh.MaKH;

                    //Gán thông tin lộ trình mới
                    loTrinhMoi.TenLoTrinh = tuyenDuongMoi.TenLoTrinhMoi;
                    loTrinhMoi.MaKH = "DETRA";
                    //Thêm lộ trình mới
                    LoTrinhQueries.ThemLoTrinh(loTrinhMoi);
                    //Lấy thông tin lộ trình vừa được thêm
                    var lotrinh = entity.LoTrinhs.OrderByDescending(n => n.STT).Take(1).SingleOrDefault();
                    // Gán giá trị mã lộ trình mới thêm vào mã hợp đồng
                    hopDong.MaLoTrinh = lotrinh.MaLoTrinh;

                    //Gán giá trị cho bảng giá
                    int bg = 0;
                    foreach (var mlx in lstMaLoaiXe)
                    {
                        bangGia.MaLoaiXe = mlx;
                        bangGia.ThoiGian = tuyenDuongMoi.GioUocTinh;
                        bangGia.MaKH = KH.MaKH;
                        bangGia.Gia = arrGiaXe[bg];
                        bangGia.MaLoTrinh = lotrinh.MaLoTrinh;
                        bg++;
                        //Thêm bảng giá
                        BangGiaQueries.ThemBangGia(bangGia);
                    }
                }
                else if (!String.IsNullOrEmpty(KH.MaKH))
                {
                    hopDong.MaKH = KH.MaKH;
                    var kh = entity.KhachHangs.SingleOrDefault(n => n.MaKH == KH.MaKH);
                    //Gán thông tin lộ trình mới
                    loTrinhMoi.TenLoTrinh = tuyenDuongMoi.TenLoTrinhMoi;
                    loTrinhMoi.MaKH = KH.MaKH;
                    //Thêm lộ trình mới
                    LoTrinhQueries.ThemLoTrinh(loTrinhMoi);
                    //Thêm lộ trình mới
                    LoTrinhQueries.ThemLoTrinh(loTrinhMoi);
                    //Lấy thông tin lộ trình vừa được thêm
                    var lotrinh = entity.LoTrinhs.OrderByDescending(n => n.STT).Take(1).SingleOrDefault();
                    // Gán giá trị mã lộ trình mới thêm vào mã hợp đồng
                    hopDong.MaLoTrinh = lotrinh.MaLoTrinh;

                    //Gán giá trị cho bảng giá
                    int bg = 0;
                    foreach (var mlx in lstMaLoaiXe)
                    {
                        bangGia.MaLoaiXe = mlx;
                        bangGia.ThoiGian = tuyenDuongMoi.GioUocTinh;
                        bangGia.MaKH = KH.MaKH;
                        bangGia.Gia = arrGiaXe[bg];
                        bangGia.MaLoTrinh = lotrinh.MaLoTrinh;
                        bg++;
                    }
                    //Thêm bảng giá
                    BangGiaQueries.ThemBangGia(bangGia);
                }

                hopDong.GiamGia = decimal.Parse(tuyenDuongMoi.GiamGiaMoi.ToString().Replace(".", ""));
                hopDong.SoHopDong = TuDongTangSoHD();
                hopDong.NgayLapHD = DateTime.Now;
                hopDong.MaNV = HD.MaNV;
                hopDong.MaTrangThai = "0";
                hopDong.SoTienTraTruoc = 0;
                hopDong.SoTienConLai = tuyenDuongMoi.TongTienMoi;
                hopDong.GhiChu = tuyenDuongMoi.GhiChuMoi;

                entity.HopDongs.Add(hopDong);

                if (!String.IsNullOrEmpty(tuyenDuongMoi.strMaChiPhiMoi))
                {
                    //lấy list mã chi phí phát sinh
                    var lstCPPS = tuyenDuongMoi.strMaChiPhiMoi.Split(',');
                    // Cắt chuỗi lấy list số lượng
                    if (string.IsNullOrEmpty(tuyenDuongMoi.strSoLuongCPMoi))
                    {
                        tuyenDuongMoi.strSoLuongCPMoi = ",";
                    }
                    var lstSoLuongCP = tuyenDuongMoi.strSoLuongCPMoi.Split(',');

                    //gán giá trị số lượng chi phí vào mảng
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
                    foreach (var cp in lstCPPS)
                    {
                        ChiTietChiPhiPhatSinh ct = new ChiTietChiPhiPhatSinh();
                        ct.MaChiPhi = cp;
                        ct.SoHopDong = hopDong.SoHopDong;
                        ct.SoLuong = 1;
                        if (String.IsNullOrEmpty(arrSoluongCP[jCP].ToString()) || arrSoluongCP[jCP] == 0)
                        {
                            ChiPhiPhatSinh x = entity.ChiPhiPhatSinhs.Where(n => n.MaChiPhi == cp).SingleOrDefault();
                            ct.DonGia = x.PhiPhatSinh;
                        }
                        else
                        {
                            ct.DonGia = arrSoluongCP[jCP];
                        }
                        entity.ChiTietChiPhiPhatSinhs.Add(ct);
                        jCP++;
                    }
                }

                //Them moi Chi tiet hop dong
                int j = 0;
                foreach (var mlx in lstMaLoaiXe)
                {
                    for (int sl = 0; sl < arrSoluong[j]; sl++)
                    {
                        var chiTietHD = new CT_HopDong();
                        chiTietHD.SoHopDong = hopDong.SoHopDong;
                        chiTietHD.MaLoaiXe = mlx;
                        chiTietHD.SoLuongNguoi = tuyenDuongMoi.SoLuongNguoiMoi;
                        chiTietHD.NgayDi = DateTime.Parse(tuyenDuongMoi.NgayDiMoi.Value.ToString("dd/MM/yyyy") + " " + tuyenDuongMoi.GioDonMoi.Value.ToString("HH:mm"));
                        chiTietHD.NgayVe = DateTime.Parse(tuyenDuongMoi.NgayVeMoi.Value.ToString("dd/MM/yyyy HH:mm"));
                        chiTietHD.GioDon = DateTime.Parse(tuyenDuongMoi.NgayDiMoi.Value.ToString("dd/MM/yyyy") + " " + tuyenDuongMoi.GioDonMoi.Value.ToString("HH:mm"));
                        chiTietHD.DiaDiemDon = tuyenDuongMoi.DiaDiemMoi;
                        chiTietHD.Gia = arrGiaXe[j];
                        chiTietHD.MaCongTy = CTHD.MaCongTy;
                        chiTietHD.GhiChu = CTHD.GhiChu;
                        chiTietHD.SoLuong = 1;
                        entity.CT_HopDongs.Add(chiTietHD);
                    }
                    j++;
                }

                ////Them moi hoa don
                //var hoaDon = new HoaDon();
                //hoaDon.SoHoaDon = "HD" + hopDong.SoHopDong;
                //hoaDon.NgayLap = hopDong.NgayLapHD;
                //hoaDon.MaKH = hopDong.MaKH;
                //hoaDon.MaNV = hopDong.MaNV;
                //entity.HoaDons.Add(hoaDon);

                ////Them chi tiet hoa don
                //var chiTietHoaDon = new CT_HoaDon();
                //chiTietHoaDon.SoHoaDon = hoaDon.SoHoaDon;
                //chiTietHoaDon.SoHopDong = hopDong.SoHopDong;
                //chiTietHoaDon.TongSoXeThue = chiTietHoaDon.TongSoXeThue;
                //chiTietHoaDon.SoTienTraTruoc = hopDong.SoTienTraTruoc;
                //chiTietHoaDon.SoTienConLai = hopDong.SoTienConLai;
                //chiTietHoaDon.TongThanhToan = hopDong.SoTienTraTruoc + hopDong.SoTienConLai;
                //entity.CT_HoaDons.Add(chiTietHoaDon);
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

        #region Cập nhật trạng thái hợp đồng
        /// <summary>
        /// cap nhat lai trang thai hop dong
        /// </summary>
        /// <returns>Boolean</returns>
        public static Boolean CapNhatTrangThai()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                //Lay danh sach hop dong dang cho
                var lstDangCho = entity.HopDongs.Where(n => n.MaTrangThai == "0");
                foreach (var dcho in lstDangCho)
                {
                    TrangThaiQueries.CapNhatTrangThaiDangChay(dcho.SoHopDong);
                }
                TrangThaiQueries.CapNhatTrangThaiPhuXeDangChay();
                TrangThaiQueries.CapNhatTrangThaiTaiXeDangChay();
                TrangThaiQueries.CapNhatTrangThaiXeDangChay();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        #endregion

        #region Lấy danh sách hợp đồng
        /// <summary>
        /// lay danh sach hop dong
        /// </summary>
        /// <returns> List HopDongViewModel </returns>
        public static List<HopDongViewModel> LayDanhSachHopDong()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from hd in entity.HopDongs
                                    //where hd.MaTrangThai != "3"
                                select new HopDongViewModel()
                                {
                                    SoHopDong = hd.SoHopDong,
                                    MaLoTrinh = hd.MaLoTrinh,
                                    NgayLapHD = hd.NgayLapHD,
                                    MaKH = hd.MaKH,
                                    MaNV = hd.MaNV,
                                    MaHinhThucThue = hd.MaHinhThucThue,
                                    MaHinhThucThanhToan = hd.MaHinhThucThanhToan,
                                    SoTienTraTruoc = hd.SoTienTraTruoc,
                                    SoTienConLai = hd.SoTienConLai,
                                    MaTrangThai = hd.MaTrangThai,
                                    GiamGia = hd.GiamGia,
                                    GhiChu = hd.GhiChu,
                                    STT = hd.STT,
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    KhachHangs = (
                                                from kh in entity.KhachHangs
                                                where kh.MaKH == hd.MaKH
                                                select new KhachHangViewModel()
                                                {
                                                    TenKH = kh.TenKH
                                                }).FirstOrDefault(),
                                    TrangThaiHopDongs = (
                                                from tt in entity.TrangThaiHopDongs
                                                where tt.MaTrangThai == hd.MaTrangThai
                                                select new TrangThaiHopDongViewModel()
                                                {
                                                    TenTrangThai = tt.TenTrangThai
                                                }).FirstOrDefault(),
                                }).OrderByDescending(n => n.NgayLapHD).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
        #endregion

        #region Lấy thông tin chi tiết hợp đồng
        /// <summary>
        /// Lấy thông tin chi tiết hợp đồng
        /// </summary>
        /// <param name="SoHopDong"></param>
        /// <returns>HopDongViewModel Single</returns>
        public static HopDongViewModel LayThongTinHopDong(String SoHopDong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from hd in entity.HopDongs
                                where hd.SoHopDong == SoHopDong
                                select new HopDongViewModel()
                                {
                                    SoHopDong = hd.SoHopDong,
                                    MaLoTrinh = hd.MaLoTrinh,
                                    NgayLapHD = hd.NgayLapHD,
                                    MaKH = hd.MaKH,
                                    MaNV = hd.MaNV,
                                    MaHinhThucThue = hd.MaHinhThucThue,
                                    MaHinhThucThanhToan = hd.MaHinhThucThanhToan,
                                    SoTienTraTruoc = hd.SoTienTraTruoc,
                                    SoTienConLai = hd.SoTienConLai,
                                    MaTrangThai = hd.MaTrangThai,
                                    GiamGia = hd.GiamGia,
                                    GhiChu = hd.GhiChu,
                                    STT = hd.STT,
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    KhachHangs = (
                                                from kh in entity.KhachHangs
                                                where kh.MaKH == hd.MaKH
                                                select new KhachHangViewModel()
                                                {
                                                    TenKH = kh.TenKH,
                                                    SDT = kh.SDT,
                                                    DiaChiKH = kh.DiaChiKH,
                                                    MaSoThue = kh.MaSoThue,
                                                    TenCongTy = kh.TenCongTy,
                                                    SDTCongTy = kh.SDTCongTy,
                                                    DiaChiCongTy = kh.DiaChiCongTy,
                                                    GiamGia = kh.GiamGia,
                                                    NguoiLienHe = kh.NguoiLienHe
                                                }).FirstOrDefault(),
                                    TrangThaiHopDongs = (
                                                from tt in entity.TrangThaiHopDongs
                                                where tt.MaTrangThai == hd.MaTrangThai
                                                select new TrangThaiHopDongViewModel()
                                                {
                                                    TenTrangThai = tt.TenTrangThai
                                                }).FirstOrDefault(),
                                    NhanViens = (
                                                from nv in entity.NhanViens
                                                where nv.MaNV == hd.MaNV
                                                select new NhanVienViewModel()
                                                {
                                                    HoTen = nv.HoTen
                                                }).FirstOrDefault(),
                                    HinhThucThues = (
                                                from htt in entity.HinhThucThues
                                                where htt.MaHinhThuc == htt.MaHinhThuc
                                                select new HinhThucThueViewModel()
                                                {
                                                    TenHinhThuc = htt.TenHinhThuc
                                                }).FirstOrDefault(),
                                    HinhThucThanhToans = (
                                                from httt in entity.HinhThucThanhToans
                                                where httt.MaHinhThucTT == hd.MaHinhThucThanhToan
                                                select new HinhThucThanhToanViewModel()
                                                {
                                                    TenHinhThucTT = httt.TenHinhThucTT
                                                }).FirstOrDefault(),
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

        #region lấy danh sách đang chờ
        /// <summary>
        /// LayDanhSachDangCho
        /// </summary>
        /// <returns></returns>
        public static List<HopDongViewModel> LayDanhSachDangCho()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from hd in entity.HopDongs
                                join cthd in entity.CT_HopDongs on hd.SoHopDong equals cthd.SoHopDong
                                where hd.MaTrangThai == "0"
                                select new HopDongViewModel()
                                {
                                    SoHopDong = hd.SoHopDong,
                                    MaLoTrinh = hd.MaLoTrinh,
                                    NgayLapHD = hd.NgayLapHD,
                                    MaKH = hd.MaKH,
                                    MaNV = hd.MaNV,
                                    MaHinhThucThue = hd.MaHinhThucThue,
                                    MaHinhThucThanhToan = hd.MaHinhThucThanhToan,
                                    SoTienTraTruoc = hd.SoTienTraTruoc,
                                    SoTienConLai = hd.SoTienConLai,
                                    MaTrangThai = hd.MaTrangThai,
                                    GiamGia = hd.GiamGia,
                                    STT = hd.STT,
                                    LoTrinhs = (
                                                from lt in entity.LoTrinhs
                                                where lt.MaLoTrinh == hd.MaLoTrinh
                                                select new LoTrinhViewModel()
                                                {
                                                    TenLoTrinh = lt.TenLoTrinh
                                                }).FirstOrDefault(),
                                    TrangThaiHopDongs = (
                                                from tt in entity.TrangThaiHopDongs
                                                where tt.MaTrangThai == hd.MaTrangThai
                                                select new TrangThaiHopDongViewModel()
                                                {
                                                    TenTrangThai = tt.TenTrangThai
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

        #region lấy danh sách chờ thanh toán
        public static List<HopDongViewModel> LayDanhSachChoThanhToan()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                               from hd in entity.HopDongs
                               where hd.MaTrangThai == "3"
                               select new HopDongViewModel()
                               {
                                   SoHopDong = hd.SoHopDong,
                                   MaLoTrinh = hd.MaLoTrinh,
                                   NgayLapHD = hd.NgayLapHD,
                                   MaKH = hd.MaKH,
                                   MaNV = hd.MaNV,
                                   MaHinhThucThue = hd.MaHinhThucThue,
                                   MaHinhThucThanhToan = hd.MaHinhThucThanhToan,
                                   SoTienTraTruoc = hd.SoTienTraTruoc,
                                   SoTienConLai = hd.SoTienConLai,
                                   MaTrangThai = hd.MaTrangThai,
                                   GiamGia = hd.GiamGia,
                                   GhiChu = hd.GhiChu,
                                   STT = hd.STT,
                                   LoTrinhs = (
                                               from lt in entity.LoTrinhs
                                               where lt.MaLoTrinh == hd.MaLoTrinh
                                               select new LoTrinhViewModel()
                                               {
                                                   TenLoTrinh = lt.TenLoTrinh
                                               }).FirstOrDefault(),
                                   KhachHangs = (
                                               from kh in entity.KhachHangs
                                               where kh.MaKH == hd.MaKH
                                               select new KhachHangViewModel()
                                               {
                                                   TenKH = kh.TenKH
                                               }).FirstOrDefault(),
                                   TrangThaiHopDongs = (
                                               from tt in entity.TrangThaiHopDongs
                                               where tt.MaTrangThai == hd.MaTrangThai
                                               select new TrangThaiHopDongViewModel()
                                               {
                                                   TenTrangThai = tt.TenTrangThai
                                               }).FirstOrDefault(),
                               }).OrderByDescending(n => n.NgayLapHD).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }

        }

        #endregion

        #region Chỉnh sửa hợp đồng
        /// <summary>
        /// Chỉnh sửa hợp đồng
        /// </summary>
        /// <param name="HD"></param>
        /// <returns></returns>
        public static Boolean ChinhSuaHopDong(HopDongViewModel HD, String strMaChiPhi, String strSoLuong)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                HopDong hd = entity.HopDongs.SingleOrDefault(n => n.SoHopDong == HD.SoHopDong);
                hd.GiamGia = HD.GiamGia;
                hd.GhiChu = HD.GhiChu;
                hd.MaKH = HD.MaKH;
                hd.MaLoTrinh = HD.MaLoTrinh;
                //lấy list mã chi phí phát sinh
                var lstCPPS = strMaChiPhi.Split(',');
                // Cắt chuỗi lấy list số lượng
                var lstSoLuong = strSoLuong.Split(',');
                int[] arrSoluong = new int[10];
                int i = 0;
                foreach (var sl in lstSoLuong)
                {
                    arrSoluong[i] = int.Parse(sl);
                    i++;
                }

                int j = 0;
                foreach (var cp in lstCPPS)
                {
                    ChiTietChiPhiPhatSinh ct = new ChiTietChiPhiPhatSinh();
                    ct.MaChiPhi = cp;
                    ct.SoHopDong = hd.SoHopDong;
                    ct.SoLuong = arrSoluong[j];
                    ChiPhiPhatSinh x = entity.ChiPhiPhatSinhs.Where(n => n.MaChiPhi == cp).SingleOrDefault();
                    ct.DonGia = x.PhiPhatSinh;
                    entity.ChiTietChiPhiPhatSinhs.Add(ct);
                    j++;
                }
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
    }
}
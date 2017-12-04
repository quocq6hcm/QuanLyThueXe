using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Queries;

namespace QuanLyThueXe.Controllers
{
    public class HopDongController : Controller
    {
        // GET: HopDong
        #region Thêm hợp đồng
        [HttpGet]
        public ActionResult MenuThemHopDong()
        {
            ViewBag.CTCPPS = ChiPhiPhatSinhQueries.DanhSachChiPhiPhatSinh();
            ViewBag.LoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
            ViewBag.LoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.KhachHang = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            return View();
        }

        [HttpPost]
        public ActionResult MenuThemHopDong(HopDongViewModel HD, CT_HopDongViewModel CTHD, KhachHangViewModel KH,TuyenDuongMoiViewModel tuyenDuongMoi, string LoaiXe, string strSoLuong, string strMaChiPhi, string strSoLuongCP,string iNgayLech = "1")
        {
            TaiKhoanViewModel taiKhoan = Session["TaiKhoan"] as TaiKhoanViewModel;
            HD.MaNV = taiKhoan.MaNV;
            ViewBag.LoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
            ViewBag.LoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.KhachHang = KhachHangQueries.DanhSachKhachHang();
            if(String.IsNullOrEmpty(LoaiXe))
            {
                var model = HopDongQueries.ThemHopDongTuyenDuongMoi(HD, CTHD, KH, tuyenDuongMoi);
            }
            else
            {
                var model = HopDongQueries.ThemHopDong(HD, CTHD, KH, LoaiXe, strSoLuong, strMaChiPhi, strSoLuongCP, iNgayLech);
            }
            return RedirectToAction("MenuDanhSachHopDong", "HopDong");
        }

        #endregion

        #region Lấy bảng giá tuyến đường cũ JSON
        [HttpGet]
        public JsonResult GetBangGia(string maLoTrinh, string maLoaiXe, string soluong, string maKhachHang, string giamGia,string strMaChiPhi, string strSoLuongCP, string iNgayLech = "1")
        {
            var data = BangGiaQueries.chiTietBangGia(maLoTrinh, maLoaiXe, soluong, maKhachHang, giamGia, strMaChiPhi, strSoLuongCP, iNgayLech);
            var niemyet = BangGiaQueries.chiTietBangGiaNiemYet(maLoTrinh, maLoaiXe, soluong, maKhachHang);
            return Json(new { data = data, niemyet = niemyet }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Lấy bảng giá tuyến đường mới JSON
        public JsonResult TuyenDuongMoi(TuyenDuongMoiViewModel tuyenDuongMoi)
        {
            var data = BangGiaQueries.TinhBangGiaTuyenDuongMoi(tuyenDuongMoi);
            return Json(new {data = data},JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Lấy 1 chi phí phát sinh JSON
        public JsonResult LayMotChiPhiPhatSinh(string mcp)
        {
            var data = ChiPhiPhatSinhQueries.ChiTiet_CPPS(mcp);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Lấy danh sách loại xe tuyến đường mới JSON
        public JsonResult LayDanhSachLoaiXe()
        {
            var loaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            return Json(new { loaiXe = loaiXe }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Danh sách hợp đồng
        [HttpGet]
        public ActionResult MenuDanhSachHopDong()
        {
            HopDongQueries.CapNhatTrangThai();
            TrangThaiQueries.CapNhatTrangThaiChoThanhToan();
            var model = HopDongQueries.LayDanhSachHopDong();
            return View(model);
        }
        #endregion

        #region Thông tin chi tiết hợp đồng
        [HttpGet]
        public ActionResult ChiTietHopDong(String SoHopDong)
        {
            var model = HopDongQueries.LayThongTinHopDong(SoHopDong);
            ViewBag.CTCPPS = ChiTietChiPhiPhatSinhQueries.LayDanhSachCTCPPhatSinhTheoSoHopDong(SoHopDong);
            ViewBag.LoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.CTHD = CT_HopDongQueries.GroupbyCTHopDong(SoHopDong);
            ViewBag.CongTy = CongTiesQueries.LayThongTinChiTietCty("DETRA");
            ViewBag.ChiPhi = ChiPhiPhatSinhQueries.DanhSachChiPhiPhatSinh();
            return View(model);
        }
        #endregion 

        #region Hoàn thành hợp đồng
        [HttpGet]
        public ActionResult HoanThanhHopDong(String SoHopDong)
        {
            TrangThaiQueries.CapNhatTrangThaiHoanThanh(SoHopDong);
            return RedirectToAction("MenuDanhSachHopDong", "HopDong");
        }
        #endregion

        #region Hủy hợp đồng
        [HttpGet]
        public ActionResult HuyHopDong(String SoHopDong)
        {
            TrangThaiQueries.CapNhatTrangThaiPhuXeRanh(SoHopDong);
            TrangThaiQueries.CapNhatTrangThaiTaiXeRanh(SoHopDong);
            TrangThaiQueries.CapNhatTrangThaiXeRanh(SoHopDong);
            TrangThaiQueries.CapNhatTrangThaiHuy(SoHopDong);
            return RedirectToAction("MenuDanhSachHopDong", "HopDong");
        }
        #endregion

        #region Danh sách hợp đồng chỉnh sửa hợp đồng
        [HttpGet]
        public ActionResult MenuDanhSachChinhSuaHopDong()
        {
            HopDongQueries.CapNhatTrangThai();
            var model = HopDongQueries.LayDanhSachHopDong();
            return View(model);
        }
        #endregion

        #region Chỉnh sửa hợp đồng
        [HttpGet]
        public ActionResult ChinhSuaHopDong(String SoHopDong)
        {
            ViewBag.CTCPPS = ChiTietChiPhiPhatSinhQueries.LayDanhSachCTCPPhatSinhTheoSoHopDong(SoHopDong);
            ViewBag.ChiPhi = ChiPhiPhatSinhQueries.DanhSachChiPhiPhatSinh();
            ViewBag.LoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
            ViewBag.KhachHang = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            var model = HopDongQueries.LayThongTinHopDong(SoHopDong);
            return View(model);
        }

        [HttpPost]
        public ActionResult ChinhSuaHopDong(HopDongViewModel HD, String strMaChiPhi, String strSoLuong)
        {
            HopDongQueries.ChinhSuaHopDong(HD, strMaChiPhi, strSoLuong);
            return RedirectToAction("MenuDanhSachChinhSuaHopDong", "HopDong");
        }
        #endregion

        #region Danh sách chi tiết hợp đồng
        public ActionResult MenuDanhSachCTHD()
        {
            var model = CT_HopDongQueries.LayDanhSachCTDH();
            return View(model);
        }
        #endregion

        #region Chỉnh sửa chi tiết hợp đồng
        [HttpGet]
        public ActionResult ChinhSuaCTHD(int SoCTHopDong)
        {
            var model = CT_HopDongQueries.LayThongTinChiTietCTHD(SoCTHopDong);
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaCTHD(CT_HopDongViewModel CTHD)
        {
            return RedirectToAction("MenuDanhSachCTHD", "HopDong");
        }
        #endregion

        #region lấy danh sách lộ trình theo mã khách hàng
        [HttpGet]
        public JsonResult LayDanhSachLoTrinhTheoMaKH(String maKhachHang)
        {
            var model = LoTrinhQueries.LayDanhSachLoTrinhTheoMaKH(maKhachHang);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Lấy danh sách loại xe theo mã khách hàng và mã lộ trình Json
        [HttpGet]
        public JsonResult LayDanhSachLoaiXeMaKHVaMaLT(string maKhachHang, string maLoTrinh)
        {
            var model = BangGiaQueries.LayDanhSachLoaiXeMaKHVaMaLT(maKhachHang, maLoTrinh);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region lấy danh sách chi phí phát sinh json
        [HttpGet]
        public JsonResult LayDanhSachCPPS()
        {
            var model = ChiPhiPhatSinhQueries.DanhSachChiPhiPhatSinh();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Danh sách đang chờ thanh toán
        [HttpGet]
        public ActionResult MenuDanhSachChoThanhToan()
        {
            TrangThaiQueries.CapNhatTrangThaiChoThanhToan();
            var model = HopDongQueries.LayDanhSachChoThanhToan();
            return View(model);
        }
        #endregion

        #region Lấy danh sách lộ trình theo mã khách hàng trong bảng giá
        public JsonResult LayDanhSachLoTrinhTheoMaKhachHangTrongBangGia(String maKhachHang)
        {
            var model = BangGiaQueries.LayDanhSachLoTrinhTheoMaKhachHangTrongBangGia(maKhachHang);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
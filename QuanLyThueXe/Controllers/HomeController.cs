using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThueXe.Models;
using QuanLyThueXe.Queries;
using QuanLyThueXe.ViewModels;

namespace QuanLyThueXe.Controllers
{
    public class HomeController : Controller
    {
        QuanLyThueXeEntities db = new QuanLyThueXeEntities();

        #region Thống kê
        [HttpGet]
        public ActionResult MenuThongKe()
        {
            return View();
        }
        #endregion

        #region Danh sách hợp đồng chạy theo ngày
        [HttpGet]
        public ActionResult MenuLichTheoNgay()
        {
            var model = CT_HopDongQueries.LayDanhSachChiTietHopDongTheoNgay(DateTime.Today);
            return View(model);
        }

        [HttpGet]
        public JsonResult LichTheoNgay(String ngay)
        {
            //if(!String.IsNullOrEmpty(ngay))
            //{
            //    ngay = DateTime.Now.ToString("dd/MM/yyyy");
            //}
            DateTime date = DateTime.Parse(ngay);
            var result = CT_HopDongQueries.LayDanhSachChiTietHopDongTheoNgay(date);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sidebar Partial
        [ChildActionOnly]
        public PartialViewResult SidebarPartial()
        {
            TaiKhoanViewModel TaiKhoan = Session["TaiKhoan"] as TaiKhoanViewModel;
            var LoaiController = LoaiControllerQueries.LayDanhSachNghiepVu();
            ViewBag.LoaiAction = LoaiActionQueries.LayDanhSachActionTheoQuyen(TaiKhoan.MaQuyen);
            return PartialView(LoaiController);
        }
        #endregion

        #region Partial thông tin nhân viên
        [ChildActionOnly]
        public PartialViewResult InfoPartial()
        {
            TaiKhoanViewModel TaiKhoan = Session["TaiKhoan"] as TaiKhoanViewModel;
            var model = NhanVienQueries.LayThongTinChiTiet(TaiKhoan.MaNV);
            return PartialView(model);
        }
        #endregion

        #region Timeline Chi tiết hợp đồng
        [HttpGet]
        public JsonResult LayDanhThoiGian()
        {
            var data = CT_HopDongQueries.layDanhSachCTHDTheoThang();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Lịch chạy của mỗi nhân viên
        [HttpGet]
        public ActionResult LichChayTheoMaNV(String MaNV)
        {
            var model = CT_HopDongQueries.LayDSCTHDTheoMaNV(MaNV);
            ViewBag.TrangThai = TrangThaiQueries.LayDanhSachTrangThai();
            return View(model);
        }
        #endregion

        #region Lấy danh sách nhân viên đang online
        public PartialViewResult LayDanhSachNhanVienOnline()
        {
            var result = TaiKhoanQueries.LayDanhSachNhanVienOnl();
            return PartialView(result);
        }

        [HttpGet]
        public JsonResult LayDanhSachNhanVien()
        {
            var result = TaiKhoanQueries.LayDanhSachNhanVienOnl();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult Chat()
        {
            return View();
        }

        QuanLyThueXeEntities _db = new QuanLyThueXeEntities();
        public String TestingSite()
        {
            return NhanVienQueries.TestingSiteMethod() + "";
        }

    }
}
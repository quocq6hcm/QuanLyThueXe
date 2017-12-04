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
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        [HttpGet]
        public ActionResult MenuThemKhachHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MenuThemKhachHang(KhachHangViewModel khachHang)
        {
            KhachHangQueries.ThemKhachHang(khachHang);
            return RedirectToAction("MenuDanhSachKhachHang", "KhachHang");
        }


        #region Thêm khách hàng thân thiết
        [HttpGet]
        public ActionResult ThemKhachHangThanThiet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemKhachHangThanThiet(KhachHangViewModel khachHang)
        {
            KhachHangQueries.ThemKhachHangThanThiet(khachHang);
            return RedirectToAction("MenuDanhSachKhachHangThanThiet", "KhachHang");
        }

        #endregion
        /// <summary>
        /// Danh sach khang hang le
        /// </summary>
        /// <returns>list<KhachHangViewModel></returns>
        public ActionResult MenuDanhSachKhachHang()
        {
            var model = KhachHangQueries.LayDanhSachKhachHangLe();
            return View(model);
        }

        /// <summary>
        /// Danh sach khang hang than thiet
        /// </summary>
        /// <returns>list<KhachHangViewModel></returns>
        public ActionResult MenuDanhSachKhachHangThanThiet()
        {
            var model = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            return View(model);
        }

        #region Thông tin chi tiết khách hàng lẻ
        public ActionResult ThongTinChiTiet(string MaKH)
        {
            var model = KhachHangQueries.LayThongTinChiTiet(MaKH);
            return View(model);
        }
        #endregion

        #region Thông tin chi tiết khách hàng thân thiết
        public ActionResult ThongTinChiTiet_KTT(string MaKH)
        {
            var model = KhachHangQueries.LayThongTinChiTiet(MaKH);
            return View(model);
        }
        #endregion

        [HttpGet]
        public ActionResult ChinhSuaKhachHang(string MaKH)
        {
            var model = KhachHangQueries.LayThongTinChiTiet(MaKH);
            ViewBag.MaLoaiKH = new SelectList(LoaiKhachHangQueries.LayDanhSachLoaiKhachHang(), "MaLoaiKH", "TenLoaiKH", model.MaLoaiKH);
            return View(model);
        }

        [HttpGet]
        public ActionResult ChinhSuaKhachHangThanThiet(string MaKH)
        {
            var model = KhachHangQueries.LayThongTinChiTiet(MaKH);
            ViewBag.MaLoaiKH = new SelectList(LoaiKhachHangQueries.LayDanhSachLoaiKhachHang(), "MaLoaiKH", "TenLoaiKH", model.MaLoaiKH);
            return View(model);
        }

        [HttpPost]
        public ActionResult ChinhSuaKhachHang(KhachHangViewModel khachHang)
        {
            var model = KhachHangQueries.LayThongTinChiTiet(khachHang.MaKH);
            //
            ViewBag.MaLoaiKH = new SelectList(LoaiKhachHangQueries.LayDanhSachLoaiKhachHang(), "MaLoaiKH", "TenLoaiKH", model.MaLoaiKH);
            if (model.MaLoaiKH == "LKH2")
            {
                KhachHangQueries.CapNhatThongTinKhachHangThanThiet(khachHang);
                return RedirectToAction("MenuDanhSachKhachHangThanThiet", "KhachHang");
            }
            else
            {
                KhachHangQueries.CapNhatThongTinKhachHang(khachHang);
                return RedirectToAction("MenuDanhSachKhachHang", "KhachHang");
            }
        }

        [HttpGet]
        public JsonResult GetThongTinKH(String maKhachHang)
        {
            var data = KhachHangQueries.LayThongTinChiTiet(maKhachHang);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult XoaKH(String MaKH)
        {
            KhachHangQueries.XoaKH(MaKH);
            return RedirectToAction("MenuDanhSachKhachHang", "KhachHang");
        }

        [HttpGet]
        public ActionResult XoaKHTT(String MaKH)
        {
            KhachHangQueries.XoaKH(MaKH);
            return RedirectToAction("MenuDanhSachKhachHangThanThiet", "KhachHang");
        }
    }
}
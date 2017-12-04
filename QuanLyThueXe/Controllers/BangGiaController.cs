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
    public class BangGiaController : Controller
    {
        QuanLyThueXeEntities db = new QuanLyThueXeEntities();

        #region Danh sách bảng giá
        //danh sách bảng giá
        [HttpGet]
        public ActionResult MenuDanhSachBangGia()
        {

            var lst = BangGiaQueries.LayDanhSachBangGia();
            ViewBag.KhachHangTT = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            return View(lst);
        }
        #endregion

        #region Chi tiết bảng giá
        //thông tin chi tiết giá
        public ActionResult ChiTietGia(string mabg)
        {
            var bg = BangGiaQueries.LayChiTietGia(mabg);
            return View(bg);
        }
        #endregion

        #region Chỉnh sửa bảng giá
        ////lấy danh sách chỉnh sửa giá
        //public ActionResult MenuDSChinhSuaGia()
        //{
        //    var lstGia = BangGiaQueries.LayDanhSachBangGia();
        //    ViewBag.LoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
        //    ViewBag.KhachHang = KhachHangQueries.DanhSachKhachHang();
        //    ViewBag.LoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
        //    return View(lstGia);
        //}

        //chỉnh sửa giá
        [HttpGet]
        public ActionResult ChinhsuaGia(string id)
        {
            var bg = BangGiaQueries.LayChiTietGia(id);
            ViewBag.MaLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.MaKH = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            ViewBag.MaLoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
            return View(bg);
        }

        [HttpPost]
        public ActionResult ChinhsuaGia(BangGiaViewModel bg)
        {
            ViewBag.MaLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.MaKH = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            ViewBag.MaLoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
            BangGiaQueries.ChinhsuaGia(bg);
            return RedirectToAction("MenuDanhSachBangGia", "BangGia");
        }
        #endregion

        #region Thêm bảng giá
        /// <summary>
        /// them bang gia
        /// </summary>
        /// <param name = "MaBangGia"></param>
        /// <returns>list<BangGiaViewModel></returns>
        [HttpGet]
        public ActionResult MenuThemBangGia()
        {
            ViewBag.MaLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.MaKH = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            ViewBag.MaLoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
            return View();
        }

        [HttpPost]
        public ActionResult MenuThemBangGia(BangGiaViewModel BG)
        {
            ViewBag.MaLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.MaKH = KhachHangQueries.DanhSachKhachHang();
            ViewBag.MaLoTrinh = LoTrinhQueries.LayDanhSachLoTrinh();
            if (BangGiaQueries.Kiemtra(BG))
            {
                BangGiaQueries.ThemBangGia(BG);
                ViewBag.BangGia = "Thêm thành công";
                return View();
            }
            else
            {
                ViewBag.BangGia = "Thêm thất bại.Bảng giá nãy đã tồn tại";
                return View();
            }
        }
        #endregion

        #region lấy danh sách bảng giá theo mã khách hàng Json
        public JsonResult LayDanhSachBangGiaTheoMaKhachHang(string maKhangHang)
        {
            var model = BangGiaQueries.LayDanhSachBangGiaTheoMaKhachHang(maKhangHang);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Lấy lộ trình theo mã khách hàng Json
        public JsonResult LayLoTrinhTheoMaKH(string maKhangHang)
        {
            var result = LoTrinhQueries.LayDanhSachLoTrinhTheoMaKH(maKhangHang);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
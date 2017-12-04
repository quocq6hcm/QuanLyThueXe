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
    public class LoTrinhController : Controller
    {
        // GET: LoTrinh
        public ActionResult MenuDanhSachLoTrinh()
        {
            var lstLT = LoTrinhQueries.LayDanhSachLoTrinh();
            return View(lstLT);
        }

        //thêm lộ trình
        [HttpGet]
        public ActionResult MenuThemLoTrinh()
        {
            ViewBag.MaKH = KhachHangQueries.LayDanhSachKhachHangThanThiet();
            return View();
        }

        [HttpPost]
        public ActionResult MenuThemLoTrinh(LoTrinhViewModel lotrinh)
        {
            ViewBag.MaKH = KhachHangQueries.DanhSachKhachHang();
            LoTrinh x = (new QuanLyThueXeEntities()).LoTrinhs.SingleOrDefault(n => n.TenLoTrinh == lotrinh.TenLoTrinh && n.MaKH == lotrinh.MaKH && n.Dang == true);
            if (x != null)
            {
                @ViewBag.ThongBaoTrungTen = "Lộ trình này đã có";
                return View();
            }
            LoTrinhQueries.ThemLoTrinh(lotrinh);
            return RedirectToAction("MenuDanhSachLoTrinh", "LoTrinh");
        }

        //chỉnh sửa lộ trình
        [HttpGet]
        public ActionResult ChinhSuaLoTrinh(string MaLT)
        {
            ViewBag.MaKH = KhachHangQueries.DanhSachKhachHang();
            ViewBag.model = LoTrinhQueries.ChiTiet_LoTrinh(MaLT);
            var model = LoTrinhQueries.LayDanhSachLoTrinh();
            return View(model);
        }
        
        [HttpGet]
        public JsonResult ChinhSuaLoTrinhJson(LoTrinhViewModel Lt)
        {
            var model = LoTrinhQueries.ChinhSua_LT(Lt);
            return Json(Lt, JsonRequestBehavior.AllowGet);
        }

        #region xóa lộ trình
        [HttpGet]
        public JsonResult XoaLT(String MaLT)
        {
            var result = LoTrinhQueries.XoaLT(MaLT);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Load lại list lộ trình bằng json
        public JsonResult LoadLoTrinh()
        {
            var result = LoTrinhQueries.LayDanhSachLoTrinh();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region xóa lộ trình
        [HttpGet]
        public ActionResult XoaLoTrinh(String MaLT)
        {
            LoTrinhQueries.XoaLT(MaLT);
            return RedirectToAction("MenuDanhSachLoTrinh", "LoTrinh");
        }
        #endregion
    }
}
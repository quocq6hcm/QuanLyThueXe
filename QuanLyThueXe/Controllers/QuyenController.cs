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
    public class QuyenController : Controller
    {
        // GET: Quyen
        [HttpGet]
        public ActionResult MenuThemQuyen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MenuThemQuyen(QuyenViewModel quyen)
        {
            QuyenQueries.ThemQuyen(quyen);
            return RedirectToAction("MenuDanhSachQuyen","Quyen");
        }
        public ActionResult MenuDanhSachQuyen()
        {
            var model = QuyenQueries.LayDanhSachQuyen();
            return View(model);
        }

        [HttpGet]
        public ActionResult ChinhSuaQuyen(string MaQuyen)
        {
            var model = QuyenQueries.LayDanhSachQuyen();
            ViewBag.Quyen = QuyenQueries.LayThongTinChiTiet(MaQuyen);
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaQuyen(QuyenViewModel quyen)
        {
            QuyenQueries.ChinhSuaQuyen(quyen);
            return RedirectToAction("MenuDanhSachQuyen", "Quyen");
        }

        public ActionResult MenuPhanQuyen()
        {
            var model = QuyenQueries.LayDanhSachQuyen();
            return View(model);
        }
        [HttpGet]
        public ActionResult PhanQuyen(string MaQuyen)
        {
            //Lấy thông tin chi tiết quyền
            ViewBag.Quyen = QuyenQueries.LayThongTinChiTiet(MaQuyen);
            //Lay danh sach action
            ViewBag.Action = LoaiActionQueries.LayDanhSachTinhNang();
            //Lay danh sach action cua 1 quyen
            ViewBag.PhanQuyen = PhanQuyenQueries.LayDanhSachPhanQuyen(MaQuyen);
            return View();
        }
        [HttpPost]
        public ActionResult PhanQuyen(string MaQuyen, string strMaAction)
        {
            PhanQuyenQueries.CapNhatLaiQuyen(MaQuyen, strMaAction);
            return RedirectToAction("MenuPhanQuyen", "Quyen");
        }
    }
}
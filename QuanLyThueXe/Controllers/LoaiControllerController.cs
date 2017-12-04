using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThueXe.Models;
using QuanLyThueXe.Queries;
using QuanLyThueXe.ViewModels;
using PagedList.Mvc;
using PagedList;

namespace QuanLyThueXe.Controllers
{
    public class LoaiControllerController : Controller
    {
        QuanLyThueXeEntities db = new QuanLyThueXeEntities();
        // GET: LoaiController
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// cập nhật Controller và Action
        /// </summary>
        /// <returns></returns>
        public ActionResult CapNhat()
        {
            LoaiControllerQueries.CapNhat();
            TempData["ThongBao"] = "<p style='margin-top:5px;' class='alert alert-info'>Cập nhật thành công</p>";
            return RedirectToAction("MenuDanhSachNghiepVu");
        }
        /// <summary>
        /// Hiển thị danh sách controller
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuDanhSachNghiepVu()
        {
            var model = LoaiControllerQueries.LayDanhSachNghiepVu();
            return View(model);

        }

        /// <summary>
        /// Chỉnh sửa controller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChinhSuaNghiepVu(string MaController)
        {
            ViewBag.model = LoaiControllerQueries.ThongTinChiTiet(MaController);
            var model = LoaiControllerQueries.LayDanhSachNghiepVu();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaNghiepVu(LoaiControllerViewModel controllerInfo)
        {
            var model = LoaiControllerQueries.ChinhSuaNghiepVu(controllerInfo);
            return RedirectToAction("MenuDanhSachNghiepVu","LoaiController");
        }
    }
}
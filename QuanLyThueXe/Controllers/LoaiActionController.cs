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
    public class LoaiActionController : Controller
    {
        // GET: LoaiAction
        public ActionResult MenuDanhSachTinhNang()
        {
            ViewBag.ListController = LoaiControllerQueries.LayDanhSachNghiepVu();
            var model = LoaiActionQueries.LayDanhSachTinhNang();
            return View(model);
        }

        [HttpGet]
        public ActionResult ChinhSuaTinhNang(int MaAction)
        {
            ViewBag.ListController = LoaiControllerQueries.LayDanhSachNghiepVu();
            var model = LoaiActionQueries.LayDanhSachTinhNang();
            ViewBag.model = LoaiActionQueries.ThongTinChiTiet(MaAction);
            return View(model);
        }    
        [HttpPost]
        public ActionResult ChinhSuaTinhNang(LoaiActionViewModel actionInfo,FormCollection f)
        {
            var MoTa = f["MoTa"].ToString();
            var MaAction = f["MaAction"].ToString();
            var model = LoaiActionQueries.ChinhSuaTinhNang(actionInfo);
            return RedirectToAction("MenuDanhSachTinhNang", "LoaiAction");
        }
    }
}
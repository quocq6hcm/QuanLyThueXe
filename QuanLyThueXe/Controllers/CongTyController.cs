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
    public class CongTyController : Controller
    {
        QuanLyThueXeEntities db = new QuanLyThueXeEntities();

        //danh sách công ty
        [HttpGet]
        public ActionResult MenuDanhSachCongTy()
        {
            var lstCty = CongTiesQueries.LayDanhSachCongTy();
            return View(lstCty);
        }

        //thông tin chi tiết công ty
        public ActionResult ThongTinChiTietCty(string MaCT)
        {
            var model = CongTiesQueries.LayThongTinChiTietCty(MaCT);
            return View(model);
        }

        //thêm công ty
        [HttpGet]
        public ActionResult MenuThemCongTy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MenuThemCongTy(CongTiesViewModel CongTy)
        {
            CongTiesQueries.ThemCongTy(CongTy);
            return RedirectToAction("MenuDanhSachCongTy", "CongTy");
        }

        ////danh sách chỉnh sửa công ty
        //public ActionResult MenuDSChinhSuaCongTy()
        //{
        //    var model = CongTiesQueries.LayDanhSachCongTy();
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult ChinhSuaCongTy(string MaCT)
        {
            var model = CongTiesQueries.LayThongTinChiTietCty(MaCT);
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaCongTy(CongTiesViewModel Congty)
        {
            var model = CongTiesQueries.LayThongTinChiTietCty(Congty.MaCongTy);
            CongTiesQueries.Chinhsua_CongTy(Congty);
            return RedirectToAction("MenuDanhSachCongTy", "CongTy");
        }

        //xóa công ty
        [HttpGet]
        public ActionResult XoaCty(String MaCongTy)
        {
            CongTiesQueries.XoaCty(MaCongTy);
            return RedirectToAction("MenuDanhSachCongTy", "CongTy");
        }
	}

}
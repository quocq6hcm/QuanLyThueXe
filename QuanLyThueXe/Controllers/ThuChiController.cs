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
    public class ThuChiController : Controller
    {
        #region Phiếu chi
        /// <summary>
        /// Danh sach phieu chi
        /// </summary>
        /// <returns>list<PhieuChiViewModel></returns>
        public ActionResult MenuDanhSachPhieuChi()
        {
            var model = PhieuChiQueries.DanhSachPhieuChi();
            return View(model);
        }

        /// <summary>
        /// them phieu chi
        /// </summary>
        /// <param name = "SoPhieuChi"></param>
        /// <returns>list<PhieuChiViewModel></returns>
        [HttpGet]
        public ActionResult MenuThemPhieuChi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MenuThemPhieuChi(PhieuChiViewModel PC)
        {
            PhieuChiQueries.ThemPhieuChi(PC);
            return RedirectToAction("MenuDanhSachPhieuChi", "ThuChi");
        }

        //chỉnh sửa phiếu chi
        [HttpGet]
        public ActionResult ChinhSuaPC(string SoPC)
        {
            ViewBag.model = PhieuChiQueries.ChiTiet_PC(SoPC);
            var model = PhieuChiQueries.DanhSachPhieuChi();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaPC(PhieuChiViewModel Pc)
        {
            var model = PhieuChiQueries.ChinhSuaPC(Pc);
            return RedirectToAction("MenuDanhSachPhieuChi", "ThuChi");
        }
        #endregion

        #region Phiếu thu
        /// <summary>
        /// Danh sach phieu thu
        /// </summary>
        /// <returns>list<PhieuThuViewModel></returns>
        public ActionResult MenuDanhSachPhieuThu()
        {
            var model = PhieuThuQueries.DanhSachPhieuThu();
            return View(model);
        }

        /// <summary>
        /// them phieu thu
        /// </summary>
        /// <param name = "SoPhieuThu"></param>
        /// <returns>list<PhieuThuViewModel></returns>
        [HttpGet]
        public ActionResult MenuThemPhieuThu()
        {
            ViewBag.MaNV = NhanVienQueries.LayDanhSachNhanVien();
            return View();
        }
        [HttpPost]
        public ActionResult MenuThemPhieuThu(PhieuThuViewModel PT)
        {
            ViewBag.MaNV = NhanVienQueries.LayDanhSachNhanVien();
            PhieuThuQueries.ThemPhieuThu(PT);
            return RedirectToAction("MenuDanhSachPhieuThu", "ThuChi");
        }

        //chỉnh sửa phiếu thu
        [HttpGet]
        public ActionResult ChinhSuaPT(string SoPT)
        {
            ViewBag.model = PhieuThuQueries.ChiTiet_PT(SoPT);
            var model = PhieuThuQueries.DanhSachPhieuThu();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaPT(PhieuThuViewModel Pt)
        {
            var model = PhieuThuQueries.ChinhSuaPT(Pt);
            return RedirectToAction("MenuDanhSachPhieuThu", "ThuChi");
        }
        #endregion
    }
}
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
    public class CaiDatChungController : Controller
    {
        #region Loại xe
        //danh sách loại xe
        public ActionResult MenuDanhSachLoaiXe()
        {
            var lstLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            return View(lstLoaiXe);
        }

        //chỉnh sửa loại xe
        [HttpGet]
        public ActionResult ChinhSuaLoaiXe(string MaLoaiXe)
        {
            ViewBag.model = LoaiXeQueries.ChiTiet_LoaiXe(MaLoaiXe);
            var model = LoaiXeQueries.LayDanhSachLoaiXe();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChinhSuaLoaiXe(LoaiXeViewModel LoaiXe)
        {
            var model = LoaiXeQueries.ChinhSuaLoaiXe(LoaiXe);
            return RedirectToAction("MenuDanhSachLoaiXe", "CaiDatChung");
        }

        //thêm loại xe
        [HttpPost]
        public ActionResult ThemLX(LoaiXeViewModel Loaixe, FormCollection f)
        {
            LoaiXeQueries.ThemLoaiXe(Loaixe);
            return RedirectToAction("MenuDanhSachLoaiXe", "CaiDatChung");
        }

        #endregion

        #region Loại Nhân viên
        //danh sách loại nhân viên
        public ActionResult MenuDanhSachLoaiNV()
        {
            var lstLoaiNV = LoaiNhanVienQueries.DanhSachLoaiNhanVien();
            return View(lstLoaiNV);
        }

        //chỉnh sửa loại nhân viên
        [HttpGet]
        public ActionResult ChinhSuaLoaiNV(string MaLoaiNV)
        {
            ViewBag.model = LoaiNhanVienQueries.ChiTiet_LoaiNV(MaLoaiNV);
            var model = LoaiNhanVienQueries.DanhSachLoaiNhanVien();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChinhSuaLoaiNV(LoaiNhanVienViewModel LoaiNv)
        {
            var model = LoaiNhanVienQueries.ChinhSuaLoaiNV(LoaiNv);
            return RedirectToAction("MenuDanhSachLoaiNV", "CaiDatChung");
        }

        //thêm loại nhân viên
        [HttpPost]
        public ActionResult ThemLNV(LoaiNhanVienViewModel Loainv, FormCollection f)
        {
            LoaiNhanVienQueries.ThemLoaiNV(Loainv);
            return RedirectToAction("MenuDanhSachLoaiNV", "CaiDatChung");
        }
        #endregion

        #region Loại Khách Hàng

        //danh sách loại khách hàng
        public ActionResult MenuDanhSachLoaiKH()
        {
            var lstLoaiKH = LoaiKhachHangQueries.LayDanhSachLoaiKhachHang();
            return View(lstLoaiKH);
        }

        //chỉnh sửa loại khách hàng
        [HttpGet]
        public ActionResult ChinhSuaLoaiKH(string MaLoaiKH)
        {
            ViewBag.model = LoaiKhachHangQueries.ChiTiet_LoaiKH(MaLoaiKH);
            var model = LoaiKhachHangQueries.LayDanhSachLoaiKhachHang();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChinhSuaLoaiKH(LoaiKhachHangViewModel LoaiKh)
        {
            var model = LoaiKhachHangQueries.ChinhSuaLoaiKH(LoaiKh);
            return RedirectToAction("MenuDanhSachLoaiKH", "CaiDatChung");
        }

        //thêm loại khách hàng
        [HttpPost]
        public ActionResult ThemLKH(LoaiKhachHangViewModel Loaikh, FormCollection f)
        {
            LoaiKhachHangQueries.ThemLoaiKH(Loaikh);
            return RedirectToAction("MenuDanhSachLoaiKH", "CaiDatChung");
        }
        #endregion

        #region Thương hiệu xe
        //lấy danh sách thương hiệu
        public ActionResult MenuDSThuongHieu()
        {
            var lstTH = ThuongHieuQueries.LayDanhSachThuongHieu();
            return View(lstTH);
        }

        //chỉnh sửa thương hiệu
        [HttpGet]
        public ActionResult ChinhSuaTH(string MaThuongHieu)
        {
            ViewBag.model = ThuongHieuQueries.ChiTiet_TH(MaThuongHieu);
            var model = ThuongHieuQueries.LayDanhSachThuongHieu();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaTH(ThuongHieuViewModel Th)
        {
            var model = ThuongHieuQueries.ChinhSuaTH(Th);
            return RedirectToAction("MenuDSThuongHieu", "CaiDatChung");
        }

        //thêm thương hiệu
        [HttpPost]
        public ActionResult ThemTH(ThuongHieuViewModel Th, FormCollection f)
        {
            ThuongHieuQueries.ThemTH(Th);
            return RedirectToAction("MenuDSThuongHieu", "CaiDatChung");
        }
        #endregion

        #region Loại Bằng

        //lấy danh sách loại bằng
        public ActionResult MenuDanhSachLoaiBang()
        {
            var lstLoaiBang = LoaiBangQueries.LayDanhSachLoaiBang();
            return View(lstLoaiBang);
        }

        //chỉnh sửa loại khách hàng
        [HttpGet]
        public ActionResult ChinhSuaBang(string MaBang)
        {
            ViewBag.model = LoaiBangQueries.ChiTiet_LoaiBang(MaBang);
            var model = LoaiBangQueries.LayDanhSachLoaiBang();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChinhSuaBang(LoaiBangViewModel LB)
        {
            var model = LoaiBangQueries.ChinhSuaBang(LB);
            return RedirectToAction("MenuDanhSachLoaiBang", "CaiDatChung");
        }

        //thêm loại khách hàng
        [HttpPost]
        public ActionResult ThemBang(LoaiBangViewModel Loaib, FormCollection f)
        {
            LoaiBangQueries.ThemBang(Loaib);
            return RedirectToAction("MenuDanhSachLoaiBang", "CaiDatChung");
        }
        #endregion

        #region Chi Phí Phát Sinh

            #region danh sách chi phí phát sinh
            //danh sách chi phí phát sinh
            public ActionResult MenuChiPhiPhatSinh()
            {
                var lstCPPS = ChiPhiPhatSinhQueries.DanhSachChiPhiPhatSinh();
                return View(lstCPPS);
            }
            #endregion

            #region chỉnh sửa chi phí phát sinh
            [HttpGet]
            public ActionResult ChinhsuaCPPS(string MaChiPhi)
            {
                var cpps = ChiPhiPhatSinhQueries.ChiTiet_CPPS(MaChiPhi);
                return View(cpps);
            }

            [HttpPost]
            public ActionResult ChinhsuaCPPS(ChiPhiPhatSinhViewModel cpps)
            {
                ChiPhiPhatSinhQueries.ChinhSuaCPPS(cpps);
                return RedirectToAction("MenuChiPhiPhatSinh", "CaiDatChung");
            }
            #endregion

            #region thêm chi phí phát sinh
            [HttpGet]
            public ActionResult ThemCPPS()
            {
                return View();
            }

            [HttpPost]
            public ActionResult ThemCPPS(ChiPhiPhatSinhViewModel CPPS)
            {
                ChiPhiPhatSinhQueries.ThemCPPS(CPPS);
                return RedirectToAction("MenuChiPhiPhatSinh", "CaiDatChung");
            }
            #endregion

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Queries;

namespace QuanLyThueXe.Controllers
{
    public class DieuPhoiController : Controller
    {
        // GET: DieuPhoi
        public ActionResult MenuDieuPhoiXe()
        {
            HopDongQueries.CapNhatTrangThai();
            var model = CT_HopDongQueries.LayDanhSachChiTietHopDongTheoTrangThai("0");
            return View(model);
        }

        #region Chi tiết điều phối xe
        [HttpGet]
        public ActionResult ChiTietDieuPhoiXe(int SoCTHopDong)
        {
            var model = CT_HopDongQueries.LayThongTinChiTietCTHD(SoCTHopDong);
            ViewBag.Xe = XeQueries.LayDanhSachXeTheoLoaiXe(model.MaLoaiXe);
            ViewBag.LoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.CongTy = CongTiesQueries.LayDanhSachCongTy();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChiTietDieuPhoiXe(CT_HopDongViewModel CTHD, String MaXeCu)
        {
            //ViewBag.MaXe = new SelectList(XeQueries.LayDanhSachXeTheoLoaiXe(model.MaLoaiXe), "MaXe", "BienSo", model.MaXe);
            CT_HopDongViewModel model = CT_HopDongQueries.LayThongTinChiTietCTHD(CTHD.SoCTHopDong);
            var xe = XeQueries.LayThongTinChiTietXe(CTHD.MaXe);
            if (xe != null)
            {
                if (xe.Status == "1")
                {
                    DieuPhoiQueries.CapNhatXeBiTrung(xe.MaXe, model);
                }
                else
                {
                    DieuPhoiQueries.CapNhatXeBoChon(model.MaXe);
                }
            }
            if (String.IsNullOrEmpty(CTHD.MaXe) && String.IsNullOrEmpty(CTHD.BienSoXe))
            {
                DieuPhoiQueries.CapNhatXeBoChon(MaXeCu);
                CTHD.MaCongTy = null;
            }
            // hàm xử lý khi có mã xe cũ là của detra mà đổi sang thuê xe ngoài
            if (!String.IsNullOrEmpty(MaXeCu) && !String.IsNullOrEmpty(CTHD.BienSoXe))
            {
                DieuPhoiQueries.CapNhatXeBoChon(MaXeCu);
                CTHD.MaXe = null;
            }
            CT_HopDongQueries.CapNhatDieuPhoiXe(CTHD);
            TrangThaiQueries.CapNhatTrangThaiXeDangCho(CTHD.MaXe);
            return RedirectToAction("MenuLichTheoNgay", "Home");
        }
        #endregion

        public ActionResult MenuDieuPhoiTaiXe()
        {
            HopDongQueries.CapNhatTrangThai();
            var model = CT_HopDongQueries.LayDanhSachChiTietHopDongTheoTrangThai("0");
            return View(model);
        }

        #region Chi tiết điều phối tài xế
        [HttpGet]
        public ActionResult ChiTietDieuPhoiTaiXe(int SoCTHopDong)
        {
            var model = CT_HopDongQueries.LayThongTinChiTietCTHD(SoCTHopDong);
            ViewBag.TaiXe = NhanVienQueries.LayDSNVDangChoTheoMaLoaiNV("LNV2");
            ViewBag.PhuXe = NhanVienQueries.LayDanhSachNhanVien();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChiTietDieuPhoiTaiXe(CT_HopDongViewModel CTHD, string MaTaiXeCu, string MaPhuXeCu)
        {
            CT_HopDongViewModel model = CT_HopDongQueries.LayThongTinChiTietCTHD(CTHD.SoCTHopDong);
            var taixe = NhanVienQueries.LayThongTinChiTiet(CTHD.MaTaiXe);
            var phuxe = NhanVienQueries.LayThongTinChiTiet(CTHD.PhuXe);
            if (taixe != null)
            {
                if (taixe.Status == "1")
                {
                    DieuPhoiQueries.CapNhatTaiXeBiTrung(taixe.MaNV, model);
                }
                else
                {
                    DieuPhoiQueries.CapNhatNhanVienBoChon(model.MaTaiXe);
                }
            }

            if (phuxe != null)
            {
                if (phuxe.Status == "1")
                {
                    DieuPhoiQueries.CapNhatTaiXeBiTrung(phuxe.MaNV, model);
                }
                else
                {
                    DieuPhoiQueries.CapNhatNhanVienBoChon(model.PhuXe);
                }
            }
            if (String.IsNullOrEmpty(CTHD.MaTaiXe) && String.IsNullOrEmpty(CTHD.TaiXeNgoai))
            {
                DieuPhoiQueries.CapNhatNhanVienBoChon(MaTaiXeCu);
            }
            if (String.IsNullOrEmpty(CTHD.PhuXe))
            {
                DieuPhoiQueries.CapNhatNhanVienBoChon(MaPhuXeCu);
            }
            CT_HopDongQueries.CapNhatDieuPhoiTaiXe(CTHD);
            TrangThaiQueries.CapNhatTrangThaiPhuXeDangCho(CTHD.PhuXe);
            TrangThaiQueries.CapNhatTrangThaiTaiXeDangCho(CTHD.MaTaiXe);
            return RedirectToAction("MenuLichTheoNgay", "Home");
        }
        #endregion

        #region Lấy xe theo mã loại xe json
        public JsonResult LayLoaiXeTheoMaLoaiXe(string MaLoaiXe)
        {
            var result = XeQueries.LayDanhSachXeTheoLoaiXe(MaLoaiXe);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
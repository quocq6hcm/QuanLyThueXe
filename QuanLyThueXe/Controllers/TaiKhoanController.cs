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
    public class TaiKhoanController : Controller
    {
        QuanLyThueXeEntities db = new QuanLyThueXeEntities();
        // GET: TaiKhoan

        #region Đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string TaiKhoanNV, String MatKhau)
        {
            var model = TaiKhoanQueries.Login(TaiKhoanNV, MatKhau);
            if (model != null)
            {
                Session["TaiKhoan"] = model;
                TaiKhoanQueries.CapNhatOnline(model.TaiKhoanNV);
                return RedirectToAction("MenuLichTheoNgay", "Home");
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu sai! Vui lòng nhập lại...";
            return View();
        }
        #endregion

        #region Màn hình chờ
        [HttpGet]
        public ActionResult LockScreen()
        {
            TaiKhoanViewModel TaiKhoan = Session["TaiKhoan"] as TaiKhoanViewModel;
            ViewBag.TaiKhoanNV = TaiKhoan.TaiKhoanNV;
            var model = NhanVienQueries.LayThongTinChiTiet(TaiKhoan.MaNV);
            return View(model);
        }

        [HttpPost]
        public ActionResult LockScreen(string TaiKhoanNV, string MatKhau)
        {
            var model = TaiKhoanQueries.Login(TaiKhoanNV, MatKhau);
            if (model != null)
            {
              
                Session["TaiKhoan"] = model;
                return RedirectToAction("MenuLichTheoNgay", "Home");
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu sai! Vui lòng nhập lại...";
            return View();
        }
        #endregion

        #region Đăng xuất
        [HttpGet]
        public ActionResult Logout()
        {
            //TaiKhoan tk = Session["TaiKhoan"] as TaiKhoan;
            //TaiKhoanQueries.CapNhatOffline(tk.TaiKhoanNV);
            Session["TaiKhoan"] = null;
            return RedirectToAction("Login", "TaiKhoan");
        }
        #endregion

        #region Đổi mật khẩu
        [HttpGet]
        public ViewResult DoiMatKhau(String taiKhoan)
        {
            var model = TaiKhoanQueries.LayThongTinTaiKhoan(taiKhoan);
            return View(model);
        }

        [HttpPost]
        public ActionResult DoiMatKhau(TaiKhoanViewModel TaiKhoan,String MatKhauCu, String MatKhauMoi)
        {
            var model = TaiKhoanQueries.LayThongTinTaiKhoan(TaiKhoan.TaiKhoanNV);
            int i = 0, j=0;
            var check = TaiKhoanQueries.Login(TaiKhoan.TaiKhoanNV, MatKhauCu);
            if(check == null)
            {
                ViewBag.MatKhauSai = "Mật khẩu không đúng";
                i++;
            }
            else
            {
                i = 0;
            }
            if(TaiKhoan.MatKhau != MatKhauMoi)
            {
                ViewBag.MatKhauTrung = "Mật khẩu không trùng";
                j++;
            }
            else
            {
                j = 0;
            }
            if(i == 0 && j ==0 )
            {
                TaiKhoanQueries.DoiMatKhau(TaiKhoan);
                ViewBag.Success = "Đổi thành công!!";
            }
            return View(model);
        }
        #endregion

        #region Tạo tài khoản
        [HttpGet]
        public ViewResult MenuTaoTaiKhoan()
        {
            var model = NhanVienQueries.LayDanhSachNhanVien();
            ViewBag.Quyen = QuyenQueries.LayDanhSachQuyen();
            return View(model);
        }

        [HttpPost]
        public ActionResult MenuTaoTaiKhoan(TaiKhoanViewModel taiKhoan)
        {
            var model = NhanVienQueries.LayDanhSachNhanVien();
            ViewBag.Quyen = QuyenQueries.LayDanhSachQuyen();
            if (!TaiKhoanQueries.TaoTaiKhoan(taiKhoan))
            {
                ViewBag.TrungTK = "Tài khoản đã được sử dụng";
                ViewBag.ThanhCong = "Tạo tài khoản thất bại";
                return View(model);
            }
            else
            {
                TaiKhoanQueries.TaoTaiKhoan(taiKhoan);
                ViewBag.ThanhCong = "Tạo tài khoản thành công";
                return View(model);
            }
            
        }
        #endregion

        #region Danh sách tài khoản 
        [HttpGet]
        public ViewResult MenuDanhSachTaiKhoan()
        {
            var model = TaiKhoanQueries.LayDanhSachTaiKhoan();
            return View(model);
        }
        #endregion

        #region reset mật khẩu 
        [HttpGet]
        public ActionResult ResetPass(string taiKhoan)
        {
            TaiKhoanQueries.ResetPass(taiKhoan);
            return RedirectToAction("MenuDanhSachTaiKhoan", "TaiKhoan");
        }
        #endregion

        #region Thông tin chi tiết tài khoản
        //thông tin chi tiết tài khoản
        public ActionResult ChiTietTK(string tk)
        {
            var Tk = TaiKhoanQueries.LayChiTietTaiKhoan(tk);
            return View(Tk);
        }
        #endregion

        #region Cập nhật tài khoản
        [HttpGet]
        public ActionResult ChinhsuaTK(string id)
        {
            var tk = TaiKhoanQueries.LayChiTietTaiKhoan(id);
            ViewBag.MaNV = new SelectList(NhanVienQueries.LayDanhSachNhanVien(), "MaNV", "HoTen", tk.MaNV);
            ViewBag.MaQuyen = new SelectList(QuyenQueries.LayDanhSachQuyen(), "MaQuyen", "TenQuyen", tk.MaQuyen);
            return View(tk);
        }

        [HttpPost]
        public ActionResult ChinhsuaTK(TaiKhoanViewModel tk)
        {
            ViewBag.MaNV = new SelectList(NhanVienQueries.LayDanhSachNhanVien(), "MaNV", "HoTen", tk.MaNV);
            ViewBag.MaQuyen = new SelectList(QuyenQueries.LayDanhSachQuyen(), "MaQuyen", "TenQuyen", tk.MaQuyen);
            TaiKhoanQueries.ChinhsuaTaiKhoan(tk);
            return RedirectToAction("MenuDanhSachTaiKhoan", "TaiKhoan");
        }
        #endregion
    }
}
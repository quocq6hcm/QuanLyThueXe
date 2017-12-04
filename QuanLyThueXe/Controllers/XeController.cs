using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Queries;
using System.IO;
using QuanLyThueXe.Models;

namespace QuanLyThueXe.Controllers
{
    public class XeController : Controller
    {
        // GET: Xe
        [HttpGet]
        public ActionResult MenuDanhSachXe()
        {
            XeQueries.CapNhatDangKiemVaBaoHiemXe();
            var model = XeQueries.LayDanhSachXe();
            return View(model);
        }


        public ActionResult ThongTinChiTietXe(string MaXe)
        {
            var model = XeQueries.LayThongTinChiTietXe(MaXe);
            return View(model);
        }

        [HttpGet]
        public ActionResult MenuThemXe()
        {
            ViewBag.MaLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.MaCongTy = CongTiesQueries.LayDanhSachCongTy();
            ViewBag.MaThuongHieu = ThuongHieuQueries.LayDanhSachThuongHieu();
            ViewBag.MaNV = NhanVienQueries.LayDanhSachNhanVien();
            return View();
        }
        [HttpPost]
        public ActionResult MenuThemXe(XeViewModel xe, HttpPostedFileBase HinhXe)
        {
            if (HinhXe != null)
            {
                if (HinhXe.ContentType != "image/jpeg" && HinhXe.ContentType != "image/png" && HinhXe.ContentType != "image/gif" && HinhXe.ContentType != "image/jpg")
                {
                    ViewBag.upload += "Hình ảnh không hợp lệ <br />";
                }
                else
                {
                    var link = Path.GetFileName(HinhXe.FileName);

                    //cắt chuỗi local
                    string[] pathArr = link.Split('\\');
                    string tenHinhAnh = pathArr.Last().ToString();

                    if (System.IO.File.Exists("~/Content/HinhXe/" + tenHinhAnh)) ;
                    {
                        //cắt chuỗi tên hình ảnh
                        string[] nameArr = tenHinhAnh.Split('.');
                        string first = nameArr.First().ToString();
                        string fileName = first + "(Copy)" + "." + nameArr.Last().ToString();
                        tenHinhAnh = fileName;
                    }
                    //Lấy hình ảnh chuyển vào thư mục hình ảnh 
                    var path = Path.Combine(Server.MapPath("~/Content/HinhXe"), tenHinhAnh);
                    HinhXe.SaveAs(path);
                    xe.HinhAnh = tenHinhAnh;
                }
            }
            ViewBag.MaLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.MaCongTy = CongTiesQueries.LayDanhSachCongTy();
            ViewBag.MaThuongHieu = ThuongHieuQueries.LayDanhSachThuongHieu();
            ViewBag.MaNV = NhanVienQueries.LayDanhSachNhanVien();
            XeQueries.ThemXe(xe);
            return RedirectToAction("MenuDanhSachXe", "Xe");
        }

        [HttpGet]
        public ActionResult XoaXe(String MaXe)
        {
            XeQueries.XoaXe(MaXe);
            return RedirectToAction("MenuDanhSachXe", "Xe");
        }

        #region sửa xe
        [HttpGet]
        public ActionResult ChinhsuaXe(string id)
        {
            var xe = XeQueries.LayThongTinChiTietXe(id);
            ViewBag.MaLoaiXe = new SelectList(LoaiXeQueries.LayDanhSachLoaiXe().ToList(), "MaLoaiXe", "TenLoaiXe", xe.MaLoaiXe);
            ViewBag.MaCongTy = new SelectList(CongTiesQueries.LayDanhSachCongTy().ToList(), "MaCongTy", "TenCongTy", xe.MaCongTy);
            ViewBag.MaThuongHieu = new SelectList(ThuongHieuQueries.LayDanhSachThuongHieu().ToList(), "MaThuongHieu", "TenThuongHieu", xe.MaThuongHieu);
            ViewBag.MaNV = NhanVienQueries.LayDanhSachNhanVien();
            return View(xe);
        }

        [HttpPost]
        public ActionResult ChinhsuaXe(XeViewModel xe, HttpPostedFileBase HinhAnhXe)
        {
            ViewBag.MaLoaiXe = LoaiXeQueries.LayDanhSachLoaiXe();
            ViewBag.MaCongTy = CongTiesQueries.LayDanhSachCongTy();
            ViewBag.MaThuongHieu = ThuongHieuQueries.LayDanhSachThuongHieu();
            ViewBag.MaNV = NhanVienQueries.LayDanhSachNhanVien();

            var entity = new QuanLyThueXeEntities();
            var Xe = entity.Xes.SingleOrDefault(n => n.MaXe == xe.MaXe);
            if (HinhAnhXe == null)
            {
                xe.HinhAnh = Xe.HinhAnh;
                var model = XeQueries.ChinhSuaXe(xe);
                return RedirectToAction("MenuDanhSachXe", "Xe");
            }
            if (HinhAnhXe != null)
            {
                if (HinhAnhXe.ContentType != "image/jpeg" && HinhAnhXe.ContentType != "image/png" && HinhAnhXe.ContentType != "image/gif" && HinhAnhXe.ContentType != "image/jpg")
                {
                    ViewBag.upload += "Hình ảnh không hợp lệ <br />";
                }
                else
                {
                    var fileName = Path.GetFileName(HinhAnhXe.FileName);
                    //Lấy hình ảnh chuyển vào thư mục hình ảnh 
                    var path = Path.Combine(Server.MapPath("~/Content/HinhXe"), fileName);
                    HinhAnhXe.SaveAs(path);
                }
                xe.HinhAnh = HinhAnhXe.FileName;
            }
            XeQueries.ChinhSuaXe(xe);
            return RedirectToAction("MenuDanhSachXe", "Xe");
        }
        #endregion
    }
}
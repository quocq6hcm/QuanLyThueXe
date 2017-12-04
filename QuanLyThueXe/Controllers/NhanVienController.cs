using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;
using QuanLyThueXe.Queries;
using System.IO;

namespace QuanLyThueXe.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        QuanLyThueXeEntities db = new QuanLyThueXeEntities();

        [HttpGet]
        public ActionResult MenuDanhSachNV()
        {

            var lst = NhanVienQueries.LayDanhSachNhanVien();
            ViewBag.NhanVien = LoaiNhanVienQueries.DanhSachLoaiNhanVien();
            return View(lst);
        }

        //thông tin chi tiết nhân viên
        public ActionResult Details(string manv)
        {
            var nv = NhanVienQueries.LayThongTinChiTiet(manv);
            return View(nv);
        }
        [HttpGet]
        public ActionResult ChinhsuaNV(string id)
        {
            var nv = NhanVienQueries.LayThongTinChiTiet(id);
            ViewBag.MaLoaiNV = LoaiNhanVienQueries.DanhSachLoaiNhanVien();
            ViewBag.MaTinh = Tinh_TPQueries.LayDanhSachTinh_TP();
            ViewBag.Bang = LoaiBangQueries.LayDanhSachLoaiBang();
            return View(nv);
        }

        [HttpPost]
        public ActionResult ChinhsuaNV(NhanVienViewModel nv, HttpPostedFileBase HinhAnhNV)
        {
            ViewBag.MaLoaiNV = LoaiNhanVienQueries.DanhSachLoaiNhanVien();
            ViewBag.MaTinh = Tinh_TPQueries.LayDanhSachTinh_TP();
            ViewBag.MaBang = LoaiBangQueries.LayDanhSachLoaiBang();

            var entity = new QuanLyThueXeEntities();
            var nhanvien = entity.NhanViens.SingleOrDefault(n => n.MaNV == nv.MaNV);
            if (HinhAnhNV == null)
            {
                nv.HinhAnh = nhanvien.HinhAnh;
                var model = NhanVienQueries.ChinhsuaNV(nv);
                return RedirectToAction("MenuDanhSachNV", "NhanVien");
            }
            if (HinhAnhNV != null)
            {
                if (HinhAnhNV.ContentType != "image/jpeg" && HinhAnhNV.ContentType != "image/png" && HinhAnhNV.ContentType != "image/gif" && HinhAnhNV.ContentType != "image/jpg")
                {
                    ViewBag.upload += "Hình ảnh không hợp lệ <br />";
                }
                else
                {
                    var fileName = Path.GetFileName(HinhAnhNV.FileName);
                    //Lấy hình ảnh chuyển vào thư mục hình ảnh 
                    var path = Path.Combine(Server.MapPath("~/Content/HinhNV"), fileName);
                    HinhAnhNV.SaveAs(path);
                }
                nv.HinhAnh = HinhAnhNV.FileName;
            }
            NhanVienQueries.ChinhsuaNV(nv);
            return RedirectToAction("MenuDanhSachNV", "NhanVien");
        }

        #region Thêm nhân viên
        [HttpGet]
        public ActionResult MenuThemNV()
        {
            ViewBag.MaLoaiNV = LoaiNhanVienQueries.DanhSachLoaiNhanVien();
            ViewBag.MaTinh = Tinh_TPQueries.LayDanhSachTinh_TP();
            ViewBag.MaBang = LoaiBangQueries.LayDanhSachLoaiBang();
            return View();
        }

        [HttpPost]
        public ActionResult MenuThemNV(NhanVienViewModel Nhanvien, HttpPostedFileBase HinhNV)
        {

            ViewBag.MaLoaiNV = LoaiNhanVienQueries.DanhSachLoaiNhanVien();
            ViewBag.MaTinh = Tinh_TPQueries.LayDanhSachTinh_TP();
            ViewBag.MaBang = LoaiBangQueries.LayDanhSachLoaiBang();

            if (HinhNV != null)
            {
                if (HinhNV.ContentType != "image/jpeg" && HinhNV.ContentType != "image/png" && HinhNV.ContentType != "image/gif" && HinhNV.ContentType != "image/jpg")
                {
                    ViewBag.upload += "Hình ảnh không hợp lệ <br />";
                }
                else
                {
                    var link = Path.GetFileName(HinhNV.FileName);

                    //cắt chuỗi local
                    string[] pathArr = link.Split('\\');
                    string tenHinhAnh = pathArr.Last().ToString();

                    if (System.IO.File.Exists("~/Content/HinhNV/" + tenHinhAnh))
                    {
                        //cắt chuỗi tên hình ảnh
                        string[] nameArr = tenHinhAnh.Split('.');
                        string first = nameArr.First().ToString();

                        string fileName = first + "(Copy)" + "." + nameArr.Last().ToString();
                        tenHinhAnh = fileName;
                    }
                    //Lấy hình ảnh chuyển vào thư mục hình ảnh 
                    var path = Path.Combine(Server.MapPath("~/Content/HinhNV"), tenHinhAnh);
                    HinhNV.SaveAs(path);

                    Nhanvien.HinhAnh = tenHinhAnh;
                }
            }
            NhanVienQueries.ThemNhanVien(Nhanvien);
            return RedirectToAction("MenuDanhSachNV", "NhanVien");
        }
        #endregion


        public JsonResult TimNhanVienTheoLoaiNV(String MaLoaiNV)
        {
            var data = NhanVienQueries.LayDSNhanVienTheoMaLoaiNV(MaLoaiNV);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult XoaNV(String MaNV)
        {
            NhanVienQueries.XoaNV(MaNV);
            return RedirectToAction("MenuDanhSachNV", "NhanVien");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThueXe.Models;
using QuanLyThueXe.ViewModels;


namespace QuanLyThueXe.Queries
{
    public class LoaiControllerQueries
    {

        //Cap nhat controller va action
        public static void CapNhat()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                ReflectionController rc = new ReflectionController();
                List<Type> lstControllerType = rc.GetControllers("QuanLyThueXe");

                foreach (var controller in lstControllerType)
                {
                    LoaiController check = entity.LoaiControllers.SingleOrDefault(n => n.MaController == controller.Name);
                    LoaiController add = new LoaiController();
                    if (check == null)
                    {
                        add.MaController = controller.Name;
                        add.TenController = "Chưa mô tả";
                        entity.LoaiControllers.Add(add);

                        //Lấy danh action bằng cách gọi hàm getaction
                        List<string> listAction = rc.GetActions(controller);
                        foreach (string action in listAction)
                        {
                            var ten = controller.Name + "-" + action;
                            LoaiAction checkAction = entity.LoaiActions.SingleOrDefault(n => n.TenAction == ten);
                            LoaiAction addAction = new LoaiAction();
                            if (checkAction == null)
                            {
                                addAction.TenAction = ten;
                                addAction.Mota = "Chưa mô tả";
                                addAction.MaController = controller.Name;
                                addAction.UrlAction = "/" + (controller.Name).Substring(0, controller.Name.Length - 10) + "/" + action;
                                entity.LoaiActions.Add(addAction);
                            }
                            entity.SaveChanges();
                        }
                    }
                    else
                    {
                        List<string> listAction = rc.GetActions(controller);
                        foreach (string action in listAction)
                        {
                            var ten = controller.Name + "-" + action;
                            LoaiAction checkAction = entity.LoaiActions.SingleOrDefault(n => n.TenAction == ten);
                            LoaiAction addAction = new LoaiAction();
                            if (checkAction == null)
                            {
                                addAction.TenAction = ten;
                                addAction.Mota = "Chưa mô tả";
                                addAction.MaController = controller.Name;
                                addAction.UrlAction = "/" + (controller.Name).Substring(0, controller.Name.Length - 10) + "/" + action;
                                entity.LoaiActions.Add(addAction);
                            }
                            entity.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                entity.Dispose();
            }
        }
        //Lay danh sach controller
        public static List<LoaiControllerViewModel> LayDanhSachNghiepVu()
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from t in entity.LoaiControllers
                                select new LoaiControllerViewModel()
                                {
                                    MaController = t.MaController,
                                    TenController = t.TenController,
                                    Icon = t.Icon,
                                    STT = t.STT
                                }).OrderBy(n=>n.STT).ToList();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }

        //cap nhat controller
        public static Boolean ChinhSuaNghiepVu(LoaiControllerViewModel controller)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var loaiController = entity.LoaiControllers.SingleOrDefault(n=>n.MaController == controller.MaController);
                loaiController.TenController = controller.TenController;
                loaiController.Icon = controller.Icon;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return false;
            }
        }
        //lay thong tin chi tiet 1 controller
        public static LoaiControllerViewModel ThongTinChiTiet(string Macontroller)
        {
            var entity = new QuanLyThueXeEntities();
            try
            {
                var result = (
                                from c in entity.LoaiControllers
                                where c.MaController == Macontroller
                                select new LoaiControllerViewModel()
                                {
                                    MaController = c.MaController,
                                    TenController = c.TenController,
                                    Icon = c.Icon,
                                    STT = c.STT
                                }).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                entity.Dispose();
                return null;
            }
        }
    }
}
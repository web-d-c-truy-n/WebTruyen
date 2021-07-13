using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
namespace WebTruyen.Controllers
{
    public class AdminWebController : Controller
    {
       webtruyenptEntities wt = new webtruyenptEntities();
        // GET: AdminWeb
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (admin)
                Admin ad = wt.Admins.SingleOrDefault(n => n.Username == tendn && n.Password == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "AdminWeb");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult ThemAdmin()
        {
            return View();
        }
        // đăng nhập
        public ActionResult Login(string tk, string mk)
        {
            if (Helper.AdminAuth.login(tk, mk))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        // đăng xuất
        public ActionResult Logout()
        {
            Helper.AdminAuth.logout();
            return Json(true);
        }
        
    }
}
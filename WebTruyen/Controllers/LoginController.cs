using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Helper;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        // đăng nhập
        [HttpPost]
        public ActionResult Login(string tk, string mk)
        {
            string msg = Auth.login(tk, mk);
            TaiKhoan taiKhoan = Auth.user();
            return Json(new { taiKhoan?.Mail, taiKhoan?.HovaTen, taiKhoan?.SDT, msg = "Đăng nhập thành công" });
        }
        // đăng ký
        [HttpPost]
        public ActionResult Register(TaiKhoan taiKhoan)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            taiKhoan.NgayTao = DateTime.Now;
            taiKhoan.TinhTrang = 0;
            db.TaiKhoans.Add(taiKhoan);
            Auth.login(taiKhoan);
            return Json(true);
        }
        // đăng xuất
        [HttpPost]
        public ActionResult Logout()
        {
            Auth.logout();
            return Json(true);
        }
    }
}
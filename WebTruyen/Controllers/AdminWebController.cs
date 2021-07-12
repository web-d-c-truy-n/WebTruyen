using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTruyen.Controllers
{
    public class AdminWebController : Controller
    {
        // GET: AdminWeb
        public ActionResult Index()
        {
            return View();
        }
        // trang đăng nhập
        public ActionResult LoginAdmin()
        {
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
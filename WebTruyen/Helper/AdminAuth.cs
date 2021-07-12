using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;

namespace WebTruyen.Helper
{
    public class AdminAuth
    {
        public static void login(Admin taiKhoan)
        {
            HttpContext.Current.Session["admin"] = taiKhoan;
        }

        public static bool login(string username, string mk)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            Admin taiKhoan = db.Admins.Where(x => x.Username == username && x.Password == mk)?.First();
            if (taiKhoan != null)
            {
                HttpContext.Current.Session["admin"] = taiKhoan;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static TaiKhoan user()
        {
            return (TaiKhoan)HttpContext.Current.Session["admin"];
        }
        public static void logout()
        {
            HttpContext.Current.Session["admin"] = null;
        }
    }
}
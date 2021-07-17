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
            mk = Commons.MD5(mk);
            webtruyenptEntities db = new webtruyenptEntities();
            List<Admin> taiKhoan = db.Admins.Where(x => x.Username == username && x.Password == mk).ToList();
            if (taiKhoan != null && taiKhoan.Count >0)
            {
                HttpContext.Current.Session["admin"] = taiKhoan;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Admin user()
        {
            return (Admin)HttpContext.Current.Session["admin"];
        }
        public static void logout()
        {
            HttpContext.Current.Session["admin"] = null;
        }
    }
}
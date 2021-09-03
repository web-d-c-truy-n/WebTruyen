using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;

namespace WebTruyen.Helper
{
    public class Auth
    {
        public static List<TaiKhoan> taiKhoanNoiBo()
        {
            List<TaiKhoan> taiKhoans = HttpContext.Current.Application["taiKhoanNoiBo"] as List<TaiKhoan>;
            if (taiKhoans == null)
            {
                taiKhoans = new List<TaiKhoan>();
            }
            return taiKhoans;
        }
        public static void themTKNoiBo(TaiKhoan taiKhoan)
        {
            List<TaiKhoan> taiKhoans = HttpContext.Current.Application["taiKhoanNoiBo"] as List<TaiKhoan>;
            if (taiKhoans == null)
            {
                taiKhoans = new List<TaiKhoan>();
            }
            taiKhoans.Add(taiKhoan);
            HttpContext.Current.Application["taiKhoanNoiBo"] = taiKhoans;
        }
        public static void login(TaiKhoan taiKhoan)
        {
            HttpContext.Current.Session["taiKhoan"] = taiKhoan.MaTK;
        }

        public static string login(string mail, string mk)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<TaiKhoan> taiKhoan = db.TaiKhoans.Where(x => (x.Mail == mail) || (x.SDT == mail)).ToList();
            if (taiKhoan != null && taiKhoan.Count >0)
            {
                TaiKhoan taiKhoan1;
                if (!taiKhoanNoiBo().Exists(x=>x.MaTK == taiKhoan[0].MaTK))
                {
                    taiKhoan1 = taiKhoan[0];
                }
                else
                {
                    taiKhoan1 = taiKhoanNoiBo().Find(x => x.MaTK == taiKhoan[0].MaTK);
                }
                try
                {
                    taiKhoan1.DangNhap(mk);
                    HttpContext.Current.Session["taiKhoan"] = taiKhoan1.MaTK;
                    return "Đăng nhập thành công";
                }
                catch(Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return "Tài khoản hoặc mật khẩu không chính xác";
            }
        }
        public static TaiKhoan user()
        {
            try
            {
                int idtk = (int)HttpContext.Current.Session["taiKhoan"];
                webtruyenptEntities db = new webtruyenptEntities();
                TaiKhoan taiKhoan = db.TaiKhoans.Find(idtk);
                return taiKhoan;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public static void logout()
        {
            HttpContext.Current.Session["taiKhoan"] = null;
        }
        public static TacGia tacGia()
        {
            List<TacGia> tacGias = user().TacGias.ToList();
            if (tacGias.Count > 0)
                return tacGias.First();
            else
                return null;
        }

        public static bool SuaTk(TaiKhoan taiKhoan)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                TaiKhoan taiKhoan1 = db.TaiKhoans.Find(taiKhoan.MaTK);
                taiKhoan1.HovaTen = taiKhoan.HovaTen;
                taiKhoan1.Mail = taiKhoan.Mail;
                taiKhoan1.SDT = taiKhoan.SDT;
                if (taiKhoan.MatKhau != null)
                {
                    taiKhoan1.MatKhau = Commons.MD5(taiKhoan.MatKhau);
                }
                if (taiKhoan.Avatar != null)
                {
                    taiKhoan1.Avatar = taiKhoan.Avatar;
                }
                db.SaveChanges();
                return true;
            }catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
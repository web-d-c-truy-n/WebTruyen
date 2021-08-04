using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;

namespace WebTruyen.Helper
{
    public class Auth
    {
        public static void login(TaiKhoan taiKhoan)
        {
            HttpContext.Current.Session["taiKhoan"] = taiKhoan.MaTK;
        }

        public static string login(string mail, string mk)
        {
            mk = Commons.MD5(mk);
            webtruyenptEntities db = new webtruyenptEntities();
            List<TaiKhoan> taiKhoan = db.TaiKhoans.Where(x => (x.Mail == mail && x.MatKhau == mk) || (x.SDT == mail && x.MatKhau == mk)).ToList();
            if (taiKhoan != null && taiKhoan.Count >0)
            {
                switch (taiKhoan[0].TinhTrang)
                {
                    case ttTaiKhoan.biKhoa30p:
                        return "Tài khoản đã bị khóa 30 phút";
                    case ttTaiKhoan.biKhoa1h:
                        return "Tài khoản đã bị khóa 1 giờ";
                    case ttTaiKhoan.biKhoanVV:
                        return "Tài khoản đã bị khóa vĩnh viễn";
                }
                HttpContext.Current.Session["taiKhoan"] = taiKhoan[0].MaTK;
                return "Đăng nhập thành công";
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
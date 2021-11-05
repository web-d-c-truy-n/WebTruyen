using Rijndael256;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;

namespace WebTruyen.Helper
{
    [Serializable()]
    public class Auth
    {
        public static int MaTk()
        {
            int idtk = (int)HttpContext.Current.Session["taiKhoan"];
            return idtk;
        }
        public static TaiKhoan taiKhoanNoiBo(int maTK)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            try
            {
                string path = HttpContext.Current.Server.MapPath($"~/Asset/TaiKhoan/{maTK}.txt");
                string baseTK = Commons.readFile(path);
                SupportTaiKhoan supportTaiKhoan = (SupportTaiKhoan)Commons.StringToObject(baseTK);
                TaiKhoan taiKhoan = db.TaiKhoans.Find(maTK);
                taiKhoan.soLanNhapSai = supportTaiKhoan.soLanSai;
                return taiKhoan;
            }
            catch
            {
                return db.TaiKhoans.Find(maTK);
            }

        }
        public static void themTKNoiBo(TaiKhoan taiKhoan)
        {
            string path = HttpContext.Current.Server.MapPath($"~/Asset/TaiKhoan/{taiKhoan.MaTK}.txt");
            SupportTaiKhoan supportTaiKhoan = new SupportTaiKhoan();
            supportTaiKhoan.soLanSai = taiKhoan.soLanNhapSai;
            string baseTK = Commons.ObjectToString(supportTaiKhoan);
            Commons.writeFile(path, baseTK);
        }
        public static void login(TaiKhoan taiKhoan)
        {
            HttpContext.Current.Session["taiKhoan"] = taiKhoan.MaTK;
            themTKNoiBo(taiKhoan);
        }

        public static string login(string mail, string mk)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<TaiKhoan> taiKhoan = db.TaiKhoans.Where(x => (x.Mail == mail) || (x.SDT == mail)).ToList();
            if (taiKhoan != null && taiKhoan.Count > 0)
            {
                TaiKhoan taiKhoan1 = taiKhoanNoiBo(taiKhoan[0].MaTK);
                try
                {
                    taiKhoan1.DangNhap(mk);
                    HttpContext.Current.Session["taiKhoan"] = taiKhoan1.MaTK;
                    return "Đăng nhập thành công";
                }
                catch (Exception e)
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
        public static TacGia tacGia()
        {
            try
            {
                int idtk = (int)HttpContext.Current.Session["taiKhoan"];
                webtruyenptEntities db = new webtruyenptEntities();
                TacGia tacGia = db.TacGias.Where(x => x.MaTG == idtk).FirstOrDefault();
                return tacGia;
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
        public static bool SuaTk(TaiKhoan taiKhoan)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                TaiKhoan taiKhoan1 = db.TaiKhoans.Find(taiKhoan.MaTK);
                taiKhoan1.HovaTen = taiKhoan.HovaTen == "" ? null : taiKhoan.HovaTen ?? taiKhoan1.HovaTen;
                taiKhoan1.Mail = taiKhoan.Mail == "" ? null : taiKhoan.Mail ?? taiKhoan1.Mail;
                taiKhoan1.SDT = taiKhoan.SDT == "" ? null : taiKhoan.SDT ?? taiKhoan1.SDT;
                if (taiKhoan.MatKhau != null && taiKhoan.MatKhau != "")
                {
                    taiKhoan1.MatKhau = Commons.MD5(taiKhoan.MatKhau);
                }
                if (taiKhoan.Avatar != null && taiKhoan.Avatar != "")
                {
                    taiKhoan1.Avatar = taiKhoan.Avatar;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
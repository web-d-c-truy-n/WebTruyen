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
        private webtruyenptEntities db;
        public LoginController()
        {
            db = new webtruyenptEntities();
        }
        // GET: Login
        // đăng nhập
        [HttpPost]
        public ActionResult Login(string tk, string mk)
        {
            string msg = Auth.login(tk, mk);
            TaiKhoan taiKhoan = Auth.user();
            return Json(new { taiKhoan?.Mail, taiKhoan?.HovaTen, taiKhoan?.SDT, msg});
        }
        // đăng ký
        [HttpPost]
        public ActionResult Register(string HovaTen,string Mail,string MatKhau, string SDT, string Captcha)
        {
            if ((Session["Captcha"] as String) != Captcha)
            {
                return Json(new { msg = "Mã xác nhận không chính xác" });
            }
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.HovaTen = HovaTen;
            taiKhoan.Mail = Mail;
            taiKhoan.MatKhau = MatKhau;
            taiKhoan.SDT = SDT;
            if (db.TaiKhoans.Where(x => x.Mail == taiKhoan.Mail).ToList().Count > 0)
            {
                return Json(new { msg = "Email đã tồn tại" });
            }
            if (db.TaiKhoans.Where(x => x.SDT == taiKhoan.SDT).ToList().Count > 0)
            {
                return Json(new { msg = "Số điện thoại đã tồn tại" });
            }
            taiKhoan.DangKy();
            Auth.login(taiKhoan);
            return Json(new { msg = "Đăng ký thành công" });
        }
        // đăng xuất
        [HttpPost]
        public ActionResult Logout()
        {
            Auth.logout();
            return Json(true);
        }
        [HttpPost]
        public ActionResult TTUserHienTai()
        {
            TaiKhoan taiKhoan = Helper.Auth.user();
            if (taiKhoan != null)
            {
                return Json(new { taiKhoan.HovaTen, taiKhoan.Mail, taiKhoan.SDT, NgayTao = taiKhoan.NgayTao.ToString("dd/MM/yyyy"), taiKhoan.MaTK });
            }
            return Json(false);
        }
        // đăng nhập Admin
        [HttpPost]
        public ActionResult LoginAdmin(string tk, string mk)
        {
            return Json(Auth.login(tk, mk));
        }
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }
        // đăng ký tác giả
        [HttpPost]
        public ActionResult RegisterTacGia(string butDanh, int vaiTro)
        {
            int idtk = (int)Session["taiKhoan"];
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(idtk);
            taiKhoan.dangKyTacGia(db, vaiTro, butDanh);
            return Json(true);
        }
    }
}
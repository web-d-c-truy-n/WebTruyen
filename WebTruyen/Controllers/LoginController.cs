﻿using System;
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
        public ActionResult Register(TaiKhoan taiKhoan)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            if (db.TaiKhoans.Where(x=>x.Mail == taiKhoan.Mail).ToList().Count > 0)
            {
                return Json(new { msg = "Email đã tồn tại" });
            }
            if (db.TaiKhoans.Where(x => x.SDT == taiKhoan.SDT).ToList().Count > 0)
            {
                return Json(new { msg = "Số điện thoại đã tồn tại" });
            }
            taiKhoan.MatKhau = Helper.Commons.MD5(taiKhoan.MatKhau);
            taiKhoan.NgayTao = DateTime.Now;
            taiKhoan.TinhTrang = 0;
            db.TaiKhoans.Add(taiKhoan);
            db.SaveChanges();
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
            if (Helper.AdminAuth.login(tk, mk))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
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
            TacGia tacGia = new TacGia();
            tacGia.ButDanh = butDanh;
            tacGia.VaiTro = vaiTro;
            tacGia.NgayDangKy = DateTime.Now;
            tacGia.MaTK = Helper.Auth.user().MaTK;
            tacGia.DaDuyet = false;
            db.TacGias.Add(tacGia);
            db.SaveChanges();
            return Json(true);
        }
    }
}
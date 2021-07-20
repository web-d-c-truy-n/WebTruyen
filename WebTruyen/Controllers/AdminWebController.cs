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
        private webtruyenptEntities db;

        public AdminWebController() {
            {
                db = new webtruyenptEntities();
            } }

        // GET: AdminWeb
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThemAdmin()
        {
            return View();
        }
        // đăng xuất
        public ActionResult Logout()
        {
            Helper.AdminAuth.logout();
            return Json(true);
        }
        // trang quản lý tài khoản
        public ActionResult QLTaiKhoan()
        {
            var listTaiKhoanAdmin = new webtruyenptEntities().TaiKhoans;
            return View(listTaiKhoanAdmin);
        }
        
        // lấy danh sách tài khoản
        [HttpPost]
        public ActionResult dsTaiKhoan(int page, int pagesize)
        {
            List<TaiKhoan> taiKhoans = db.TaiKhoans.OrderBy(x => x.MaTK).Skip((page -1)* pagesize).Take(pagesize).ToList();
            var data = taiKhoans.Select(x => new
            {
                x.MaTK,x.HovaTen, x.Mail, x.SDT, x.TinhTrang,
                NgayTao = x.NgayTao.ToString("dd/MM/yyyy")
            });
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        // xem thông tin tài khoản
        public ActionResult ttTaiKhoan(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            return View(taiKhoan);
        }
        // danh sách tác phẩm
        [HttpPost]
        public ActionResult dsTacPham(int page, int pagesize)
        {
            var data = (from tr in db.Truyens join tl in db.TheLoais 
                        on tr.MaLoai equals tl.MaLoai
                        select new {tr.MaTruyen, tr.TacGiaGoc, tr.TenTruyen, Luotthich = tr.Luotthiches.Count }).Take(pagesize).ToList();
            return Json(data);
        }

        [HttpPost]
        public ActionResult setTinhTrang(int id,int tinhTrang)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            taiKhoan.TinhTrang = tinhTrang;
            db.SaveChanges();
            return Json(true);
        }
        [HttpPost]
        public ActionResult xoaTaiKhoan(int id)
        {
            db.TaiKhoans.Remove(db.TaiKhoans.Find(id));
            return Json(true);
        }
    }
}
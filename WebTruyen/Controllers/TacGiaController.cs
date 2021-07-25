using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    public class TacGiaController : Controller
    {
        webtruyenptEntities db = new webtruyenptEntities();
        // GET: TacGia
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string butDanh, int vaiTro)
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
        public ActionResult TrangTacGia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemAnh(HttpPostedFileBase fileBase)
        {
            return null;
        }
    }
}
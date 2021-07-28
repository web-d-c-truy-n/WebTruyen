using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Helper;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    [LoginTacGia]
    public class TacGiaController : Controller
    {
        private webtruyenptEntities db;
        public TacGiaController()
        {
            db = new webtruyenptEntities();
        }
        // GET: TacGia
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TrangTacGia()
        {
            if (Helper.Auth.tacGia() != null)
            {
                ViewBag.anhCuaTG = Helper.Auth.tacGia().QuanLyHinhAnhs.ToList();
                ViewBag.theLoai = db.TheLoais.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult ThemAnh(HttpPostedFileBase file)
        {
            if (!IsImage(file))
            {
                return Json(new {result = false, msg = "Đây không phải là hình ảnh!!!" });
            }
            string path = Server.MapPath("~/Asset/TacGia/Anh/");
            string fileName = Guid.NewGuid().ToString() +"_"+ file.FileName;
            file.SaveAs(path + fileName);
            QuanLyHinhAnh anh = new QuanLyHinhAnh();
            anh.URL = "/Asset/TacGia/Anh/"+fileName;
            anh.MaTG = Helper.Auth.user().TacGias.First().MaTG;
            db.QuanLyHinhAnhs.Add(anh);
            db.SaveChanges();
            return Json(new { result = true, msg = "Lưu thành công", anh.URL, anh.MaAnh});
        }
        private bool IsImage(HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }

            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            // linq from Henrik Stenbæk
            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
        // đăng truyện
        [HttpPost]
        public ActionResult DangTruyen(Truyen truyen)
        {
            try
            {
                truyen.NgayTao = DateTime.Now;
                truyen.DaDuyet = false;
                truyen.Khoa = false;
                db.Truyens.Add(truyen);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
            
        }
    }
}
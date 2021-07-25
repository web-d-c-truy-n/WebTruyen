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
    }
}
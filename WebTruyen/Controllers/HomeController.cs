using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using WebTruyen.Helper;

namespace WebTruyen.Controllers
{
    public class HomeController : Controller
    {
        private webtruyenptEntities db;
        public HomeController()
        {
            db = new webtruyenptEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult testAPT()
        {
            //TheLoai theLoai = new TheLoai();
            //string[] tl = { "Xuyên không", "Tu Tiên", "Lãng Mạn", "Tình Cảm", "Truyện Ngắn", "Ngôn Tình" };
            //foreach (string t in tl)
            //{
            //    db.TheLoais.Add(new TheLoai()
            //    {
            //        TenLoai = t,
            //        NgayTao = DateTime.Now,
            //    });
            //}
            //db.SaveChanges();
            return View();
        }

        public ActionResult testReact()
        {
            return View();
        }
        [HttpPost]
        [Login]
        public ActionResult dkTacGia(string butDanh, int vaiTro)
        {
            TacGia tacGia = new TacGia();
            tacGia.MaTK = Auth.user().MaTK;
            tacGia.ButDanh = butDanh;
            tacGia.NgayDangKy = DateTime.Now;
            tacGia.DaDuyet = false;
            tacGia.VaiTro = vaiTro;
            db.TacGias.Add(tacGia);
            return Json(true);
        }
        public ActionResult Tomtat()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        [Login]
        public ActionResult ThongtinTK()
        {
            return View();
        }
        public ActionResult DangKiTacGia()
        {
            return View();
        }
        public ActionResult Lichsu()
        {
            return View();
        }
        public ActionResult Theodoi()
        {
            return View();
        }
        // xuất ra các danh sách truyện hot ở trang chủ
        public ActionResult XuatCacTruyenHot(int page, int pagesize)
        {
            List<vTruyen> truyens = db.vTruyens.OrderByDescending(x=>x.LuotThich).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            return Json(truyens.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}
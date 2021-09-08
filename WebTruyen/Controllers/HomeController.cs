using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using WebTruyen.Helper;
using System.IO;
using System.Web.Script.Serialization;
using Rijndael256;

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
            //var truyens = db.vTruyens.OrderByDescending(x => x.NgayDang).Take(20).ToArray().Select(x=>new {truyen = x,Chuong = db.ChuongTruyens.Where(c=>c.MaTruyen == x.MaTruyen).OrderByDescending(c3=>c3.NgayTao).Select(c2=>new {c2.SoChuong, c2.TenChuong}).ToArray() });
            //ViewBag.truyenMoi = new JavaScriptSerializer().Serialize(truyens);
            ViewBag.truyenYeuThich = db.vTruyens.Where(x => !x.TamAn && (x.DaDuyet ?? false) && !(x.Khoa ?? false))
                .OrderByDescending(x => x.LuotThich).Take(6).ToArray();
            return View();
        }
        public ActionResult theLoai(string id)
        {
            string[] MaLoai = id.Split('-');
            ViewBag.MaLoai = MaLoai[MaLoai.Length - 1];
            ViewBag.truyenYeuThich = db.vTruyens.Where(x => !x.TamAn && (x.DaDuyet ?? false) && !(x.Khoa ?? false))
                .OrderByDescending(x => x.LuotThich).Take(6).ToArray();
            return View("Index");
        }
        public ActionResult TruyenChu()
        {
            ViewBag.LoaiTruyen = 1;
            ViewBag.truyenYeuThich = db.vTruyens.Where(x => !x.TamAn && (x.DaDuyet ?? false) && !(x.Khoa ?? false))
                .OrderByDescending(x => x.LuotThich).Take(6).ToArray();
            return View("Index");
        }
        public ActionResult TruyenTranh()
        {
            ViewBag.LoaiTruyen = 2;
            ViewBag.truyenYeuThich = db.vTruyens.Where(x => !x.TamAn && (x.DaDuyet ?? false) && !(x.Khoa ?? false))
                .OrderByDescending(x => x.LuotThich).Take(6).ToArray();
            return View("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult testAPI()
        {
            Truyen truyen = db.Truyens.Find(1);
            truyen.CapNhatLuotThich(Auth.user().MaTK);
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
            int idtk = (int)Session["taiKhoan"];
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(idtk);
            taiKhoan.dangKyTacGia(db,vaiTro,butDanh);
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
        public PartialViewResult DangKiTacGia()
        {            
            return PartialView();
        }
        public PartialViewResult Lichsu()
        {
            List<Truyen> truyens = (from tr in db.Truyens
                                    join lx in db.LuotXems
                                    on tr.MaTruyen equals lx.MaTruyen
                                    orderby lx.NgayXem descending
                                    group tr by tr.MaTruyen).SelectMany(x => x).ToList();
            return PartialView(truyens);
        }
        public PartialViewResult Theodoi()
        {
            return PartialView();
        }
        // xuất ra các danh sách truyện hot ở trang chủ
        public ActionResult XuatCacTruyenIndex(int page, int pagesize)
        {
            var vvTruyens = db.vvTruyens.OrderBy(x=>x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            return Json(vvTruyens, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XuatCacTruyenTheLoai(int page, int pagesize, int maLoai, int loaiTruyen)
        {
            vvTruyen[] vvTruyens;
            if (maLoai != -1 && loaiTruyen == -1)
                vvTruyens = db.vvTruyens.Where(x=>x.MaLoai == maLoai).OrderBy(x => x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            else if (maLoai == -1 && loaiTruyen !=-1)
                vvTruyens = db.vvTruyens.Where(x => x.LoaiTruyen == loaiTruyen).OrderBy(x => x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            else
                vvTruyens = db.vvTruyens.Where(x => x.MaLoai == maLoai && x.LoaiTruyen == loaiTruyen).OrderBy(x => x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            return Json(vvTruyens, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCaptcha()
        {
            Captcha captcha = new Captcha();
            Session["Captcha"] = captcha.captchaText;
            return Json(captcha.Img(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult timKiemTruyen(string timKiem, int page, int pagesize)
        {
            vvTruyen[] vvTruyens = Truyen.timKiem(timKiem).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            return Json(vvTruyens, JsonRequestBehavior.AllowGet);
        }
    }
}
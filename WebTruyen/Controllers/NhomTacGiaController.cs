using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Helper;
using WebTruyen.Models;
namespace WebTruyen.Controllers
{
    [Login]
    public class NhomTacGiaController : Controller
    {
        private webtruyenptEntities db;
        public NhomTacGiaController()
        {
            db = new webtruyenptEntities();
        }
        // GET: NhomTacGia
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            int maTK = Auth.MaTk();
            ViewBag.theLoai = db.TheLoais.ToList();
            ViewBag.anhCuaTG = db.QuanLyHinhAnhs.Where(x => x.MaTK == maTK).ToList();
            return View();
        }
        public PartialViewResult thongTinNhomTacGia()
        {
            return PartialView();
        }
        public PartialViewResult DangTacPham()
        {
            return PartialView();
        }
        public PartialViewResult DangChuong()
        {
            return PartialView();
        }
        public PartialViewResult ThanhVienNhom()
        {
            return PartialView();
        }
        public PartialViewResult PheDuyet()
        {
            return PartialView();
        }
    }
}
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
        public ActionResult Index(string id)
        {
            int maTK = Auth.MaTk();
            int maNhom = int.Parse(id.Split('-').Last());
            ViewBag.maNhom = maNhom;
            ViewBag.theLoai = db.TheLoais.ToList();
            ViewBag.anhCuaTG = db.QuanLyHinhAnhs.Where(x => x.MaTK == maTK).ToList();
            return View();
        }
        public PartialViewResult thongTinNhomTacGia(int maNhom)
        {
            NhomTG nhomTG = db.NhomTGs.Find(maNhom);
            ViewBag.xemNhom = false;
            return PartialView(nhomTG);
        }
        public PartialViewResult DangTacPham()
        {
            return PartialView();
        }
        public PartialViewResult DangChuong(int maNhom)
        {
            return PartialView();
        }
        public PartialViewResult ThanhVienNhom(int maNhom)
        {
            List<ThanhVienNhom> thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaNhom == maNhom && x.DaDuyet).ToList();
            return PartialView(thanhVienNhom);
        }
        public PartialViewResult PheDuyet(int maNhom)
        {
            List<ThanhVienNhom> thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaNhom == maNhom && !x.DaDuyet).ToList();
            return PartialView(thanhVienNhom);
        }

        public ActionResult pheDuyetThanhVie(int maTV, int maNhom)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x=>x.MaTK == maTK && x.MaNhom == maNhom);
            thanhVienNhom.DuyetThanhVien(maTV);
            return Json(true);
        }
        public ActionResult xoaThanhVien(int maTV, int maNhom)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x => x.MaTK == maTK && x.MaNhom == maNhom);
            thanhVienNhom.xoaThanhVien(maTV);
            return Json(true);
        }
        public ActionResult roiNhom(int maNhom)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x => x.MaTK == maTK && x.MaNhom == maNhom);
            thanhVienNhom.roiNhom(db);
            return Json(true);
        }
        public ActionResult timKiem(string timKiem)
        {
            return null;
        }
    }
}
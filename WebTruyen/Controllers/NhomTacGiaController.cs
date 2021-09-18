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
        public ActionResult Index(string id)
        {
            int maTK = Auth.MaTk();                                    
            int maNhom = int.Parse(id.Split('-').Last());
            bool isThanhVien = db.ThanhVienNhoms.FirstOrDefault(x => x.MaNhom == maNhom && x.MaTK == maTK)?.DaDuyet ?? false;
            NhomTG nhom = db.NhomTGs.Find(maNhom);
            if (!isThanhVien)
                return Redirect(Url.Action("ThongTinNhom", "TacGia", new { id = Commons.convertToUnSign3(nhom.TenNhom + "-" + maNhom) }));
            ViewBag.maNhom = maNhom;
            ViewBag.theLoai = db.TheLoais.ToList();
            ViewBag.anhCuaTG = db.QuanLyHinhAnhs.Where(x => x.MaTK == maTK).ToList();
            ViewBag.truongNhom = Auth.user().isTruongNhom(maNhom)?1:0;
            return View(nhom);
        }
        public PartialViewResult thongTinNhomTacGia(int maNhom)
        {
            NhomTG nhomTG = db.NhomTGs.Find(maNhom);
            ViewBag.xemNhom = false;
            ViewBag.TacPham = (from tg in db.TruyenTacGias
                               where tg.DangNhom == maNhom
                               join tr in db.vvTruyens
                               on tg.MaTruyen equals tr.MaTruyen
                               select tr);
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
        [HttpPost]
        public ActionResult pheDuyetThanhVien(int maTV, int maNhom)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x=>x.MaTK == maTK && x.MaNhom == maNhom);
            thanhVienNhom.DuyetThanhVien(maTV);
            return Json(true);
        }
        [HttpPost]
        public ActionResult xoaThanhVien(int maTV, int maNhom)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x => x.MaTK == maTK && x.MaNhom == maNhom);
            thanhVienNhom.xoaThanhVien(maTV);
            return Json(true);
        }
        [HttpPost]
        public ActionResult roiNhom(int maNhom)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x => x.MaTK == maTK && x.MaNhom == maNhom);
            thanhVienNhom.roiNhom(db);
            return Json(true);
        }
        public ActionResult timKiem(string timKiem, int maNhom)
        {
            List<TimKiemTV> thanhVien = db.Database.SqlQuery<TimKiemTV>($"TIMKIEMTV {maNhom},N'{timKiem}'").ToList();
            return Json(thanhVien.Select(x=>new {x.MaTK,x.ButDanh,x.Avatar, Ngayvaonhom= x.Ngayvaonhom.ToString("dd/MM/yyyy"), x.Vaitro }),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult thangChuc(int maTV, int maNhom)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x => x.MaTK == maTK && x.MaNhom == maNhom);
            thanhVienNhom.ThangChuc(maTV);
            return Json(true);
        }
        private class TimKiemTV
        {
            public int MaTK { get; set; }
            public string ButDanh { get; set; }
            public DateTime Ngayvaonhom { get; set; }
            public string Avatar { get; set; }
            public int Vaitro { get; set; }
        }
        public ActionResult layTruyenNhom(int maNhom)
        {
            Truyen[] truyen = (from tg in db.TruyenTacGias
                             where tg.DangNhom == maNhom
                             join tr in db.Truyens
                             on tg.MaTruyen equals tr.MaTruyen
                             select tr).ToArray();
            return Json(truyen.Select(x => new { x.MaTruyen, x.TenTruyen }));
        }    
        [HttpPost]
        public ActionResult suaTTNhom(int maNhom, string tenNhom, string khauHieu)
        {
            int maTK = Auth.MaTk();
            ThanhVienNhom thanhVien = db.ThanhVienNhoms.FirstOrDefault(x => x.MaNhom == maNhom && x.MaTK == maTK);
            thanhVien.suaTTNhom(tenNhom,khauHieu);
            return Json(true);
        }
        public PartialViewResult traoDoi(int maNhom)
        {
            ViewBag.maNhom = maNhom;
            return PartialView();
        }
        public ActionResult noiDungTraoDoi(int id)
        {
            if (!Auth.user().isTrongNhom(id)) return null;
            List <TraoDoiNhom> traoDoiNhoms = db.TraoDoiNhoms.Where(x => x.MaNhom == id).ToList();
            return Json(traoDoiNhoms.Select(x => new { x.MaNhom, x.MaTV, x.MaTraoDoi, x.NoiDung, x.PhanHoi, NgayViet = x.NgayViet.ToString("dd/MM/yyyy"), x.ButDanh, x.Avatar }),JsonRequestBehavior.AllowGet);
        }
    }
}
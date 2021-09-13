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
            if (Helper.Auth.user() != null)
            {
                ViewBag.anhCuaTG = Helper.Auth.user().QuanLyHinhAnhs.ToList();
                ViewBag.theLoai = db.TheLoais.ToList();
                ViewBag.cacTacGia = db.TacGias;
            }
            return View();
        }
        [HttpPost]
        public ActionResult ThemAnh(HttpPostedFileBase file)
        {
            if (!Commons.IsImage(file))
            {
                return Json(new { result = false, msg = "Đây không phải là hình ảnh!!!" });
            }
            string path = Server.MapPath("~/Asset/TacGia/Anh/");
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            file.SaveAs(path + fileName);
            QuanLyHinhAnh anh = new QuanLyHinhAnh();
            anh.URL = "/Asset/TacGia/Anh/" + fileName;
            anh.MaTK = Helper.Auth.user().MaTK;
            anh.them();
            return Json(new { result = true, msg = "Lưu thành công", anh.URL, anh.MaAnh });
        }
        // đăng truyện
        [HttpPost]
        public ActionResult DangTruyen(Truyen truyen, int vaiTro, int?[] dongTG, int? dangNhom)
        {
            try
            {
                if (dangNhom != null)
                {
                    int maTK = Auth.MaTk();
                    ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.FirstOrDefault(x => x.MaNhom == dangNhom && x.MaTK == maTK);
                    thanhVienNhom.vietTruyen(truyen, vaiTro);
                    return Json(true);
                }
                List<TruyenTacGia> truyenTacGias = new List<TruyenTacGia>();
                if (dongTG != null)
                {
                    foreach (int dtg in dongTG)
                    {
                        TruyenTacGia truyenTacGia = new TruyenTacGia();
                        truyenTacGia.MaTK = dtg;
                        truyenTacGia.VaiTro = vaiTro;
                        truyenTacGias.Add(truyenTacGia);
                    }
                }
                TruyenTacGia truyenTacGia1 = new TruyenTacGia();
                truyenTacGia1.MaTK = Auth.MaTk();
                truyenTacGia1.VaiTro = vaiTro;
                truyenTacGias.Add(truyenTacGia1);
                truyen.CreateOrUpdate(truyenTacGias);
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
        public PartialViewResult thongTinTacGia()
        {
            return PartialView(Auth.user());
        }
        public ActionResult laySoChuongTruyen(int id)
        {
            var chuongTruyens = db.ChuongTruyens.Where(x => x.MaTruyen == id).Select(x => new { x.MaTruyen, x.SoChuong, x.TenChuong }).ToArray();
            return Json(chuongTruyens, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createOrUpdateChuong(ChuongTruyen chuongTruyen)
        {
            chuongTruyen.createOrUpdate();
            return Json(true);
        }
        [HttpPost]
        public ActionResult xoaChuong(int maTruyen, int soChuong)
        {
            ChuongTruyen chuongTruyen = db.ChuongTruyens.FirstOrDefault(x => x.MaTruyen == maTruyen && x.SoChuong == soChuong);
            chuongTruyen.xoa(db);
            return Json(true);
        }
        public PartialViewResult thongKe()
        {
            int maTK = Auth.MaTk();
            List<Truyen> Truyen = (from tr in db.Truyens
                                       join tg in db.TruyenTacGias
                                       on tr.MaTruyen equals tg.MaTruyen
                                       where tg.MaTK == maTK
                                       select tr).ToList();
            return PartialView(Truyen);
        }
        public ActionResult layThongKe(int soNgay)
        {
            int maTK = Auth.MaTk();
            var LuotXem = db.Database.SqlQuery<ThongKe>($"tkLuotXem {soNgay},{maTK}");
            var LuotThich = db.Database.SqlQuery<ThongKe>($"tkLuotThich {soNgay},{maTK}");
            var LuotTheoDoi = db.Database.SqlQuery<ThongKe>($"tkLuotTheoDoi {soNgay},{maTK}");
            var json = new { LuotThich = LuotThich.Select(x=>new {Ngay = x.Ngay.ToString("dd/MM/yyyy"), x.SoLuong }), LuotXem = LuotXem.Select(x=>new {Ngay = x.Ngay.ToString("dd/MM/yyyy"), x.SoLuong }), LuotTheoDoi = LuotTheoDoi.Select(x=>new {Ngay = x.Ngay.ToString("dd/MM/yyyy"), x.SoLuong }) };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        private class ThongKe{
            public DateTime Ngay { get; set; }
            public int SoLuong { get; set; }
        }
        public ActionResult suaTacPham(int id)
        {
            Truyen truyen = db.Truyens.Find(id);
            int maTK = Auth.MaTk();
            if (Helper.Auth.user() != null)
            {
                ViewBag.anhCuaTG = Helper.Auth.user().QuanLyHinhAnhs.ToList();
                ViewBag.theLoai = db.TheLoais.ToList();
                ViewBag.cacTacGia = db.TacGias;
            }
            return View(truyen);
        }
        [HttpPost]
        public ActionResult xoaTruyen(int maTruyen)
        {
            Truyen truyen = db.Truyens.Find(maTruyen);
            db.Truyens.Remove(truyen);
            db.SaveChanges();
            return Json(true);
        }     
        [HttpPost]
        public ActionResult suaButDanh(string butDanh)
        {
            int maTK = Auth.MaTk();
            TaiKhoan tacGia = db.TaiKhoans.Find(maTK);
            tacGia.ButDanh = butDanh;
            db.SaveChanges();
            return Json(true);
        }
    }
}
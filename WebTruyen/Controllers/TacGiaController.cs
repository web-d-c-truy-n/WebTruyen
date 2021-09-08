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
                foreach (int dtg in dongTG)
                {
                    TruyenTacGia truyenTacGia = new TruyenTacGia();
                    truyenTacGia.MaTK = dtg;
                    truyenTacGia.VaiTro = vaiTro;
                    truyenTacGias.Add(truyenTacGia);
                }
                TruyenTacGia truyenTacGia1 = new TruyenTacGia();
                truyenTacGia1.MaTK = Auth.MaTk();
                truyenTacGia1.VaiTro = vaiTro;
                truyenTacGias.Add(truyenTacGia1);
                truyen.them(truyenTacGias);
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }
    }
}
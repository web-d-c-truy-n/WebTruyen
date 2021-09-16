using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
using WebTruyen.Helper;
namespace WebTruyen.Controllers
{
    [LoginAdmin]
    public class AdminWebController : Controller
    {
        private webtruyenptEntities db;

        public AdminWebController() 
        {
            {
                db = new webtruyenptEntities();
            } 
        }

        // GET: AdminWeb
        public ActionResult Index()
        {
            ViewBag.CountTK = db.TaiKhoans.ToList().Count;
            ViewBag.CountTG = db.TacGias.ToList().Count;
            ViewBag.CountTr = db.Truyens.ToList().Count;
            ViewBag.CountAd = db.Admins.ToList().Count;
            ViewBag.SoNguoiDK = db.TaiKhoans.ToList().Count;
            ViewBag.SoLuotXem = db.LuotXems.ToList().Count;
            ViewBag.SoLuotThich = db.LuotThichTruyens.ToList().Count;
            ViewBag.SoLuotTheoDoi = db.TheodoTGs.ToList().Count;
            return View();
        }
        public ActionResult ThemAdmin()
        {
            return View();
        }
        // đăng xuất
        public ActionResult Logout()
        {
            Helper.Auth.logout();
            return Json(true);
        }
        // trang quản lý tài khoản
        public ActionResult QLTaiKhoan()
        {
            var listTaiKhoanAdmin = new webtruyenptEntities().TaiKhoans;
            return View(listTaiKhoanAdmin);
        }
        [HttpPost]
        public ActionResult RegisterAdmin(TaiKhoan admin)
        {
            if (db.TaiKhoans.Where(x=>x.Mail == admin.Mail).ToList().Count > 0)
            {
                return Json(new { msg = "Tên tài khoản đã tồn tại" });
            }
            admin.dangKyAdmin(db);
            Auth.login(admin);
            return Json(new {msg="Đăng ký thành công" });
        }
        #region quản lý tài khoản
        // lấy danh sách tài khoản
        public ActionResult dsTaiKhoan(int page, int pagesize, string timKiem)
        {
            List<TaiKhoan> taiKhoans = TaiKhoan.timKiem(timKiem, (page - 1) * pagesize,pagesize);
            var data = taiKhoans.Select(x => new
            {
                x.MaTK,x.HovaTen, x.Mail, x.SDT, x.TinhTrang,
                NgayTao = x.NgayTao.ToString("dd/MM/yyyy")
            });
            return Json(data,JsonRequestBehavior.AllowGet);
        }        
        // xem thông tin tài khoản
        public ActionResult ttTaiKhoan(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            return View(taiKhoan);
        }

        [HttpPost]
        public ActionResult setTinhTrang(int id,int tinhTrang)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan.Mail == "admin") 
                return Json(false);
            taiKhoan.khoaTK(db,tinhTrang);
            return Json(true);
        }
        [HttpPost]
        public ActionResult xoaTaiKhoan(int id)
        {
            try
            {
                Auth.user().xoaTK(id);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }            
        }
        public ActionResult layTTTaiKhoan(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            return Json(new {
                taiKhoan.MaTK,
                taiKhoan.HovaTen,
                taiKhoan.Mail,
                taiKhoan.SDT,
                taiKhoan.TinhTrang,
                NgayTao = taiKhoan.NgayTao.ToString("dd/MM/yyyy"),
                taiKhoan.Avatar,
                ButDanh = taiKhoan.ButDanh ?? taiKhoan.HovaTen
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CapNhatTKAdmin(TaiKhoan taiKhoan)
        {
            string Mail = db.TaiKhoans.Find(taiKhoan.MaTK).Mail;
            if (Mail == "admin")
                return Json(false);
            bool rs = Helper.Auth.SuaTk(taiKhoan);
            return Json(rs);
        }
        #endregion
        #region quản lý tác giả
        public ActionResult DSTacGia(int page, int pagesize, string timKiem)
        {
            List<TacGia> taiKhoans = TacGia.timKiem(timKiem, (page - 1) * pagesize, pagesize);            
            var data = taiKhoans.Select(x => new
            {
                x.MaTG,
                x.ButDanh,
                TenTK = x.TaiKhoan().HovaTen,
                NgayDK = x.NgayDangKy?.ToString("dd/MM/yyyy"),
                x.VaiTro,
                x.DaDuyet,
                x.Khoa
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult XetDuyetTG(int id)
        {
            TaiKhoan tacGia = Helper.Auth.user();
            tacGia.duyetTacGia(id);            
            return Json(true);
        }
        public ActionResult LayThongTinTG(int id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            return Json(new { tacGia.MaTG, NgayDangKy = tacGia.NgayDangKy?.ToString("dd/MM/yyyy"), tacGia.DaDuyet, tacGia.ButDanh, tacGia.VaiTro, tacGia.Khoa }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult layTruyenTG(int maTG)
        {
           List<vTruyen> truyen = (from tr in db.vTruyens
                              join tg in db.TruyenTacGias
                              on tr.MaTruyen equals tg.MaTruyen
                              where tg.MaTK == maTG
                              select tr).ToList();
            return Json(truyen.Select(x=>new {x.MaTruyen,x.TenTruyen,x.AnhBia, NgayTao = x.NgayTao.ToString("dd/MM/yyyy"), NgayDang = x.NgayDang?.ToString("dd/MM/yyyy") }), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult XoaTacGia(int MaTG)
        {
            try
            {
                Auth.user().xoaTacGia(MaTG);
                return Json(true);
            }
            catch(Exception e)
            {
                return Json(false);
            }
            
        }
        [HttpPost]
        public ActionResult KhoaTacGia(int maTG)
        {
            Auth.user().khoaTacGia(maTG);
            return Json(true);
        }
        #endregion
        #region quản lý truyện
        public ActionResult dsTruyen(int page, int pagesize,string timKiem)
        {
            List<Truyen> truyens = Truyen.timKiem2(timKiem, (page - 1) * pagesize, pagesize);
            List<dsTruyen2> dsTruyens = new List<dsTruyen2>();
            foreach (Truyen x in truyens)
            {
                dsTruyen2 dsTruyen = new dsTruyen2()
                {
                    MaTruyen = x.MaTruyen,
                    TenTruyen = x.TenTruyen,
                    AnhBia = db.QuanLyHinhAnhs.Find(x.AnhBia).URL,
                    NgayTao = x.NgayTao.ToString("dd/MM/yyyy"),
                    NgayDang = x.NgayDang?.ToString("dd/MM/yyyy"),
                    DaDuyet = x.DaDuyet ?? false,
                    Khoa = x.Khoa ?? false
                };
                dsTruyens.Add(dsTruyen);
            }            
            return Json(dsTruyens, JsonRequestBehavior.AllowGet);
        }
        private class dsTruyen2
        {
            public int MaTruyen { get; set; }
            public string TenTruyen { get; set; }
            public string AnhBia { get; set; }
            public string NgayTao { get; set; }
            public string NgayDang { get; set; }
            public bool DaDuyet { get; set; }
            public bool Khoa { get; set; }
        }
        public ActionResult chiTietTruyen(int maTruyen)
        {
            Truyen x = db.Truyens.Find(maTruyen);
            string TinhTrang;
            if (x.Khoa??false)
            {
                TinhTrang = "Bị khóa";
            }else if (x.DaDuyet ?? false)
            {
                TinhTrang = "Đã duyệt";
            }
            else
            {
                TinhTrang = "Chưa duyệt";
            }
            var chiTiet = new
            {
                x.MaTruyen,
                AnhBia = x.QuanLyHinhAnh.URL,
                x.TenTruyen,
                TheLoai = x.TheLoai.TenLoai,
                LoaiTruyen = x.LoaiTruyen == Helper.loaiTruyen.truyenChu?"Truyện chữ":"Truyện tranh",
                TienDo = x.TinhTrang == Helper.ttTruyen.hoanThanh?"Hoàn thành":"Đang thực hiện",
                LuotXem = x.luotXem(),
                LuotThich = x.LuotThich().Count,
                TinhTrang,
                TacGia = (from tg in db.TacGias 
                          join tr_tg in db.TruyenTacGias
                          on tg.MaTG equals tr_tg.MaTK
                          where tr_tg.MaTruyen == x.MaTruyen
                          select new {tg.MaTG, tg.ButDanh}).ToArray(),
            };
            return Json(chiTiet, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult thaoTac(int maTruyen, int thaoTac)
        {
            int duyetTruyen = 1, khoaTruyen = 2, xoaTruyen = 3;
            if (thaoTac == duyetTruyen)
            {
                Auth.user().duyetTruyen(maTruyen);
            }
            else if (thaoTac == khoaTruyen)
            {
                Auth.user().khoaTruyen(maTruyen);
            }
            else if (thaoTac == xoaTruyen)
            {
                Auth.user().xoaTruyen_admin(maTruyen);
            }
            return Json(true);
        }
        #endregion
        public ActionResult dsAdmin(int page, int pagesize, string timKiem)
        {
            List<TaiKhoan> taiKhoans = TaiKhoan.timKiem_admin(timKiem, (page - 1) * pagesize, pagesize);
            var data = taiKhoans.Select(x => new
            {
                x.MaTK,
                x.HovaTen,
                x.Mail,
                x.SDT,
                x.TinhTrang,
                NgayTao = x.NgayTao.ToString("dd/MM/yyyy")
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
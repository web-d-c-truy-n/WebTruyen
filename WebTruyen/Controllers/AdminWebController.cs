using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;
namespace WebTruyen.Controllers
{
    public class AdminWebController : Controller
    {
        private webtruyenptEntities db;

        public AdminWebController() {
            {
                db = new webtruyenptEntities();
            } }

        // GET: AdminWeb
        public ActionResult Index()
        {
            ViewBag.CountTK = db.TaiKhoans.ToList().Count;
            ViewBag.CountTG = db.TacGias.ToList().Count;
            return View();
        }
        public ActionResult ThemAdmin()
        {
            return View();
        }
        // đăng xuất
        public ActionResult Logout()
        {
            Helper.AdminAuth.logout();
            return Json(true);
        }
        // trang quản lý tài khoản
        public ActionResult QLTaiKhoan()
        {
            var listTaiKhoanAdmin = new webtruyenptEntities().TaiKhoans;
            return View(listTaiKhoanAdmin);
        }
        [HttpPost]
        public ActionResult RegisterAdmin(Admin admin)
        {
            if (db.Admins.Where(x=>x.Username == admin.Username).ToList().Count > 0)
            {
                return Json(new { msg = "Tên tài khoản đã tồn tại" });
            }
            admin.Password = Helper.Commons.MD5(admin.Password);
            admin.Vaitro = 0;
            admin.Ngaytao = DateTime.Now;
            db.Admins.Add(admin);
            db.SaveChanges();
            return Json(new {msg="Đăng ký thành công" });
        }
        #region quản lý tài khoản
        // lấy danh sách tài khoản
        public ActionResult dsTaiKhoan(int page, int pagesize)
        {
            List<TaiKhoan> taiKhoans = db.TaiKhoans.OrderBy(x => x.MaTK).Skip((page -1)* pagesize).Take(pagesize).ToList();
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
        // danh sách tác phẩm
        [HttpPost]
        public ActionResult dsTacPham(int page, int pagesize)
        {
            var data = (from tr in db.Truyens join tl in db.TheLoais 
                        on tr.MaLoai equals tl.MaLoai
                        select new {tr.MaTruyen, tr.TacGiaGoc, tr.TenTruyen, Luotthich = tr.Luotthiches.Count }).Take(pagesize).ToList();
            return Json(data);
        }

        [HttpPost]
        public ActionResult setTinhTrang(int id,int tinhTrang)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            taiKhoan.TinhTrang = tinhTrang;
            db.SaveChanges();
            return Json(true);
        }
        [HttpPost]
        public ActionResult xoaTaiKhoan(int id)
        {
            db.TaiKhoans.Remove(db.TaiKhoans.Find(id));
            db.SaveChanges();
            return Json(true);
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
                NgayTao = taiKhoan.NgayTao.ToString("dd/MM/yyyy")
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        public ActionResult DSTacGia(int page, int pagesize)
        {
            List<TacGia> taiKhoans = db.TacGias.OrderBy(x => x.MaTG).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            var data = taiKhoans.Select(x => new
            {
                x.MaTG,
                x.ButDanh,
                TenTK = x.TaiKhoan.HovaTen,
                NgayDK = x.NgayDangKy.ToString("dd/MM/yyyy"),
                x.VaiTro,
                x.DaDuyet
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult XetDuyetTG(int id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            tacGia.DaDuyet = true;
            db.SaveChanges();
            return Json(true);
        }
        public ActionResult LayThongTinTG(int id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            return Json(new { tacGia.MaTG, tacGia.MaTK, NgayDangKy = tacGia.NgayDangKy.ToString("dd/MM/yyyy"), tacGia.DaDuyet, tacGia.ButDanh, tacGia.VaiTro }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhatTKAdmin(TaiKhoan taiKhoan)
        {
            bool rs = Helper.Auth.SuaTk(taiKhoan);
            return Json(rs);
        }
        [HttpPost]
        public ActionResult XoaTacGia(int MaTG)
        {
            try
            {
                TacGia tacGia = db.TacGias.Find(MaTG);
                db.TacGias.Remove(tacGia);
                db.SaveChanges();
                return Json(true);
            }
            catch(Exception e)
            {
                return Json(false);
            }
            
        }                
    }
}
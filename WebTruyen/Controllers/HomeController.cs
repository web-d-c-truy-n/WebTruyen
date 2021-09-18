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
            taiKhoan.dangKyTacGia(db, vaiTro, butDanh);
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
            return View(Auth.user());
        }
        public PartialViewResult DangKiTacGia()
        {
            return PartialView();
        }
        public ActionResult Lichsu()
        {
            List<vvTruyen> truyens = (from tr in db.vvTruyens
                                    join lx in db.LuotXems
                                    on tr.MaTruyen equals lx.MaTruyen
                                    orderby lx.NgayXem descending
                                    group tr by tr).Select(x => x.Key).ToList();
            return PartialView(truyens);
        }
        public PartialViewResult Theodoi()
        {
            List<vvTruyen> truyens = (from tr in db.vvTruyens
                                      join lx in db.LuotThichTruyens
                                      on tr.MaTruyen equals lx.MaTruyen
                                      orderby lx.NgayThich select tr).ToList();
            return PartialView(truyens);
        }
        // xuất ra các danh sách truyện hot ở trang chủ
        public ActionResult XuatCacTruyenIndex(int page, int pagesize)
        {
            var vvTruyens = db.vvTruyens.OrderByDescending(x => x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            return Json(vvTruyens, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XuatCacTruyenTheLoai(int page, int pagesize, int maLoai, int loaiTruyen)
        {
            vvTruyen[] vvTruyens;
            if (maLoai != -1 && loaiTruyen == -1)
                vvTruyens = db.vvTruyens.Where(x => x.MaLoai == maLoai).OrderBy(x => x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            else if (maLoai == -1 && loaiTruyen != -1)
                vvTruyens = db.vvTruyens.Where(x => x.LoaiTruyen == loaiTruyen).OrderByDescending(x => x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            else
                vvTruyens = db.vvTruyens.Where(x => x.MaLoai == maLoai && x.LoaiTruyen == loaiTruyen).OrderBy(x => x.NgayDang).Skip((page - 1) * pagesize).Take(pagesize).ToArray();
            return Json(vvTruyens, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCaptcha()
        {
            Captcha captcha = new Captcha();
            Session["Captcha"] = captcha.captchaText;
            return Json(captcha.Img(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult timKiemTruyen(string timKiem, int page, int pagesize)
        {
            vvTruyen[] vvTruyens = Truyen.timKiem(timKiem, (page - 1) * pagesize,pagesize).ToArray();
            return Json(vvTruyens, JsonRequestBehavior.AllowGet);
        }
        [Login]
        [HttpPost]
        public ActionResult upAvatar()
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase avatar = files[0];
            if (!Commons.IsImage(avatar))
            {
                return Json("Đây không phải là hình ảnh");
            }
            int maTK = Auth.MaTk();
            string path = Server.MapPath("~/Asset/TaiKhoan/Avatar/");
            avatar.SaveAs(path + maTK + "-" + avatar.FileName);
            TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(x => x.MaTK == maTK);
            taiKhoan.Avatar = "/Asset/TaiKhoan/Avatar/" + Auth.MaTk() + "-" + avatar.FileName;
            db.SaveChanges();
            return Json("Cập nhật avatar thành công");
        }
        [Login]
        [HttpPost]
        public ActionResult CapNhatTaiKhoanUser(TaiKhoan taiKhoan)
        {
            taiKhoan.MaTK = Auth.MaTk();
            bool rs = Auth.SuaTk(taiKhoan);
            return Json(rs);
        }
        [Login]
        [HttpPost]
        public ActionResult doiMatKhau(string mkHT, string mkMoi, string xnMK)
        {
            if (mkMoi != xnMK)
                return Json("Xác nhận mật khẩu không chính xác");
            string mk = Auth.user().MatKhau;
            mkHT = Commons.MD5(mkHT);
            if (mk != mkHT)
                return Json("Mật khẩu hiện tại không chính xác");
            TaiKhoan taiKhoan = db.TaiKhoans.Find(Auth.MaTk());
            taiKhoan.MatKhau = Commons.MD5(mkMoi);
            db.SaveChanges();
            return Json("Đổi mật khẩu thành công");
        }
        public ActionResult layTruyenTG(int id)
        {
            id = id == -1 ? Auth.MaTk() : id;
            vvTruyen[] truyens = (from tg in db.TruyenTacGias
                                where tg.MaTK == id
                                join tr in db.vvTruyens
                                on tg.MaTruyen equals tr.MaTruyen
                                select tr).ToArray();
            return Json(truyens, JsonRequestBehavior.AllowGet);
        }
        [Login]
        public ActionResult layNoiDungChuong(int maTr, int soChuong)
        {
            ChuongTruyen noiDung = db.ChuongTruyens.FirstOrDefault(x=>x.MaTruyen == maTr && x.SoChuong == soChuong);
            Truyen truyen = db.Truyens.Find(maTr);
            if (truyen.LoaiTruyen == loaiTruyen.truyenTranh)
            {
                int[] maAnh = noiDung.NoiDung.Split(',').Select(x => int.Parse(x)).ToArray();
                string nd = "";
                foreach (int anh in maAnh)
                {
                    QuanLyHinhAnh qla = db.QuanLyHinhAnhs.Find(anh);
                    nd += "<img src = '" + qla.URL + "' maAnh ='" + qla.MaAnh + "' />";
                }
                noiDung.NoiDung = nd;
            }
            return Json(new {noiDung.MaTruyen, noiDung.SoChuong, noiDung.TenChuong,noiDung.NoiDung, NgayTao = noiDung.NgayTao.ToString("dd/MM/yyyy") }, JsonRequestBehavior.AllowGet);
        }
        [Login]
        public PartialViewResult ttTacGia(int id)
        {            
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            ViewBag.isTheoDoi = true;
            return PartialView("~/Views/TacGia/thongTinTacGia.cshtml",taiKhoan);
        }
        [Login]
        public ActionResult TacGia(string id)
        {
            int MaTG = int.Parse(id.Split('-').Last());
            TaiKhoan taiKhoan = db.TaiKhoans.Find(MaTG);
            return View(taiKhoan);
        }
        [Login]
        [HttpPost]
        public ActionResult theoDoi(int maTG, bool isTheoDoi)
        {
            TheodoTG theodoTG = new TheodoTG();
            theodoTG.MaTG = maTG;
            theodoTG.MaTK = Auth.MaTk();
            HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
            hanhDongCuaTK.theoDoiTG(theodoTG, isTheoDoi);
            return Json(true);
            
        }
        [Login]
        public ActionResult dsTheoDoi()
        {
            int maTK = Auth.MaTk();
            List<TaiKhoan> theodoTG = (from td in db.TheodoTGs
                                 where td.MaTK == maTK
                                 join tk in db.TaiKhoans
                                 on td.MaTG equals tk.MaTK
                                 select tk).ToList();
            return PartialView(theodoTG);
        }
        [Login]
        public ActionResult getThongBao()
        {
            List<ThongBao> thongBaos = Auth.user().thongBaos();
            foreach (ThongBao thongBao in thongBaos)
            {
                thongBao.xem();
            }
            return Json(Auth.user().allThongBao().Select(x => x.ThongBao1),JsonRequestBehavior.AllowGet);
        }
        [Login]
        public ActionResult demThongBao()
        {
            return Json(Auth.user().thongBaos().Count, JsonRequestBehavior.AllowGet);
        }
    }
}
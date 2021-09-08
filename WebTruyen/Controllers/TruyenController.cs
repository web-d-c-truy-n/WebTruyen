﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Helper;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    [Login]
    public class TruyenController : Controller
    {
        // GET: Truyen
        private webtruyenptEntities db;
        public TruyenController()
        {
            db = new webtruyenptEntities();
        }
        public ActionResult TomTat(string id)
        {
            string[] maTruyens = id.Split('-');
            int maTruyen = int.Parse(maTruyens[maTruyens.Length - 1]);
            Truyen truyen = db.Truyens.FirstOrDefault(x=>x.MaTruyen == maTruyen);
            return View(truyen);
        }
        public ActionResult truyentranh(string id, int Chuong)
        {
            string[] maTruyens = id.Split('-');
            int maTruyen = int.Parse(maTruyens[maTruyens.Length - 1]);
            ChuongTruyen chuongTruyen = db.ChuongTruyens.FirstOrDefault(x => x.MaTruyen == maTruyen && x.SoChuong == Chuong);
            chuongTruyen.CapNhatLuotXem(Auth.MaTk());
            return View(chuongTruyen);
        }
        public ActionResult truyenchu(string id, int Chuong)
        {
            string[] maTruyens = id.Split('-');
            int maTruyen = int.Parse(maTruyens[maTruyens.Length - 1]);
            ChuongTruyen chuongTruyen = db.ChuongTruyens.FirstOrDefault(x => x.MaTruyen == maTruyen && x.SoChuong == Chuong);
            chuongTruyen.CapNhatLuotXem(Auth.MaTk());
            return View(chuongTruyen);
        }

        public ActionResult layBinhLuan(int id, int? soChuong)
        {
            if (soChuong != null || soChuong !=-1)                
                return Json(db.BinhLuans.Where(x => x.MaTruyen == id).ToList().Select(x => new {
                    x.MaBinhLuan,
                    x.HovaTen,
                    x.Avatar,
                    x.NoiDung,
                    NgayBinhLuan = x.NgayBinhLuan.ToString("dd/MM/yyyy hh:mm:ss tt"),
                    x.PhanHoi
                }).ToArray(), JsonRequestBehavior.AllowGet);
            else
                return Json(db.BinhLuans.Where(x => x.MaTruyen == id && x.SoChuong == soChuong).ToList().Select(x => new {
                    x.MaBinhLuan,
                    x.HovaTen,
                    x.Avatar,
                    x.NoiDung,
                    NgayBinhLuan = x.NgayBinhLuan.ToString("dd/MM/yyyy hh:mm:ss tt"),
                    x.PhanHoi
                }).ToArray(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult vietBinhLuan(int maTruyen, int? soChuong, string noiDung, int? phanHoi)
        {
            soChuong = soChuong == -1 ? null : soChuong;
            BinhLuan binhLuan = new BinhLuan();
            binhLuan.MaTruyen = maTruyen;
            binhLuan.SoChuong = soChuong;
            binhLuan.NoiDung = noiDung;
            binhLuan.MaTK = Auth.MaTk();
            binhLuan.PhanHoi = phanHoi == -1?null:phanHoi;
            HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
            int maBinhLuan = hanhDongCuaTK.binhLuan(binhLuan);
            var x = db.BinhLuans.FirstOrDefault(xx => xx.MaBinhLuan == maBinhLuan);
            return Json(new
            {
                x.MaBinhLuan,
                x.HovaTen,
                x.Avatar,
                x.NoiDung,
                NgayBinhLuan = x.NgayBinhLuan.ToString("dd/MM/yyyy hh:mm:ss tt"),
                x.PhanHoi
            });
        }
        [HttpPost]
        public ActionResult danhGia(int maTruyen, int danhGia)
        {
            DanhGia danhGia1 = new DanhGia();
            danhGia1.MaTK = Auth.MaTk();
            danhGia1.MaTruyen = maTruyen;
            danhGia1.DanhGia1 = danhGia.ToString();
            HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
            hanhDongCuaTK.danhGia(danhGia1);
            return Json(true);
        }
        [HttpPost]
        public ActionResult thichTruyen(int maTruyen, bool isThich)
        {
            LuotThichTruyen luotThichTruyen = new LuotThichTruyen();
            luotThichTruyen.MaTruyen = maTruyen;
            luotThichTruyen.MaTK = Auth.MaTk();
            HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
            hanhDongCuaTK.thichTruyen(luotThichTruyen, isThich);
            return Json(true);
        }
    }
}
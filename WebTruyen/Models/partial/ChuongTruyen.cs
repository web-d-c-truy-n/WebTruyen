using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class ChuongTruyen
    {
        public void them()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            try
            {
                if (!Auth.user().isTruyenCuaToi(MaTruyen)) return;
                this.NgayTao = DateTime.Now;
                db.ChuongTruyens.Add(this);
                db.SaveChanges();
                guithongbao();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void sua(webtruyenptEntities db)
        {
            try
            {
                if (!Auth.user().isTruyenCuaToi(MaTruyen)) return;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void xoa(webtruyenptEntities db)
        {
            try
            {
                if (!Auth.user().isTruyenCuaToi(MaTruyen)) return;
                db.ChuongTruyens.Remove(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void guithongbao()
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                List<LuotThichTruyen> luotThichTruyens = db.LuotThichTruyens.Where(x => x.MaTruyen == this.MaTruyen).ToList();
                foreach (LuotThichTruyen luotThichTruyen in luotThichTruyens)
                {
                    ThongBao thongBao = new ThongBao();
                    thongBao.MaTK = luotThichTruyen.MaTK;
                    thongBao.MaTruyen = this.MaTruyen;
                    thongBao.SoChuong = this.SoChuong;
                    string tenTruyen = db.Truyens.Find(this.MaTruyen).TenTruyen;
                    thongBao.ThongBao1 = $"Truyện {tenTruyen} đã cập nhật chương mới\nChương: {this.SoChuong} {this.TenChuong}";
                    HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                    hanhDongCuaTK.thongBao(thongBao);
                }
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void CapNhatLuotThich(int maTK,bool isThich)
        {
            try
            {
                LuotThichChuong luotThichChuong = new LuotThichChuong();
                luotThichChuong.MaTK = maTK;
                luotThichChuong.MaTruyen = this.MaTruyen;
                luotThichChuong.SoChuong = this.SoChuong;
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thichChuong(luotThichChuong,isThich);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void CapNhatLuotXem(int maTK)
        {
            try
            {
                LuotXem luotXem = new LuotXem();
                luotXem.MaTK = maTK;
                luotXem.MaTruyen = this.MaTruyen;
                luotXem.SoChuong = this.SoChuong;
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.Xem(luotXem);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void createOrUpdate()
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                ChuongTruyen chuongTruyen = db.ChuongTruyens.FirstOrDefault(x => x.MaTruyen == this.MaTruyen && x.SoChuong == this.SoChuong);
                if (chuongTruyen != null)
                {
                    chuongTruyen.NoiDung = this.NoiDung;
                    chuongTruyen.TenChuong = this.TenChuong;
                    chuongTruyen.Dang = this.Dang;
                    chuongTruyen.sua(db);
                }
                else
                {
                    them();
                }
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public List<BinhLuan> binhLuan()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.BinhLuans.Where(x => x.MaTruyen == this.MaTruyen && x.SoChuong == this.SoChuong).ToList();
        }
    }
}
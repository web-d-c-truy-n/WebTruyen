using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class TacGia
    {
        public TaiKhoan TaiKhoan()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.TaiKhoans.Find(this.MaTG);
        }

        public void dangKyTacGia()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(this.MaTG);
            taiKhoan.VaiTro = this.VaiTro == vtTacGia.tacGia ? vtTaiKhoan.tacGiaChuaDuyet : vtTaiKhoan.dichGiaChuaDuyet;
            taiKhoan.ngayDKTG = DateTime.Now;
            db.SaveChanges();
        }

        public void duyetTG()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(this.MaTG);
            taiKhoan.VaiTro = this.VaiTro == vtTacGia.tacGia ? vtTaiKhoan.tacGiaDaDuyet : vtTaiKhoan.dichGiaDaDuyet;
            db.SaveChanges();
        }
        public void khoaTG()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(this.MaTG);
            taiKhoan.VaiTro = this.VaiTro == vtTacGia.tacGia ? vtTaiKhoan.tacGiaBiKhoa : vtTaiKhoan.dichGiaBiKhoa;
            db.SaveChanges();
        }
        public void xoaTG()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(this.MaTG);
            taiKhoan.VaiTro = vtTaiKhoan.docGia;
            db.SaveChanges();
        }
        public static List<TacGia> timKiem(string timKiem, int skip, int take)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                return db.Database.SqlQuery<TacGia>($"TIMKIEM_TACGIA '{timKiem}',{skip},{take}").ToList();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
    }
}
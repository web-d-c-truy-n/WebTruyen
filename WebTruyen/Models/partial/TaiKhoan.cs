using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class TaiKhoan
    {
        private int soLanNhapSai;
        private void tangLanNhap()
        {
            this.soLanNhapSai++;
            switch (soLanNhapSai)
            {
                case 5:
                    this.TinhTrang = ttTaiKhoan.biKhoa30p;
                    this.NgayKhoa = DateTime.Now;
                    break;
                case 10:
                    this.TinhTrang = ttTaiKhoan.biKhoa1h;
                    this.NgayKhoa = DateTime.Now;
                    break;
                case 15:
                    this.TinhTrang = ttTaiKhoan.biKhoanVV;
                    this.NgayKhoa = DateTime.Now;
                    break;
            }
            refresh();
        }

        public void DangNhap(string matKhau)
        {
            int _30p = 1800;
            int _1h = 3600;
            if(this.TinhTrang == ttTaiKhoan.biKhoa30p && Commons.khoanCach2Giay(this.NgayKhoa?? DateTime.Now,DateTime.Now) <= _30p)
            {
                throw new InvalidOperationException("Tài khoản đã bị khóa 30 phút");
            }else if (this.TinhTrang == ttTaiKhoan.biKhoa1h && Commons.khoanCach2Giay(this.NgayKhoa ?? DateTime.Now, DateTime.Now) <= _1h)
            {
                throw new InvalidOperationException("Tài khoản đã bị khóa 1h");
            }else if (this.TinhTrang == ttTaiKhoan.biKhoanVV)
            {
                throw new InvalidOperationException("Tài khoản đã bị khóa vĩnh viễn");
            }
            else if (this.MatKhau != matKhau)
            {
                tangLanNhap();
                throw new InvalidOperationException("Tài khoản hoặc mật khẩu không chính xác");
            }
            else
            {
                this.TinhTrang = 0;
                refresh();
            }
        }

        public void DangKy()
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MatKhau = Commons.MD5(this.MatKhau);
                this.NgayTao = DateTime.Now;
                this.TinhTrang = 0;
                db.TaiKhoans.Add(this);
                db.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;                
                throw Ex;
            }
        }

        private void refresh()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            TaiKhoan taiKhoan = db.TaiKhoans.Find(this.MaTK);
            taiKhoan.NgayKhoa = this.NgayKhoa;
            taiKhoan.TinhTrang = this.TinhTrang;
            try
            {
                taiKhoan.sua(db);
            }
            catch
            {
                throw;
            }
        }

        public void sua(webtruyenptEntities db)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }

        }



    }
}
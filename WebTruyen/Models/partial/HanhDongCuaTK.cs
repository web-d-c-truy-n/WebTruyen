using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class HanhDongCuaTK
    {
        public void Xem(LuotXem luotXem)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MaTK = luotXem.MaTK;
                this.MaTruyen = luotXem.MaTruyen;
                this.NgayHanhDong = DateTime.Now;
                this.SoChuong = luotXem.SoChuong;
                this.LoaiHD = hdTaiKhoan.xemChuong;
                db.HanhDongCuaTKs.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void thichTruyen(LuotThichTruyen luotThichTruyen)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MaTK = luotThichTruyen.MaTK;
                this.MaTruyen = luotThichTruyen.MaTruyen;
                this.NgayHanhDong = DateTime.Now;
                this.LoaiHD = hdTaiKhoan.thichTruyen;
                db.HanhDongCuaTKs.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void thichChuong(LuotThichChuong luotThichChuong)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MaTK = luotThichChuong.MaTK;
                this.MaTruyen = luotThichChuong.MaTruyen;
                this.SoChuong = luotThichChuong.SoChuong;
                this.NgayHanhDong = DateTime.Now;
                this.LoaiHD = hdTaiKhoan.thichChuong;
                db.HanhDongCuaTKs.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void binhLuan(BinhLuan binhLuan)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MaTK = binhLuan.MaTK;
                this.MaTruyen = binhLuan.MaTruyen;
                this.SoChuong = binhLuan.SoChuong;
                this.GhiChu = binhLuan.NoiDung;
                this.PhanHoi = binhLuan.PhanHoi;
                this.NgayHanhDong = DateTime.Now;
                this.LoaiHD = hdTaiKhoan.binhLuan;
                db.HanhDongCuaTKs.Add(this);
                db.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void traoDoiNhom(TraoDoiNhom traoDoiNhom)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MaTK = traoDoiNhom.MaTV;
                this.GhiChu = traoDoiNhom.NoiDung;
                this.PhanHoi = traoDoiNhom.PhanHoi;
                this.MaNhom = traoDoiNhom.MaNhom;
                this.NgayHanhDong = DateTime.Now;
                this.LoaiHD = hdTaiKhoan.binhLuan;
                db.HanhDongCuaTKs.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void thongBao(ThongBao thongBao)
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                this.MaTK = thongBao.MaTK;
                this.MaTruyen = thongBao.MaTruyen;
                this.SoChuong = thongBao.SoChuong;
                this.TacGia = thongBao.TacGia;
                this.GhiChu = thongBao.ThongBao1;
                this.DaXem = thongBao.DaXem;
                this.PhanHoi = thongBao.PhanHoi;
                this.MaNhom = thongBao.MaNhom;
                this.NgayHanhDong = DateTime.Now;
                this.LoaiHD = hdTaiKhoan.thongBao;
                db.HanhDongCuaTKs.Add(this);
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
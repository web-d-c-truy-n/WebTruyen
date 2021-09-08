﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTruyen.Helper;

namespace WebTruyen.Models
{
    public partial class ThanhVienNhom
    {
        // vai trò nhóm trưởng
        public void DuyetThanhVien(int maTK)
        {

            try
            {
                if (this.Vaitro != vtNhom.nhomTruong) return;
                webtruyenptEntities db = new webtruyenptEntities();
                ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaTK == maTK && x.MaNhom == this.MaNhom).First();
                thanhVienNhom.DaDuyet = true;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò nhóm trưởng
        public void ThangChuc(int maTK)
        {
            try
            {
                if (this.Vaitro != vtNhom.nhomTruong) return;
                webtruyenptEntities db = new webtruyenptEntities();
                ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaTK == maTK && x.MaNhom == this.MaNhom).First();
                thanhVienNhom.Vaitro = vtNhom.nhomTruong;
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò nhóm trưởng
        public void xoaThanhVien(int maTK)
        {
            try
            {
                if (this.Vaitro != vtNhom.nhomTruong) return;
                webtruyenptEntities db = new webtruyenptEntities();
                ThanhVienNhom thanhVienNhom = db.ThanhVienNhoms.Where(x => x.MaTK == maTK && x.MaNhom == this.MaNhom).First();
                db.ThanhVienNhoms.Remove(thanhVienNhom);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void roiNhom(webtruyenptEntities db)
        {
            try
            {
                db.ThanhVienNhoms.Remove(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        // vai trò nhóm trưởng
        public void vietTruyen(Truyen truyen,int vaiTro)
        {
            try
            {
                if (this.Vaitro != vtNhom.nhomTruong) return;
                List<TruyenTacGia> truyenTacGia = new List<TruyenTacGia>();
                truyenTacGia.Add(new TruyenTacGia()
                {
                    MaTK = this.MaTK,
                    VaiTro = vaiTro,
                    DangNhom = this.MaNhom
                });
                truyen.them(truyenTacGia);
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public void traoDoi(string noiDung, int? phanHoi)
        {
            try
            {
                TraoDoiNhom traoDoiNhom = new TraoDoiNhom();
                traoDoiNhom.MaNhom = this.MaNhom;
                traoDoiNhom.MaTV = this.MaTK;
                traoDoiNhom.NoiDung = noiDung;
                traoDoiNhom.PhanHoi = phanHoi;
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.traoDoiNhom(traoDoiNhom);
            }catch(Exception e)
            {
                throw;
            }
            
        }
    }
}
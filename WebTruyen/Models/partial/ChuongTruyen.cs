﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    public partial class ChuongTruyen
    {
        public void them()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            try
            {
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
                    thongBao.ThongBao1 = $"Truyện {this.Truyen.TenTruyen} đã cập nhật chương mới\nChương: {this.SoChuong} {this.TenChuong}";
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
        public void CapNhatLuotThich(int maTK)
        {
            try
            {
                LuotThichChuong luotThichChuong = new LuotThichChuong();
                luotThichChuong.MaTK = maTK;
                luotThichChuong.MaTruyen = this.MaTruyen;
                luotThichChuong.SoChuong = this.SoChuong;
                HanhDongCuaTK hanhDongCuaTK = new HanhDongCuaTK();
                hanhDongCuaTK.thichChuong(luotThichChuong);
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
    }
}
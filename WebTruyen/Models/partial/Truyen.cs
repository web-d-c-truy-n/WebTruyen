﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    public partial class Truyen
    {
        public void them()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            try
            {
                this.NgayTao = DateTime.Now;
                db.Truyens.Add(this);
                db.SaveChanges();
                guiThongBao();
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
                db.Truyens.Remove(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        
        public static List<Truyen> timKiem(string timKiem)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.Database.SqlQuery<Truyen>($"TIMKIEM_Truyen N'{timKiem}'").ToList();
        }

        private void guiThongBao()
        {
            try
            {
                int maTG = Helper.Auth.tacGia().MaTG;
                string tenTG = Helper.Auth.tacGia().ButDanh;
                // lấy danh sách người theo doi tác giả này
                webtruyenptEntities db = new webtruyenptEntities();
                List<TheodoiTG> theodoiTGs = db.TheodoiTGs.Where(x => x.MaTG == maTG).ToList();
                // sau đó gửi thông báo cho từng người bằng cách lưu vào csdl
                foreach (TheodoiTG theodoiTG in theodoiTGs)
                {
                    db.ThongBaos.Add(new ThongBao() { MaTK = theodoiTG.MaTK, NgayThongBao = DateTime.Now, DaXem = false, ThongBao1 = $"Tác giả {tenTG} đã lên sóng truyện {this.TenTruyen}" });
                }
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
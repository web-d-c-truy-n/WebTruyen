using System;
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
                List<ChuongTruyen> chuongtruyen = db.ChuongTruyens.Where(x => x.MaTruyen == this.MaTruyen).ToList();
                foreach (ChuongTruyen chuongTruyen in chuongtruyen)
                {
                    db.ThongBaos.Add(new ThongBao() {MaTK=chuongTruyen.MaTruyen,NgayThongBao = DateTime.Now, DaXem = false, ThongBao1 = $"Truyện")
                }
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
    }
}
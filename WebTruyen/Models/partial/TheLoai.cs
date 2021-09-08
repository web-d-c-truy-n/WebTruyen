using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    public partial class TheLoai 
    {
        
        public void them()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            try
            {
                this.NgayTao = DateTime.Now;
                db.TheLoais.Add(this);
                db.SaveChanges();
            }catch(DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }
        public void xoa(webtruyenptEntities db)
        {
            try
            {
                db.TheLoais.Remove(this);
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
        public static List<TheLoai> timkiem (string timkiem)
        {
            webtruyenptEntities db = new webtruyenptEntities();
            return db.Database.SqlQuery<TheLoai>($"TIMKIEM_THELOAI N'{timkiem}'").ToList();
        }
    }
}
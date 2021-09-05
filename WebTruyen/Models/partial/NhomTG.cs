using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    public partial class NhomTG
    {
        public void taoNhom()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            try
            {
                db.NhomTGs.Add(this);
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
                db.NhomTGs.Remove(this);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException Ex = ex.GetBaseException() as SqlException;
                throw Ex;
            }
        }

        public List<TacGia> xemDanhSachThanhVien()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<TacGia> tacGias = (from tv in db.ThanhVienNhoms where tv.MaNhom == this.MaNhom
                                    join tg in db.TacGias
                                    on tv.MaTK equals tg.MaTG
                                    select tg).ToList();
            return tacGias;
        }
        public List<Truyen> xemDanhSachTruyen()
        {
            webtruyenptEntities db = new webtruyenptEntities();
            List<Truyen> truyens = (from tg in db.TruyenTacGias
                                    where tg.DangNhom == this.MaNhom
                                    join tr in db.Truyens
                                    on tg.MaTruyen equals tr.MaTruyen
                                    select tr).ToList();
            return truyens;
        }
    }
}
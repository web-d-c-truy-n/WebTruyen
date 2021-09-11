using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    public partial class ThongBao
    {
        public void xem()
        {
            try
            {
                webtruyenptEntities db = new webtruyenptEntities();
                HanhDongCuaTK hanhDongCuaTK = db.HanhDongCuaTKs.Find(this.MaThongBao);
                hanhDongCuaTK.DaXem = true;
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